using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;

namespace Portal.Cms.Controls
{
    public class Link : Control
    {
        private IList<IParameter> _parameters = null;

        public Link() { }

        public virtual string AlternateText
        {
            get { return this.HtmlProperties.Get<string>("alt"); }
            set { this.HtmlProperties["alt"] = value; }
        }

        public virtual string Url
        {
            get { return this.HtmlProperties.Get<string>("href"); }
            set { this.HtmlProperties["href"] = value; }
        }

        public virtual string Text
        {
            get { return this.HtmlProperties.Get<string>("text"); }
            set { this.HtmlProperties["text"] = value; }
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


                    this._parameters.Add(new Textbox("Text", "text", this.Text, true));
                    this._parameters.Add(new Textbox("Alternate Text", "alternate_text", this.AlternateText, true));
                    this._parameters.Add(new Textbox("Url", "navigation_url", this.Url, true));
                }

                return this._parameters;
            }
        }

        /// <summary>
        /// Returns the name of this control
        /// </summary>
        public override string ControlsName
        {
            get { return "Link"; }
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
                this.Text = this.Parameters.Get("text").Value;
                this.AlternateText = this.Parameters.Get("alternate_text").Value;
                this.Url = this.Parameters.Get("navigation_url").Value;

                return true;
            }

            return false;
        }


    }
}
