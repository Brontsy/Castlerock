using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;
using System.Web.Security;

namespace Castlerock.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return this.RedirectToRoute("Member-Downloads");
            }

            return View("Index", new Login());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                if (ServiceLocator.GetMembershipService().AuthenticateEmail(login.Email, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.Email, false);
                    return this.RedirectToRoute("Member-Downloads");
                }
                else
                {
                    this.ModelState.AddModelError("Email", "Invalid username or password, please try again");
                }
            }

            return View("Index", login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
