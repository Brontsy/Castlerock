using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;
using System.Web.Security;
using Castlerock.Web.New.Providers;
using Castlerock.Web.New.Attributes;

namespace Castlerock.Web.New.Controllers
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
            return View("Login", new Login());
        }

        [AcceptVerbs(HttpVerbs.Post), ExportModelStateToTempData]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (this._loginProvider.Login(login.Email, login.Password, false).Successful)
                    {
                        FormsAuthentication.SetAuthCookie(login.Email, false);
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

            return this.RedirectToRoute("Home");
        }

        public ActionResult Logout()
        {
            this._loginProvider.Logout();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
