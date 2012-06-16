using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;

namespace Castlerock.Web.Controllers
{
    public class InvestorsController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "Investors";
            model.Title = "Investors";
            model.SelectedNavigation = "Investors";

            return View("StandardPageLayout", model);
        }
    }
}