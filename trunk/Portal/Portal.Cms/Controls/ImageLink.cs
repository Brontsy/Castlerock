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
    public class ImageLink : Control
    {
        private string _name = "Image with a link";

        public ImageLink() { }

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

        /// <summary>
        /// Gets the name of the view to render this image link
        /// </summary>
        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/ImageLink"; }
        }

        [Required(ErrorMessage = "* Please enter the source of the image")]
        [DisplayName("Image Src")]
        public virtual string ImageUrl { get; set; }

        [Required(ErrorMessage = "* Please enter the url for this link")]
        [DisplayName("Url")]
        public virtual string Url { get; set; }
    }
}
