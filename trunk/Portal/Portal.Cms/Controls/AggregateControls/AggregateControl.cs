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
    public class AggregateControl : Control, IAggregateControl
    {
        private IList<IParameter> _parameters = null;

        public AggregateControl() { }

        /// <summary>
        /// Gets the text to render to the page for adding a control
        /// eg "add image"
        /// </summary>
        public virtual string AddControlsName
        {
            get { return "Add Control"; }
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
                    this._parameters.Add(new Textbox("Name", "name", this.Name, true));
                }

                return this._parameters;
            }
        }

        /// <summary>
        /// Gets a list of all the allowable control types this aggregate control can have as children
        /// </summary>
        public virtual List<Type> TypesAllowableAsChildren
        {
            get { return new List<Type>() { typeof(Control) }; }
        }

        public override string ControlsName
        {
            get { return "Control Group"; }
        }

        public override bool Update(NameValueCollection parameters)
        {
            if (this.IsValid(parameters))
            {
                this.Name = this.Parameters.Get<Textbox>("name").Value;
                return true;
            }

            return false;
        }
    }
}
