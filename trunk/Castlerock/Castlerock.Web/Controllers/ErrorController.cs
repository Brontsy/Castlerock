using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;

namespace Castlerock.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Castlerock/Error/

        public ActionResult Show404()
        {
            return View("404", new PageViewModel());
        }


        public ActionResult Show500()
        {
            return View("500", new PageViewModel());
        }

    }
}
