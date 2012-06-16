using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class MembersController : InvestorsController
    {
        [Authorize]
        public override ActionResult CurrentUnitholders()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/low-management-fees.png";
            page.RedLogoText = "Low Management Fees";
            page.HeaderImageUrl = "/Content/Images/header/investors-unitholders.jpg";

            return View(page);
        }

        public ActionResult Login(string username, string password)
        {
            return this.RedirectToAction("Index", "Home");
        }
    }
}
