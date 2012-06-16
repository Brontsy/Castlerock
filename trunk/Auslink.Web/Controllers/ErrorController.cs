using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/attractive-yields.png";
            page.RedLogoText = "Attractive Yields";
            page.HeaderImageUrl = "/Content/Images/header/contact-us.jpg";

            return View("404", page);
        }

        public ActionResult Unknown()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/attractive-yields.png";
            page.RedLogoText = "Attractive Yields";
            page.HeaderImageUrl = "/Content/Images/header/contact-us.jpg";

            return View("500", page);
        }
    }
}
