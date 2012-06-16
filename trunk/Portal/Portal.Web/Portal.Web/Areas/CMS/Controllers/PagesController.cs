using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Web.Controllers;
using Portal.Websites.Interfaces;
using Portal.Web.Models;
using Portal.Cms;
using Portal.Web.Areas.CMS.Models;
using Portal.Cms.Interfaces;

namespace Portal.Web.Areas.CMS.Controllers
{
    public class PagesController : PortalBaseController
    {
        private ICmsService _cmsService = null;

        public PagesController(IWebsite website, ICmsService cmsService)
            : base(website)
        {
            this._cmsService = cmsService;
        }

        public ActionResult Index()
        {
            CmsPagesViewModel viewModel = new CmsPagesViewModel(this.Website, this._cmsService.GetPages(this.Website));

            return View("Index", viewModel);
        }

        public ActionResult Page(int pageId)
        {
            IPage page = this._cmsService.GetPageById(pageId);

            return View("Page", new CmsPageViewModel(this.Website, page));
        }
    }
}
