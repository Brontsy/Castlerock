using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;

namespace Auslink.Web.New.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult TrustManager()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/management-expertise.png";
            page.RedLogoText = "Management Expertise";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/management.jpg";

            return View(page);
        }

        public ActionResult PropertyManager()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/management-expertise.png";
            page.RedLogoText = "Management Expertise";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/management.jpg";

            return View(page);
        }

    }
}
