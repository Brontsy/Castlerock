using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;

namespace Auslink.Web.New.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/attractive-yields.png";
            page.RedLogoText = "Attractive Yields";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/contact-us.jpg";

            return View("404", page);
        }

        public ActionResult Unknown()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/attractive-yields.png";
            page.RedLogoText = "Attractive Yields";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/contact-us.jpg";

            return View("500", page);
        }
    }
}
