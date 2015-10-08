using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;

namespace Auslink.Web.New.Controllers
{
    public class PropertyPortfolioController : Controller
    {
        public ActionResult AllProperties()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/property-development.png";
            page.RedLogoText = "Property Development";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/property-portfolio-01.jpg";

            return View(page);
        }

        public ActionResult Property(string propertyName)
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/property-location-diversification.png";
            page.RedLogoText = "Property Location Diversification";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/property-portfolio-02.jpg";

            return View(propertyName, page);
        }

    }
}
