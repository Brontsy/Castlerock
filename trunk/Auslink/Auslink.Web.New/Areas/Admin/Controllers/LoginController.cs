using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {

        }


        public ActionResult Index()
        {
            return View();
        }
    }
}