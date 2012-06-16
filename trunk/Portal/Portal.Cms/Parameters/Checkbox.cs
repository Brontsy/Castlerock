using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using System.Collections.Specialized;

namespace Portal.Cms.Parameters
{
    public class Checkbox : Parameter
    {
        private bool _selected = false;

        public Checkbox(string label, string key, bool selected)
            : base(label, key, string.Empty, false)
        {
            this._selected = selected;
        }

        /// <summary>
        /// The value this parameter has. This can be used to populate
        /// the form with default values etc.
        /// </summary>
        public override string Value
        {
            get { return string.Empty; }
            set 
            {
                if (!bool.TryParse(value.Substring(0, 4), out this._selected))
                {
                    this._selected = false;
                }
            }
        }

        public bool Selected
        {
            get { return this._selected; }
            set { this._selected = value; }
        }


        public override string View
        {
            get { return "Parameters/Checkbox"; }
        }

        public override void SetFormValue(NameValueCollection postedValues)
        {
            this.Value = postedValues[this.Key];

            if (!this.Selected && this.IsRequired)
            {
                this.Message = string.Format("Please enter agree to {0}", this.Label);
                this.IsValid = false;
            }
        }
    }
}
