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
    public class Column : AggregateControl
    {
        private IList<IParameter> _parameters = null;

        public Column() { }

        public override string View
        {
            get { return "Controls/AggregateControls/Column"; }
        }

        public override string ControlsName
        {
            get { return "Column"; }
        }

        public virtual string Width
        {
            get { return this.DataItems.Get<string>("Width"); }
            set { this.DataItems["Width"] = value; }
        }

        public virtual string Alignment
        {
            get { return this.DataItems.Get<string>("Alignment"); }
            set { this.DataItems["Alignment"] = value; }
        }

        public virtual string Margin
        {
            get { return this.DataItems.Get<string>("Margin"); }
            set { this.DataItems["Margin"] = value; }
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


                    this._parameters.Add(new Textbox("Width", "width", this.Width, true));
                    this._parameters.Add(new Textbox("Alignment", "alignment", this.Alignment, true));
                    this._parameters.Add(new Textbox("Margin", "margin", this.Margin, true));
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
                return new List<Type>() { typeof(Control) };
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
                this.Width = this.Parameters.Get<Textbox>("width").Value;
                this.Alignment = this.Parameters.Get<Textbox>("alignment").Value;
                this.Margin = this.Parameters.Get<Textbox>("margin").Value;

                return true;
            }

            return false;
        }
    }
}
