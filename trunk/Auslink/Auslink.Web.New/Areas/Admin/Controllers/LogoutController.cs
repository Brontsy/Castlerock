using Auslink.Web.New.Areas.Admin.Models.Login;
using Auslink.Web.New.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        private ILoginProvider _loginProvider;

        public LogoutController(ILoginProvider loginProvider)
        {
            this._loginProvider = loginProvider;
        }

        public ActionResult Index()
        {
            this._loginProvider.Logout();

            return this.RedirectToAction("Index", "Home");
        }
    }
}