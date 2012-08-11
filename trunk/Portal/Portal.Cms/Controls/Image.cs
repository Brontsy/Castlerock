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
    public class Image : Control
    {
        private string _name = "Image";

        public Image() { }

        [Required(ErrorMessage = "* Please give the image a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/Image"; }
        }

        /// <summary>
        /// Gets the source for this image
        /// </summary>
        [Required(ErrorMessage = "* Please give the source of this image")]
        [DisplayName("Image Src")]
        public virtual string ImageUrl { get; set; }

        /// <summary>
        /// Gets the css class for this image
        /// </summary>
        [DisplayName("Css Class")]
        public virtual string CssClass { get; set; }
    }
}
