using System;
using System.Text;
using Portal.Cms.Interfaces;

namespace Portal.Cms.Parameters
{
    public class Image : Textbox
    {
        public Image(string label, string key, string value, bool isRequired)
            : base (label, key, value, isRequired)
        {
        }
    }
}
