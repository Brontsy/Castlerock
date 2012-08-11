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
    public class NavigationControl : Control, IAggregateControl
    {
        private string _name = "Navigation";

        public NavigationControl() { }

        public override string View
        {
            get { return "Controls/AggregateControls/Navigation"; }
        }

        /// <summary>
        /// Returns the name of this control
        /// </summary>
        [Required(ErrorMessage = "* Please give the navigation a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
