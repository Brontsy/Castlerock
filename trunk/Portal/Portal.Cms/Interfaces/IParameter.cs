using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Portal.Cms.Interfaces
{
    public interface IParameter
    {
        /// <summary>
        /// The label for the parameter. ie the friendly name
        /// to render next to the parameter when it is displayed
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// The key (id) that this parameter will have when it is
        /// displayed on the page
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// The value this parameter has. This can be used to populate
        /// the form with default values etc.
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Is this paramter valid or not
        /// </summary>
        bool IsValid { get; set; }

        /// <summary>
        /// Gets and sets a message to be displayed alongside the parameter
        /// if its invalid
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets the name of the view (ascx file) to render the paramater
        /// </summary>
        string View { get; }

        /// <summary>
        /// Is this paramater required or not
        /// </summary>
        bool IsRequired { get; }

        void SetFormValue(NameValueCollection postedValues);
    }
}
