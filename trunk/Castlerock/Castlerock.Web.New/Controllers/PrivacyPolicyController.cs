using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;

namespace Castlerock.Web.New.Controllers
{
    public class PrivacyPolicyController : CastlerockController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Privacy Policy";

            return View("Index");
        }
    }
}
