using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Overview()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/low-entry-costs.png";
            page.RedLogoText = "Low Entry Costs";
            page.HeaderImageUrl = "/Content/Images/header/about-key-features.jpg";

            return View(page);
        }

        public ActionResult KeyFeatures()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/low-entry-costs.png";
            page.RedLogoText = "Low Entry Costs";
            page.HeaderImageUrl = "/Content/Images/header/about-key-features.jpg";

            return View(page);
        }

    }
}