using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Websites.Interfaces;
using Portal.Web.Areas.CMS.Models;
using Portal.Cms.Models;
using Portal.Cms;

namespace Portal.Web.Areas.CMS.Controllers
{
    public class TemplateController : Controller
    {
        private IWebsite _website;
        private ICmsService _cmsService;

        public TemplateController(IWebsite website, ICmsService cmsService)
        {
            this._website = website;
            this._cmsService = cmsService;
        }

        public ActionResult Index()
        {
            TemplatesPageViewModel viewModel = new TemplatesPageViewModel(this._website, this._cmsService.GetTemplates());
            return View("Index", viewModel);
        }

        public ActionResult Add()
        {
            TemplatePageViewModel viewModel = new TemplatePageViewModel(this._website, new TemplateViewModel(new Template()));
            return View("Add", viewModel);
        }

        public ActionResult Edit(int templateId)
        {
            Template template = this._cmsService.GetTemplateById(templateId);
            TemplatePageViewModel viewModel = new TemplatePageViewModel(this._website, new TemplateViewModel(template));
            return View("Add", viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(TemplateViewModel templateViewModel)
        {
            if (this.ModelState.IsValid)
            {
                int? templateId = null;

                if (templateViewModel.Id != 0)
                {
                    templateId = templateViewModel.Id;
                }

                this._cmsService.SaveTemplate(templateId, templateViewModel.Name, templateViewModel.Html);

                return this.RedirectToRoute(CMSAreaRegistration.CmsTemplatesRouteUrl);
            }
            
            TemplatePageViewModel viewModel = new TemplatePageViewModel(this._website, templateViewModel);
            return View("Edit", viewModel);
        }
    }
}
