using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;

namespace Castlerock.Web.New.Controllers
{
    public class InvestorsController : CastlerockController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Investors";
            ViewBag.SelectedNavigation = "Investors";

            return View("Index");
        }
    }
}