using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using System.Collections.Specialized;

namespace Portal.Cms.Parameters
{
    public class DatePicker : Parameter
    {
        private DateTime? _date = null;

        public DatePicker(string label, string key, DateTime value, bool isRequired)
            : base(label, key, value.ToString("d MMMM yyyy"), isRequired)
        {
        }

        /// <summary>
        /// The value this parameter has. This can be used to populate
        /// the form with default values etc.
        /// </summary>
        public override string Value
        {
            get 
            {
                if (this.Date.HasValue)
                {
                    return this.Date.Value.ToLongDateString();
                }

                return this._value;
            }
            set { this._value = value; }
        }

        public override string View
        {
            get { return "Parameters/DatePicker"; }
        }

        public DateTime? Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public override void SetFormValue(NameValueCollection postedValues)
        {
            bool isValid = true;
            this.Value = postedValues[this.Key];

            if (string.IsNullOrEmpty(this.Value))
            {
                isValid = false;
                this.Message = string.Format("Please enter a {0}", this.Label);
            }

            DateTime dateTime;
            if (!DateTime.TryParse(this.Value, out dateTime))
            {
                isValid = false;
                this.Message = string.Format("Please enter a valid {0}", this.Label);
            }
            else
            {
                this.Date = dateTime;
            }

            if (this.IsRequired)
            {
                this.IsValid = isValid;
            }
        }
    }
}
