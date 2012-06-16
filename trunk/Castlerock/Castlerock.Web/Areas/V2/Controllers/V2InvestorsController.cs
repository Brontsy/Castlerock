using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;
using Castlerock.Web.Controllers;


namespace Castlerock.Web.Areas.V2.Controllers
{
    public class V2InvestorsController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "Investors";
            model.Title = "Investors";
            model.SelectedNavigation = "Investors";

            return View("Index", model);
        }
    }
}