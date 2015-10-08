using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;
using Auslink.Web.New.Attributes;

namespace Auslink.Web.New.Controllers
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
