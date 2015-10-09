using Auslink.Web.New.Areas.Admin.Models.Login;
using Auslink.Web.New.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private ILoginProvider _loginProvider;

        public LoginController(ILoginProvider loginProvider)
        {
            this._loginProvider = loginProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel();

            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (this._loginProvider.Login(viewModel.Username, viewModel.Password, false).Successful)
                    {
                        FormsAuthentication.SetAuthCookie(viewModel.Username, false);
                        return this.RedirectToRoute(AdminRoutes.Home);
                    }
                    else
                    {
                        this.ModelState.AddModelError("Username", "Invalid username or password, please try again");
                    }
                }
                catch (Exception exception)
                {
                    this.ModelState.AddModelError("Username", "There was a problem logging you in. Please try again." + exception.Message);
                }
            }

            return this.Index();
        }
    }
}