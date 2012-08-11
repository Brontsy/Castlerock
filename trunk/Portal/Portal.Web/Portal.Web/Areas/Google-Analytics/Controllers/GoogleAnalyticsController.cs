using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Websites.Interfaces;
using Portal.Web.Models;
using Portal.Web.Attributes;

namespace Portal.Web.Areas.GoogleAnalytics.Controllers
{
    [AdministratorFilter]
    public class GoogleAnalyticsController : Controller
    {
        private IWebsite _website = null;

        public GoogleAnalyticsController(IWebsite website)
        {
            this._website = website;
        }

        public ActionResult Index()
        {
            return View(new PageViewModel(this._website));
        }

    }
}
