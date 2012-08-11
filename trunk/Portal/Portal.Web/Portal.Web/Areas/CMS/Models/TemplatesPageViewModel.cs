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
    public class TemplatesPageViewModel : Portal.Web.Models.PageViewModel
    {
        private IList<Template> _templates = null;

        public TemplatesPageViewModel(IWebsite website, IList<Template> templates)
            : base(website)
        {
            this._templates = templates;
        }

        public IList<TemplateViewModel> Templates
        {
            get { return this._templates.Select(o => new TemplateViewModel(o)).ToList(); }
        }
    }
}