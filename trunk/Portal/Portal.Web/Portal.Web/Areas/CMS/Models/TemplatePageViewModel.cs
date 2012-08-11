using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Portal.Cms.Models;

namespace Portal.Web.Areas.CMS.Models
{
    public class TemplatePageViewModel : Portal.Web.Models.PageViewModel
    {
        private TemplateViewModel _template = null;

        public TemplatePageViewModel(IWebsite website, TemplateViewModel template)
            : base(website)
        {
            this._template = template;
        }

        public TemplateViewModel Template
        {
            get { return this._template; }
        }
    }
}