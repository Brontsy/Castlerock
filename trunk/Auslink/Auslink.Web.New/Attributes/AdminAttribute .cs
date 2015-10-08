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
            return true;
        }
    }
}
