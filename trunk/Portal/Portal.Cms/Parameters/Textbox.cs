using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using System.Collections.Specialized;

namespace Portal.Cms.Parameters
{
    public class Textbox : Parameter
    {
        public Textbox(string label, string key, string value, bool isRequired)
            : base (label, key, value, isRequired)
        {
        }


        public override string View
        {
            get { return "Parameters/Textbox"; }
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
