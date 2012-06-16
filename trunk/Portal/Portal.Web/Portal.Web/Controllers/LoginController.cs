using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Portal.Membership;
using Portal.Web.Attributes;
using Portal.Web.Areas.Membership;
using Portal.Websites.Interfaces;
using Portal.Web.Models;
using Portal.Membership.Models;

namespace Portal.Web.Controllers
{
    public class LoginController : PortalBaseController
    {
        private IMembershipService _membershipService = null;

        public LoginController(IWebsite website, IMembershipService membershipService)
            : base (website)
        {
            this._membershipService = membershipService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Login", new LoginViewModel(this.Website));
        }
        
        [AcceptVerbs(HttpVerbs.Post), ExportModelStateToTempData]
        public ActionResult Index(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                if (this._membershipService.Authenticate(Username, Password))
                {
                    Member member = this._membershipService.GetMemberByUsername(Username);
                    FormsAuthentication.SetAuthCookie(member.Id.ToString(), false);

                    return this.Redirect(this.Website.Components[0].Url);
                }
                else
                {
                    this.ModelState.AddModelError("Email", "Invalid username or password, please try again");
                }
            }

            return View("Login", new LoginViewModel(this.Website) { Username = Username, Password = Password });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToRoute("Login");

        }
    }
}
