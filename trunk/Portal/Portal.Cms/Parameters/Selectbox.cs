using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using System.Collections.Specialized;

namespace Portal.Cms.Parameters
{
    public class Selectbox : Parameter
    {
        private Dictionary<string, string> _values = new Dictionary<string, string>();

        public Selectbox(string label, string key, Dictionary<string, string> values, string selectedValue, bool isRequired)
            : base(label, key, selectedValue, isRequired)
        {
            this._values = values;
        }

        /// <summary>
        /// A list of string to populate the drop down box
        /// </summary>
        public Dictionary<string, string> Values
        {
            get { return this._values; }
            set { this._values = value; }
        }

        public override string View
        {
            get { return "Parameters/Selectbox"; }
        }

        public override void SetFormValue(NameValueCollection postedValues)
        {
            this.Value = postedValues[this.Key];

            if (this.IsRequired && string.IsNullOrEmpty(this.Value))
            {
                this.Message = string.Format("Please enter a {0}", this.Label);
                this.IsValid = false;
            }
        }
    }
}
