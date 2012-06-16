using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult TrustManager()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/management-expertise.png";
            page.RedLogoText = "Management Expertise";
            page.HeaderImageUrl = "/Content/Images/header/management.jpg";

            return View(page);
        }

        public ActionResult PropertyManager()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/management-expertise.png";
            page.RedLogoText = "Management Expertise";
            page.HeaderImageUrl = "/Content/Images/header/management.jpg";

            return View(page);
        }

    }
}
