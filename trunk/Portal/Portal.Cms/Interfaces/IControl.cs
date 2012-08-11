using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Portal.Cms.Events;
using Portal.Cms.Pages;

namespace Portal.Cms.Interfaces
{
    public interface IControl12
    {
        Guid Id { get; }

        /// <summary>
        /// Gets the name of the control that is stored in the databse
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the location that this control is to be rendered on the page
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the name of hte view to render this control
        /// </summary>
        string View { get; }

        int DisplayOrder { get; }


        IList<IControl> Controls { get; }

        //IList<IParameter> Parameters { get; }


        /// <summary>
        /// Updates this data source using the request object from the http request.
        /// This way we have access to all the values that was posted up
        /// </summary>
        /// <param name="request"></param>
        /// <returns>True if the control was updated, false if it wasnt (i.e there was a validation issue)</returns>
        //bool Update(NameValueCollection parameters);

        //event IEvent PropertySetChanged;
        //declare the event using the delegate
        event Notify Notify;


        void EventRaised(EventArgs e);
    }
}
