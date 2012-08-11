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
    public class InternalLink : Control
    {
        private string _name = "Internal Link";
        private int pageId;

        public InternalLink() { }

        [Required(ErrorMessage = "* Please enter the alternate text for the  internal link")]
        [DisplayName("Alternate Text")]
        public virtual string AlternateText { get; set; }

        public virtual string Url { get; set; }

        [Required(ErrorMessage = "* Please enter the alternate text for the")]
        [DisplayName("Text")]
        public virtual string Text { get; set; }

        public virtual int PageId { get; set; }


        /// <summary>
        /// Returns the name of this control
        /// </summary>
        [Required(ErrorMessage = "* Please give the internal link a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/InternalLink"; }
        }
    }
}
