using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Portal.Cms.Extensions;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;

namespace Portal.Cms.Controls
{
    public class Link : Control
    {
        private string _name = "Link";

        public Link() { }

        [DisplayName("Alternate Text")]
        public virtual string AlternateText { get; set; }

        [Required(ErrorMessage = "* Please enter the url for this link")]
        [DisplayName("Url")]
        public virtual string Url { get; set; }

        [Required(ErrorMessage = "* Please enter the text for this link")]
        [DisplayName("Text")]
        public virtual string Text { get; set; } 

 
        /// <summary>
        /// Returns the name of this control
        /// </summary>
        [Required(ErrorMessage = "* Please give the link a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/Link"; }
        }
    }
}
