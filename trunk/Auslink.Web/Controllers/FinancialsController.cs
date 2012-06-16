using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class FinancialsController : Controller
    {
        public ActionResult Returns()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/tax-advantage-income.png";
            page.RedLogoText = "Tax Advantage Income";
            page.HeaderImageUrl = "/Content/Images/header/financials.jpg";

            return View(page);
        }

        public ActionResult FundSummary()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/stable-income.png";
            page.RedLogoText = "Stable Income";
            page.HeaderImageUrl = "/Content/Images/header/financials.jpg";

            return View(page);
        }

    }
}
