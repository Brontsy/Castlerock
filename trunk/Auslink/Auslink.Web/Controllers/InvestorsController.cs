using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;
using Auslink.Web.Attributes;

namespace Auslink.Web.Controllers
{
    public class InvestorsController : Controller
    {
        public ActionResult Prospective()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/sustainable-buildings.png";
            page.RedLogoText = "Sustainable Buildings";
            page.HeaderImageUrl = "/Content/Images/header/investors-prospective.jpg";

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
            page.RedLogoImageUrl = "/Content/Images/header/low-management-fees.png";
            page.RedLogoText = "Low Management Fees";
            page.HeaderImageUrl = "/Content/Images/header/investors-unitholders.jpg";


            return View(page);
        }

    }
}
