using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;

namespace Castlerock.Web.New.Controllers
{
    public class DisclaimerController : CastlerockController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Disclaimer";

            return View("Index");
        }
    }
}
