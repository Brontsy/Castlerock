using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;


namespace Castlerock.Web.New.Controllers
{
    [HandleError]
    public class HomeController : CastlerockController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Castlerock Property";
            ViewBag.SelectedNavigation = "Home";

            return View("Index");
        }
    }
}
