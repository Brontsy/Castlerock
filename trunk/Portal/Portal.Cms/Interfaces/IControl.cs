using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Portal.Cms.Interfaces
{
    public interface IControl
    {
        int Id { get; }

        /// <summary>
        /// Gets the name of the control that is stored in the databse
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the name of the control to render in the cms editor when
        /// adding controls to a page
        /// </summary>
        string ControlsName { get; }

        /// <summary>
        /// Gets the name of hte view to render this control
        /// </summary>
        string View { get; }

        int DisplayOrder { get; set; }


        IControl ParentControl { get; set; }

        IList<IControl> Controls { get; set; }

        IList<IPage> Pages { get; set; }

        IList<IParameter> Parameters { get; }


        /// <summary>
        /// Updates this data source using the request object from the http request.
        /// This way we have access to all the values that was posted up
        /// </summary>
        /// <param name="request"></param>
        /// <returns>True if the control was updated, false if it wasnt (i.e there was a validation issue)</returns>
        bool Update(NameValueCollection parameters);

        /// <summary>
        /// Does this control already exist on the page?
        /// This will check through each parent control as well, to make sure that the parent
        /// doesnt also already exist
        /// </summary>
        bool AlreadyExistsOnPage(int pageId);
        
        /// <summary>
        /// Returns a list of all the pages including all the pages the parent control
        /// exists on
        /// </summary>
        IList<IPage> GetAllPages(IList<IPage> pages);
    }
}
