using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;
using Auslink.Cms.Services;
using Auslink.Cms.Models;

namespace Auslink.Web.New.Controllers
{
    public class AboutController : Controller
    {
        private IPageService _pageService;
        public AboutController(IPageService pageService)
        {
            this._pageService = pageService;
        }


        public ActionResult Overview()
        {
            Page page = this._pageService.GetPageByName("overview");

            ViewBag.Html = page.Content.First(o => o.IsPublished).Html;

            PageViewModel viewModel = new PageViewModel();
            viewModel.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/low-entry-costs.png";
            viewModel.RedLogoText = "Low Entry Costs";
            viewModel.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/about-key-features.jpg";

            return View("Overview", viewModel);
        }

        public ActionResult KeyFeatures()
        {
            Page page = this._pageService.GetPageByName("Key Features");

            ViewBag.Html = page.Content.First(o => o.IsPublished).Html;

            PageViewModel viewModel = new PageViewModel();
            viewModel.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/low-entry-costs.png";
            viewModel.RedLogoText = "Low Entry Costs";
            viewModel.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/about-key-features.jpg";

            return View("KeyFeatures", viewModel);
        }

    }
}