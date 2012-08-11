using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Interfaces.Cms
{
    public interface IControl
    {
        Guid Id { get; set; }

        /// <summary>
        /// Gets the name of the control that is stored in the databse
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the location that this control is to be rendered on the page
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets the name of hte view to render this control
        /// </summary>
        string View { get; }

        /// <summary>
        /// Gets the display order of this control
        /// </summary>
        int DisplayOrder { get; }

        /// <summary>
        /// Gets a list of all the child controls this control might have
        /// </summary>
        IList<IControl> Controls { get; }
    }
}
