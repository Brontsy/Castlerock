using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;

namespace Castlerock.Web.Controllers
{
    public class PrivacyPolicyController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "PrivacyPolicy";
            model.Title = "Privacy Policy";

            return View("StandardPageLayout", model);
        }
    }
}
