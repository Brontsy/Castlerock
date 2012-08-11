using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Portal.Web.Controllers;
using Portal.Websites.Interfaces;
using Portal.Web.Models;
using Portal.Cms;
using Portal.Web.Areas.CMS.Models;
using Portal.Cms.Interfaces;
using Portal.Web.Attributes;
using Portal.Cms.Models;
using PageViewModel = Portal.Web.Areas.CMS.Models.PageViewModel;
using Portal.Cms.Controls;
using Portal.Web.Areas.CMS.ModelBinders;
using Portal.Interfaces.Cms;
using Portal.Cms.Extensions;

namespace Portal.Web.Areas.CMS.Controllers
{
    [AdministratorFilter]
    public class PagesController : PortalBaseController
    {
        private ICmsService _cmsService = null;
        private IList<IControl> _allControls = null;

        public PagesController(IWebsite website, ICmsService cmsService, IList<IControl> allControls)
            : base(website)
        {
            this._cmsService = cmsService;
            this._allControls = allControls;
        }

        public ActionResult Index()
        {
            CmsPagesViewModel viewModel = new CmsPagesViewModel(this.Website, this._cmsService.GetPages());

            return View("Index", viewModel);
        }

        public ActionResult Page(int pageId)
        {
            IPage page = this._cmsService.GetPageById(pageId);

            return View("Page", new CmsPageViewModel(this.Website, page));
        }

        public ActionResult New()
        {
            IList<Template> templates = this._cmsService.GetTemplates();

            return View("New", new CmsPageViewModel(this.Website, templates));
        }

        [HttpPost]
        public ActionResult Save(PageViewModel pageViewModel)
        {
            if (this.ModelState.IsValid)
            {                
                int? pageId = null;

                if (pageViewModel.Id != 0)
                {
                    pageId = pageViewModel.Id;
                }

                IPage page = this._cmsService.SavePage(pageId, pageViewModel.Name, pageViewModel.Url, pageViewModel.TemplateId);

                return this.RedirectToRoute(CMSAreaRegistration.CmsPageRouteUrl, new { pageId = page.Id, pageName = page.Key });
            }

            IList<Template> templates = this._cmsService.GetTemplates();

            return View("Edit", new CmsPageViewModel(this.Website, pageViewModel, templates));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveControl(int pageId, Guid? parentControlId, IControl control, string location)
        {
            if (this.ModelState.IsValid)
            {
                this._cmsService.AddControl(pageId, Request.Unvalidated().Form, parentControlId, control, location);

                if (parentControlId.HasValue)
                {
                    return this.RedirectToRoute(CMSAreaRegistration.CmsPageRouteUrl, new { pageId = pageId });
                }

                return this.RedirectToRoute(CMSAreaRegistration.CmsPageRouteUrl, new { pageId = pageId });
            }


            return this.AddControl(pageId, parentControlId, control, location);
        }

        public ActionResult AddControls(int pageId, Guid? parentControlId, string location)
        {
            IPage page = this._cmsService.GetPageById(pageId);

            IList<IPage> allPages = this._cmsService.GetPages();

            IControl control = null;
            if (parentControlId.HasValue)
            {
                control = page.Controls.Child(parentControlId.Value);
            }

            return View("AddControls", new AddControlsViewModel(this.Website, allPages, control, location, this._allControls));
        }


        public ActionResult AddControl(int pageId, Guid? parentControlId, IControl control, string location)
        {
            IPage page = this._cmsService.GetPageById(pageId);

            IControl parentControl = null;
            if (parentControlId.HasValue)
            {
                parentControl = page.Controls.Child(parentControlId.Value);
            }

            return View("AddControl", new AddControlViewModel(this.Website, control, parentControl, location));
        }


        public ActionResult AddExistingControl(int pageId, Guid controlId, Guid? parentControlId, string location)
        {
            this._cmsService.AddExistingControl(pageId, controlId, parentControlId, location);

            return this.RedirectToRoute(CMSAreaRegistration.CmsPageRouteUrl, new { pageId = pageId });
        }


        public ActionResult DeleteControl(int pageId, Guid controlId)
        {
            this._cmsService.DeleteControl(pageId, controlId);
            return this.RedirectToRoute(CMSAreaRegistration.CmsPageRouteUrl, new { pageId = pageId });
        }
    }
}
