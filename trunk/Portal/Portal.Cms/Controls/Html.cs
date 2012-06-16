using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;

namespace Portal.Cms.Controls
{
    public class Html : Control
    {
        private IList<IParameter> _parameters = null;

        public Html() { }

        public virtual string HtmlContent
        {
            get { return this.DataItems.Get<string>("Html"); }
            set { this.DataItems["Html"] = value; }
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


                    this._parameters.Add(new Textarea("HTML", "html", this.HtmlContent, true));
                }

                return this._parameters;
            }
        }

        /// <summary>
        /// Returns the name of this control
        /// </summary>
        public override string ControlsName
        {
            get { return "Html"; }
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
                if (this.IsValidHtml())
                {
                    this.HtmlContent = this.Parameters.Get<Textarea>("html").Value;

                    return true;
                }
                else
                {
                    this.Parameters.Get<Textarea>("html").IsValid = false;
                    this.Parameters.Get<Textarea>("html").Message = "You have entered invalid HTML. Please try again";
                }
            }

            return false;
        }

        private bool IsValidHtml()
        {
            //HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            //htmlDoc.LoadHtml(this.Parameters.Get<Textarea>("html").Value);

            //return htmlDoc.ParseErrors.Count() == 0;

            return true;
        }
    }
}
