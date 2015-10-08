using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;
using Auslink.Web.New.Attributes;

namespace Auslink.Web.New.Controllers
{
    public class InvestorsController : Controller
    {
        public ActionResult Prospective()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/sustainable-buildings.png";
            page.RedLogoText = "Sustainable Buildings";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/investors-prospective.jpg";

            return View(page);
        }

        [ImportModelStateFromTempData]
        public virtual ActionResult CurrentUnitholders()
        {
            if (this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("CurrentUnitholders", "Members");
            }

            PageViewModel page = new PageViewModel();
            page.Login.LoginLocation = LoginLocation.CurrentUnitHolders;
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/low-management-fees.png";
            page.RedLogoText = "Low Management Fees";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/investors-unitholders.jpg";


            return View(page);
        }

    }
}
