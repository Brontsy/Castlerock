using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Portal.Cms.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portal.Web.Areas.CMS.Models
{
    public class TemplateViewModel
    {
        private Template _template = null;

        private int _id;
        private string _name = string.Empty;
        private string _html = string.Empty;

        public TemplateViewModel()
        {
        }

        public TemplateViewModel(Template template)
        {
            this._id = template.Id;
            this._name = template.Name;
            this._html = template.Html;

            this._template = template;
        }

        /// <summary>
        /// Gets the id of this template
        /// </summary>
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// Gets the name of this template
        /// </summary>
        [Required(ErrorMessage = "* Please enter a name")]
        [DisplayName("Name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Gets html for this template
        /// </summary>
        [Required(ErrorMessage = "* Please enter the html for the template")]
        [DisplayName("Html")]
        public string Html
        {
            get { return this._html; }
            set { this._html = value; }
        }

        /// <summary>
        /// Gets a list of all the locations this template has
        /// </summary>
        public IList<string> Locations
        {
            get { return this._template.Locations; }
        }

        /// <summary>
        /// Gets the url key for this template
        /// </summary>
        public string Key
        {
            get { return this.Name.ToUrl(); }
        }
    }
}