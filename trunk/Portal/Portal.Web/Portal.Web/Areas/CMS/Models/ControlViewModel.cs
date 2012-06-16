using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;

namespace Portal.Web.Areas.CMS.Models
{
    public class ControlViewModel
    {
        private IControl _control = null;
        private IList<ControlViewModel> _controls = null;

        public ControlViewModel(IControl control)
        {
            this._control = control;
            this._controls = control.Controls.Select(o => new ControlViewModel(o)).ToList();
        }

        /// <summary>
        /// Gets the id of this page
        /// </summary>
        public string Id
        {
            get { return this._control.Id.ToString(); }
        }

        /// <summary>
        /// Gets the name of the page
        /// </summary>
        public string Name
        {
            get { return this._control.Name; }
        }

        /// <summary>
        /// Gets a url friendly version of the name. Replaces the spaces with dashes etc
        /// </summary>
        public string NameUrlFriendly
        {
            get { return this._control.Name.ToUrl(); }
        }

        /// <summary>
        /// Gets all the child controls of this control
        /// </summary>
        public IList<ControlViewModel> Controls
        {
            get { return this._controls; }
        }

        /// <summary>
        /// Gets the name of the view to render this control
        /// </summary>
        public string View
        {
            get { return this._control.View; }
        }
    }
}