using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Cms.Interfaces
{
    public interface IAggregateControl
    {
        /// <summary>
        /// Gets the text to render to the page for adding a control
        /// eg "add image"
        /// </summary>
        string AddControlsName { get; }
    }
}
