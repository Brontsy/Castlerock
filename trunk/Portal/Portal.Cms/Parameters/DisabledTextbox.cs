using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Cms.Parameters
{
    public class DisabledTextbox : Textbox
    {
        public DisabledTextbox(string label, string key, string value)
            : base(label, key, value, false)
        {
            
        }

        public override string View
        {
            get
            {
                return "Parameters/DisabledTextbox";
            }
        }
    }
}
