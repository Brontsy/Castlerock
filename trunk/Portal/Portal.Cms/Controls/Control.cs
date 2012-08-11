using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;
using System.Xml.Serialization;
using Portal.Cms.Pages;
using Portal.Interfaces.Cms;

namespace Portal.Cms.Controls
{
    public abstract class Control : IControl
    {
        private IList<IControl> _controls = new List<IControl>();

        public Control()
        {
            this.DisplayOrder = 1;
        }



        /// <summary>
        /// Gets and sets a list of child controls this control might have
        /// </summary>
        public virtual IList<IControl> Controls
        {
            get { return this._controls; }
            set { this._controls = value; }
        }

        /// <summary>
        /// Gets the id of the control
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the display order for this control
        /// </summary>
        public virtual int DisplayOrder { get; internal set; }
        /// <summary>
        /// Gets the name of this control
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// Gets the name of the view to render the control
        /// </summary>
        public abstract string View { get; }

        /// <summary>
        /// Gets and sets the location inside the template this control should sit
        /// </summary>
        public string Location { get; set; }
    }
}
