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
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/low-entry-costs.png";
            page.RedLogoText = "Low Entry Costs";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/about-key-features.jpg";

            return View(page);
        }

        public ActionResult KeyFeatures()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/low-entry-costs.png";
            page.RedLogoText = "Low Entry Costs";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/about-key-features.jpg";

            return View(page);
        }

    }
}