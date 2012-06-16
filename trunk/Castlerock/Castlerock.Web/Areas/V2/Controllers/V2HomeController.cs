using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;
using Castlerock.Web.Controllers;


namespace Castlerock.Web.Areas.V2.Controllers
{
    [HandleError]
    public class V2HomeController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "Home";
            model.Title = "Castlerock Property";
            model.SelectedNavigation = "Home";

            return View("Index", model);
        }
    }
}
