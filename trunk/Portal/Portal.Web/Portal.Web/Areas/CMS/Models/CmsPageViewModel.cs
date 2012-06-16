using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;

namespace Portal.Web.Areas.CMS.Models
{
    public class CmsPageViewModel : Portal.Web.Models.PageViewModel
    {
        private Portal.Web.Areas.CMS.Models.PageViewModel _page = null;

        public CmsPageViewModel(IWebsite website, IPage page)
            : base(website)
        {
            this._page = new Portal.Web.Areas.CMS.Models.PageViewModel(page);
        }

        public PageViewModel Page
        {
            get { return this._page; }
        }
    }
}