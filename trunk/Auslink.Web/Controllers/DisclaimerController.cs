using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class DisclaimerController : Controller
    {
        public ActionResult Index()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/attractive-yields.png";
            page.RedLogoText = "Attractive Yields";
            page.HeaderImageUrl = "/Content/Images/header/contact-us.jpg";

            return View(page);
        }
    }
}
