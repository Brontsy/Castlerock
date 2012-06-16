using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;


namespace Castlerock.Web.Controllers
{
    [HandleError]
    public class HomeController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "Home";
            model.Title = "Castlerock Property";
            model.SelectedNavigation = "Home";

            return View("StandardPageLayout", model);
        }
    }
}
