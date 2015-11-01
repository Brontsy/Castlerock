using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;
using Auslink.Cms.Models;
using Auslink.Cms.Services;

namespace Auslink.Web.New.Controllers
{
    public class FinancialsController : Controller
    {
        private IPageService _pageService;

        public FinancialsController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        public ActionResult Returns()
        {
            Page page = this._pageService.GetPageByName("returns");

            ViewBag.Html = page.Content.First(o => o.IsPublished).Html;


            PageViewModel viewModel = new PageViewModel();
            viewModel.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/tax-advantage-income.png";
            viewModel.RedLogoText = "Tax Advantage Income";
            viewModel.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/financials.jpg";

            return View(viewModel);
        }

        public ActionResult FundSummary()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/stable-income.png";
            page.RedLogoText = "Stable Income";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/financials.jpg";

            return View(page);
        }

    }
}
