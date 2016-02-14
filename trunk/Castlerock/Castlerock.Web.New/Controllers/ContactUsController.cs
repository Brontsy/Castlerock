using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;

namespace Castlerock.Web.New.Controllers
{
    public class ContactUsController : CastlerockController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Contact Us";

            return View("Index");
        }
    }
}
