using Auslink.Cms.Models;
using Auslink.Cms.Services;
using Auslink.QuarterlyUpdates.Models;
using Auslink.QuarterlyUpdates.Services;
using Auslink.Web.New.Areas.Admin.Models.Cms;
using Auslink.Web.New.Areas.Admin.Models.QuarterlyUpdates;
using Auslink.Web.New.Attributes;
using Auslink.Web.New.Providers;
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
        private IMemberProvider _memberProvider;

        public CmsController(IPageService pageService, IMemberProvider memberProvider)
        {
            this._pageService = pageService;
            this._memberProvider = memberProvider;
        }

        public ActionResult Index()
        {
            var pages = this._pageService.GetPages();

            var viewModel = pages.Select(o => new PageViewModel(o));

            return this.View("Index", viewModel);
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

                this._pageService.SavePageContent(content, this._memberProvider.GetLoggedInMember().Name);

                return this.RedirectToRoute(AdminRoutes.Cms.Page.View);
            }

            return this.EditPageContent(viewModel.PageId, viewModel.ContentId);
        }

        public ActionResult PublishPageContent(Guid pageId, Guid contentId)
        {
            this._pageService.PublishPageContent(pageId, contentId, this._memberProvider.GetLoggedInMember().Name);

            return this.RedirectToRoute(AdminRoutes.Cms.Page.View, new { published = true });
        }


        public ActionResult AddPage()
        {
            EditPageViewModel viewModel = new EditPageViewModel();

            return this.View("AddPage", viewModel);
        }

        public ActionResult EditPage(Guid pageId)
        {
            Page page = this._pageService.GetPageById(pageId);
            EditPageViewModel viewModel = new EditPageViewModel(page);

            return this.View("EditPage", viewModel);
        }

        public ActionResult SavePage(EditPageViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this._pageService.SavePage(viewModel.PageId, viewModel.Name, this._memberProvider.GetLoggedInMember().Name);
            }

            return this.EditPage(viewModel.PageId);
        }
    }
}