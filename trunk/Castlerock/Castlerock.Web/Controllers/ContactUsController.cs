using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;

namespace Castlerock.Web.Controllers
{
    public class ContactUsController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "ContactUs";
            model.Title = "Contact Us";

            return View("StandardPageLayout", model);
        }
    }
}
