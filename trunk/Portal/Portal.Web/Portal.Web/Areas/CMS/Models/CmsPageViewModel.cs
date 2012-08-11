using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Portal.Cms.Controls;
using Portal.Cms.Models;
using Portal.Interfaces.Cms;

namespace Portal.Web.Areas.CMS.Models
{
    public class CmsPageViewModel : Portal.Web.Models.PageViewModel
    {
        private Portal.Web.Areas.CMS.Models.PageViewModel _page = null;
        private IList<Template> _templates = null;

        public CmsPageViewModel(IWebsite website, IPage page)
            : base(website)
        {
            this._page = new Portal.Web.Areas.CMS.Models.PageViewModel(page);
        }

        public CmsPageViewModel(IWebsite website, IList<Template> templates)
            : base(website)
        {
            this._page = new Portal.Web.Areas.CMS.Models.PageViewModel(templates);
            this._templates = templates;
        }

        public CmsPageViewModel(IWebsite website, PageViewModel pageViewModel, IList<Template> templates)
            : base(website)
        {
            this._page = pageViewModel;
            pageViewModel.AddTemplates(templates);
        }

        public PageViewModel Page
        {
            get { return this._page; }
        }

        public IList<TemplateViewModel> Templates
        {
            get { return this._templates.Select(o => new TemplateViewModel(o)).ToList(); }
        }

        public IList<IControl> AddedableControls
        {
            get
            {
                IList<IControl> controls = new List<IControl>();

                var allTypes = typeof(Control).Assembly.GetTypes();
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                IList<Type> allowableTypes = new List<Type>();

                foreach (var actualyType in allTypes)
                {
                    if (typeof(Control).IsAssignableFrom(actualyType) && !actualyType.IsInterface && !actualyType.IsAbstract)
                    {
                        allowableTypes.Add(actualyType);
                    }
                }

                foreach (var type in allowableTypes)
                {
                    IControl control = Activator.CreateInstance(type) as IControl;

                    controls.Add(control);
                }

                return controls;
            }
        }
    }
}