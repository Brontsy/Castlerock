using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;

namespace Portal.Cms.Controls
{
    public class Heading : Control
    {
        private IList<IParameter> _parameters = null;

 
        public override string ControlsName
        {
            get { return "Heading"; }
        }

        public virtual string Size
        {
            get { return this.HtmlProperties.Get<string>("size"); }
            set { this.HtmlProperties["size"] = value; }
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

                    Dictionary<string,string> sizes = new Dictionary<string,string>();
                    sizes.Add("h1", "h1");
                    sizes.Add("h2", "h2");
                    sizes.Add("h3", "h3");
                    sizes.Add("h4", "h4");
                    sizes.Add("h5", "h5");

                    this._parameters.Add(new Selectbox("Size", "size", sizes, this.Size, true));
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
                this.Size = this.Parameters.Get<Selectbox>("size").Value;

                return true;
            }

            return false;
        }


    }
}
