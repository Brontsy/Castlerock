using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;
using Auslink.Web.Attributes;

namespace Auslink.Web.Controllers
{
    public class HomeController : Controller
    {
        [ImportModelStateFromTempData]
        public ActionResult Index()
        {
            return View("Index", new PageViewModel());
        }

    }
}
