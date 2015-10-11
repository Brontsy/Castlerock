using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;
using Auslink.Web.New.Attributes;
using Auslink.Cms.Services;
using Auslink.Cms.Models;

namespace Auslink.Web.New.Controllers
{
    public class HomeController : Controller
    {
        private IPageService _pageService;

        public HomeController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        [ImportModelStateFromTempData]
        public ActionResult Index()
        {
            Page page = this._pageService.GetPageByName("home");

            ViewBag.Html = page.Content.First(o => o.IsPublished).Html;

            return View("Index", new PageViewModel());
        }

    }
}
