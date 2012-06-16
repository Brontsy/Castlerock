using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;

namespace Portal.Cms.Controls
{
    public class Image : Control
    {
        private IList<IParameter> _parameters = null;

        public Image() 
        {
        }

        public override string ControlsName
        {
            get { return "Image"; }
        }

        /// <summary>
        /// Gets the source for this image
        /// </summary>
        public virtual string ImageSrc
        {
            get { return this.HtmlProperties.Get<string>("src"); }
            set { this.HtmlProperties["src"] = value; }
        }

        /// <summary>
        /// Gets the css class for this image
        /// </summary>
        public virtual string CssClass
        {
            get { return this.HtmlProperties.Get<string>("class"); }
            set { this.HtmlProperties["class"] = value; }
        }

        /// <summary>
        /// Collection of parameters to create and edit head 2 head items
        /// </summary>
        public override IList<IParameter> Parameters
        {
            get
            {
                if (this._parameters == null)
                {
                    this._parameters = new List<IParameter>();
                    this._parameters.Add(new Textbox("Image Url", "image_url", this.ImageSrc, true));
                }

                return this._parameters;
            }
        }

        /// <summary>
        /// Updates this data source using the request object from the http request.
        /// This way we have access to all the values that was posted up
        /// </summary>
        /// <param name="request"></param>
        /// <param name="valid">Is the form post up valid or not</param>
        public override bool Update(NameValueCollection parameters)
        {
            if (this.IsValid(parameters))
            {
                this.ImageSrc = this.Parameters.Get("image_url").Value;

                return true;
            }

            return false;
        }


    }
}
