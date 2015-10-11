using Auslink.Membership.Models;
using Auslink.Membership.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Providers
{
    public interface ILoginProvider
    {
        LoginResult Login(string email, string password, bool rememberMe);

        void Logout();
    }

    public class LoginResult
    {

        public bool Successful { get; private set; }

        public Member Member { get; private set; }

        private LoginResult() { }

        public static LoginResult Success(Member member)
        {
            return new LoginResult() { Successful = true, Member = member };
        }
        public static LoginResult InvalidUsernamePassword()
        {
            return new LoginResult() { Successful = false };
        }
    }

    public class LoginProvider : ILoginProvider
    {
        private IMembershipService _membershipService;
        private IAuthenticationManager _authenticationManager;

        public LoginProvider(IMembershipService membershipService, IAuthenticationManager authenticationManager)
        {
            this._membershipService = membershipService;
            this._authenticationManager = authenticationManager;
        }

        public LoginResult Login(string email, string password, bool rememberMe)
        {
            bool isValid = this._membershipService.Authenticate(email, password);

            if (isValid)
            {
                Member member = this._membershipService.GetMemberByUsername(email);

                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, member.MemberId.ToString()), }, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);

                // if you want roles, just add as many as you want here (for loop maybe?)
                identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));
                // tell OWIN the identity provider, optional
                // identity.AddClaim(new Claim(IdentityProvider, "Simplest Auth"));

                this._authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = rememberMe
                }, identity);

                return LoginResult.Success(member);
            }

            return LoginResult.InvalidUsernamePassword();
        }

        public void Logout()
        {
            this._authenticationManager.SignOut();
        }
    }
}
