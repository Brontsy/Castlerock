using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Auslink.Web.New.Models;
using Auslink.Web.New.Attributes;
using Auslink.Membership.Services;
using Auslink.Web.New.Providers;
using Auslink.Web.New.Areas.Admin;

namespace Auslink.Web.New.Controllers
{
    public class LoginController : Controller
    {
        private ILoginProvider _loginProvider;

        public LoginController(ILoginProvider loginProvider)
        {
            this._loginProvider = loginProvider;
        }

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            if(returnUrl == "/admin")
            {
                return this.RedirectToRoute(AdminRoutes.Login);
            }

            return View("Login", new Login());
        }
        
        [AcceptVerbs(HttpVerbs.Post), ExportModelStateToTempData]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (this._loginProvider.Login(login.Username, login.Password, false).Successful)
                    {
                        FormsAuthentication.SetAuthCookie(login.Username, false);
                        return this.RedirectToRoute("Investors-Current-Unitholders-Members");
                    }
                    else
                    {
                        this.ModelState.AddModelError("Email", "Invalid username or password, please try again");
                    }
                }
                catch (Exception exception)
                {
                    this.ModelState.AddModelError("Email", "There was a problem logging you in. Please try again." + exception.Message);
                }
            }

            if (login.LoginLocation == LoginLocation.Home)
            {
                return this.RedirectToRoute("Home");

            }
            else
            {
                return this.RedirectToRoute("Investors-Current-Unitholders");
            }
        }

        public ActionResult Logout()
        {
            this._loginProvider.Logout();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
