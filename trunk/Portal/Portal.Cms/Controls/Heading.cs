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
    public class Heading : Control
    {
        private string _name = "Heading";

        [Required(ErrorMessage = "* Please give the heading a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [Required(ErrorMessage = "* Please enter the text for the heading")]
        [DisplayName("Text")]
        public string Text { get; set; }

        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/Heading"; }
        }

        [Required(ErrorMessage = "* Please select the size you would like the heading to be")]
        [DisplayName("Size")]
        public virtual string Size { get; set; }
    }
}
