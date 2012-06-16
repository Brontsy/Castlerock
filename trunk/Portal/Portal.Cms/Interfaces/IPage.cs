using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms.Pages;

namespace Portal.Cms.Interfaces
{
    public interface IPage
    {
        /// <summary>
        /// Gest the Id of the page
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets and sets the name of the page
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the key for this page to be used in the url
        /// /Page/{key}/{pageId}
        /// </summary>
        string Key { get; }

        IList<IControl> Controls { get; }

        /// <summary>
        /// Checks to see if a control already on the page has the same unique identifier
        /// </summary>
        bool ControlExistsOnPage(int controlId);
    }
}
