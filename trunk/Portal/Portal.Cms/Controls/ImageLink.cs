using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;

namespace Portal.Cms.Controls
{
    public class ImageLink : Control
    {
        private IList<IParameter> _parameters = null;

        public ImageLink() { }

        public override string ControlsName
        {
            get { return "Image with a link"; }
        }

        public virtual string ImageUrl
        {
            get { return this.DataItems.Get<string>("ImageUrl"); }
            set { this.DataItems["ImageUrl"] = value; }
        }

        public virtual string Url
        {
            get { return this.DataItems.Get<string>("Url"); }
            set { this.DataItems["Url"] = value; }
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
                    this._parameters.Add(new Textbox("Url", "navigation_url", this.Url, true));
                    this._parameters.Add(new Textbox("Image Url", "image_url", this.ImageUrl, true));
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
                this.Url = this.Parameters.Get("navigation_url").Value;
                this.ImageUrl = this.Parameters.Get("image_url").Value;

                return true;
            }

            return false;
        }


    }
}
