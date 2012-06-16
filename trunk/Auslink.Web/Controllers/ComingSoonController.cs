using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.Models;

namespace Auslink.Web.Controllers
{
    public class ComingSoonController : Controller
    {
        public ActionResult Index()
        {
            PageViewModel page = new PageViewModel();
            return View(page);
        }
    }
}