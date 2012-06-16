using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Portal.Cms.Extensions;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;

namespace Portal.Cms.Controls
{
    public class Layout : AggregateControl
    {
        private IList<IParameter> _parameters = null;

        public Layout() { }

        public override string View
        {
            get { return "Controls/AggregateControls/Layout"; }
        }

        public override string ControlsName
        {
            get { return "Layout"; }
        }

        public virtual string CssClass
        {
            get { return this.DataItems.Get<string>("CssClass"); }
            set { this.DataItems["CssClass"] = value; }
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
                    this._parameters.Add(new Textbox("Css Class", "css_class", this.CssClass, true));
                }

                return this._parameters;
            }
        }

        /// <summary>
        /// Gets a list of all the allowable control types this aggregate control can have as children
        /// </summary>
        public override List<Type> TypesAllowableAsChildren
        {
            get
            {
                return new List<Type>() { typeof(Column) };
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
                this.CssClass = this.Parameters.Get<Textbox>("css_class").Value;
                return true;
            }

            return false;
        }
    }
}
