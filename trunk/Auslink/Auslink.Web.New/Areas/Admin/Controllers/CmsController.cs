using Auslink.Cms.Models;
using Auslink.Cms.Services;
using Auslink.QuarterlyUpdates.Models;
using Auslink.QuarterlyUpdates.Services;
using Auslink.Web.New.Areas.Admin.Models.Cms;
using Auslink.Web.New.Areas.Admin.Models.QuarterlyUpdates;
using Auslink.Web.New.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    [AdminAttribute]
    public class CmsController : Controller
    {
        private IPageService _pageService;

        public CmsController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        public ActionResult Index()
        {
            return null;
        }

        public ActionResult ViewPage(Guid pageId, bool? published)
        {
            Page page = this._pageService.GetPageById(pageId);

            PageViewModel viewModel = new PageViewModel(page);

            ViewBag.Published = published;

            return this.View("ViewPage", viewModel);
        }

        public ActionResult EditPageContent(Guid pageId, Guid contentId)
        {
            Page page = this._pageService.GetPageById(pageId);

            EditPageContentViewModel viewModel = new EditPageContentViewModel(page, contentId);

            return this.View("EditPageContent", viewModel);
        }

        public ActionResult SavePageContent(PageContentViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                Page page = this._pageService.GetPageById(viewModel.PageId);
                PageContent content = page.Content.First(o => o.ContentId == viewModel.ContentId);

                content.Html = viewModel.Html;

                this._pageService.SavePageContent(content);

                return this.RedirectToRoute(AdminRoutes.Cms.ViewPage);
            }

            return this.EditPageContent(viewModel.PageId, viewModel.ContentId);
        }

        public ActionResult PublishPageContent(Guid pageId, Guid contentId)
        {
            this._pageService.PublishPageContent(pageId, contentId);

            return this.RedirectToRoute(AdminRoutes.Cms.ViewPage, new { published = true });
        }
    }
}