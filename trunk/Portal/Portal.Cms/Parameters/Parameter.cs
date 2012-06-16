using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms.Interfaces;
using System.Collections.Specialized;

namespace Portal.Cms.Parameters
{
    public abstract class Parameter : IParameter
    {
        protected string _label = string.Empty;
        protected string _key = string.Empty;
        protected string _value = string.Empty;
        protected bool _isValid = true;
        protected string _message = string.Empty;
        protected bool _isRequired = false;
        
        public Parameter(string label, string key, string value, bool isRequired)
        {
            this._label = label;
            this._key = key;
            this._value = value;
            this._isRequired = isRequired;
        }

        /// <summary>
        /// Get the name of the view to render this parameter
        /// </summary>
        public abstract string View { get; }

        public abstract void SetFormValue(NameValueCollection postedValues);

        public bool IsValid
        {
            get { return this._isValid; }
            set { this._isValid = value; }
        }

        /// <summary>
        /// Gets the label to render for this textbox
        /// </summary>
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }

        /// <summary>
        /// The key (id) that this parameter will have when it is
        /// displayed on the page
        /// </summary>
        public string Key 
        {
            get { return this._key; }
            set { this._key = value; }
        }

        /// <summary>
        /// The value this parameter has. This can be used to populate
        /// the form with default values etc.
        /// </summary>
        public virtual string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        /// <summary>
        /// Gets and sets a message to be displayed alongside the parameter
        /// if its invalid
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set 
            {
                // we only want to set the message if nothing has already been set.
                // This will make sure no validation messages overwrite any previously set messages
                if (this._message == string.Empty)
                {
                    this._message = value;
                }
            }
        }

        /// <summary>
        /// Is this parameter a required one or not.
        /// </summary>
        public bool IsRequired
        {
            get { return this._isRequired; }
            set { this._isRequired = value; }
        }

        public string CssClass
        {
            get
            {
                string cssClass = string.Empty;

                if (!this.IsValid)
                {
                    cssClass = "error";
                }

                if (this.IsRequired)
                {
                    cssClass += " required";
                }

                return string.Format(" class=\"{0}\"", cssClass);//.Replace(" ", string.Empty);
            }
        }
    }
}
