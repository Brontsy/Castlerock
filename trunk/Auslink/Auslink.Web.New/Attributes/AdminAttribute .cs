using Auslink.Membership.Models;
using Auslink.Membership.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Attributes
{
    public class AdminAttribute : AuthorizeAttribute
    {
        public IMembershipService MembershipService { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(httpContext.User.Identity.IsAuthenticated)
            {
                int memberId;

                if (int.TryParse(httpContext.User.Identity.Name, out memberId))
                {
                    Member member = this.MembershipService.GetMemberById(memberId);
                    if (member != null && member.Roles.Contains(Role.Administrator))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
