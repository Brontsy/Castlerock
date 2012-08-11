using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Portal.Cms.Extensions;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;

namespace Portal.Cms.Controls
{
    public class Html : Control
    {
        private string _name = "Html";

        public Html() { }

        [Required(ErrorMessage = "* Please enter the contents of this html control")]
        [DisplayName("Content")]
        public virtual string Content { get; set; }

        /// <summary>
        /// Returns the name of this control
        /// </summary>
        [Required(ErrorMessage = "* Please give the html a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/Html"; }
        }
    }
}
