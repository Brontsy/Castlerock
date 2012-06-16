using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Portal.Membership;
using Portal.Web.Models;
using Portal.Websites.Interfaces;

namespace Portal.Web.Controllers
{
    public class PermissionController : PortalBaseController
    {
        public PermissionController(IWebsite website)
            : base (website)
        {
        }
        
        public ActionResult Invalid()
        {
            return View(new PageViewModel(this.Website));
        }
    }
}
