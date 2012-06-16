using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Web.Models;
using Portal.Cms.Interfaces;
using Portal.Websites.Interfaces;

namespace Portal.Web.Areas.CMS.Models
{
    public class CmsPagesViewModel : Portal.Web.Models.PageViewModel
    {
        private IList<PageViewModel> _pages = null;

        public CmsPagesViewModel(IWebsite website, IList<IPage> pages)
            : base(website)
        {
            this._pages = pages.Select(o => new PageViewModel(o)).ToList();
        }

        public IList<PageViewModel> Pages
        {
            get { return this._pages; }
        }
    }
}