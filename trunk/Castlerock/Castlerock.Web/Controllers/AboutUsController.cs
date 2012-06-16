using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;

namespace Castlerock.Web.Controllers
{
    public class AboutUsController : CastlerockController
    {

        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "AboutUs";
            model.Title = "About Us";
            model.SelectedNavigation = "AboutUs";

            return View("StandardPageLayout", model);
        }
    }
}
