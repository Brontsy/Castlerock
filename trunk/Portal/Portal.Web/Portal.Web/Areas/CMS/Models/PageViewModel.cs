using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using System.Web.Mvc;
using Portal.Cms.Models;
using Portal.Interfaces.Cms;

namespace Portal.Web.Areas.CMS.Models
{
    public class PageViewModel
    {
        private IPage _page = null;
        private IList<IControl> _controls = null;

        private string _name;
        private string _template;
        private int _templateId;

        private IList<Template> _templates;

        public PageViewModel()
        {
        }

        public PageViewModel(IPage page)
        {
            this._page = page;
            this.Name = page.Name;
            this.Id = page.Id;
            this._controls = page.Controls;
        }

        public PageViewModel(IList<Template> templates)
        {
            this._templates = templates;
        }

        /// <summary>
        /// Gets the id of this page
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name of the page
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the url of the page
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a url friendly version of the name. Replaces the spaces with dashes etc
        /// </summary>
        public string NameUrlFriendly
        {
            get { return this._page.Name.ToUrl(); }
        }

        /// <summary>
        /// Gets all the child controls of this control
        /// </summary>
        public IList<IControl> Controls
        {
            get { return this._controls; }
        }

        public int TemplateId
        {
            get;
            set;
        }

        public TemplateViewModel Template
        {
            get { return new TemplateViewModel(this._page.Template); }
        }

        public SelectList Templates
        {
            get
            {
                return new SelectList(this._templates, "Id", "Name");
            }
        }

        public void AddTemplates(IList<Template> templates)
        {
            this._templates = templates;
        }
    }
}