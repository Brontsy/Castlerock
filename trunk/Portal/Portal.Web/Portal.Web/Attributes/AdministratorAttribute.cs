using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Portal.Membership;
using Ninject;
using Portal.Membership.Models;
using Portal.Membership.Enums;
using System.Web.Routing;
using System.Web.Security;

namespace Portal.Web.Attributes
{
    public class AdministratorFilterAttribute : FilterAttribute { }

    public class AdministratorFilter : IActionFilter
    {
        [Inject]
        public IMembershipService MembershipService { get; set; }

        public AdministratorFilter(IMembershipService memberService)
        {
            this.MembershipService = memberService;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // if we are logged in
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string memberId = filterContext.HttpContext.User.Identity.Name;

                Member member = this.MembershipService.GetMemberById(int.Parse(memberId));

                if (!member.Roles.ToList().Exists(o => o.Type == RoleType.Administrator))
                {
                    FormsAuthentication.SignOut();
                    filterContext.Result = new RedirectToRouteResult("No-Permission", new RouteValueDictionary());
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult("Login", new RouteValueDictionary());
            }
        }
    }
}
