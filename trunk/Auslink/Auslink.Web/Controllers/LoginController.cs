using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Auslink.Web.Models;
using Auslink.Web.Attributes;
using Portal.Membership;

namespace Auslink.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
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
                    if (ServiceLocator.GetMembershipService().Authenticate(login.Username, login.Password))
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
            FormsAuthentication.SignOut();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
