using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;

namespace Auslink.Web.New.Controllers
{
    public class FinancialsController : Controller
    {
        public ActionResult Returns()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/tax-advantage-income.png";
            page.RedLogoText = "Tax Advantage Income";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/financials.jpg";

            return View(page);
        }

        public ActionResult FundSummary()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/stable-income.png";
            page.RedLogoText = "Stable Income";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/financials.jpg";

            return View(page);
        }

    }
}
