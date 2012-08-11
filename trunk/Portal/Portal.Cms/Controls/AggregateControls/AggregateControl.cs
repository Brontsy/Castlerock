using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Portal.Cms.Extensions;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;

namespace Portal.Cms.Controls
{
    public class AggregateControl : Control, IAggregateControl
    {
        private string _name = "Control Group";

        public AggregateControl() { }

        public override string View
        {
            get { return "Controls/AggregateControls/AuslinkHeader"; }
        }

        /// <summary>
        /// Gets a list of all the allowable control types this aggregate control can have as children
        /// </summary>
        [JsonIgnoreAttribute]
        public virtual List<Type> TypesAllowableAsChildren
        {
            get { return new List<Type>() { typeof(Control) }; }
        }

        [Required(ErrorMessage = "* Please give the control group a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
