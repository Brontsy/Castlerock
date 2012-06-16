using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class PropertyPortfolioController : Controller
    {
        public ActionResult AllProperties()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/property-development.png";
            page.RedLogoText = "Property Development";
            page.HeaderImageUrl = "/Content/Images/header/property-portfolio-01.jpg";

            return View(page);
        }

        public ActionResult Property(string propertyName)
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "/Content/Images/header/property-location-diversification.png";
            page.RedLogoText = "Property Location Diversification";
            page.HeaderImageUrl = "/Content/Images/header/property-portfolio-02.jpg";

            return View(propertyName, page);
        }

    }
}
