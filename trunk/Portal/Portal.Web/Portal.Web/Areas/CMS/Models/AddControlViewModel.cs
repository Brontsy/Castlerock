using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Portal.Cms.Controls;
using Portal.Interfaces.Cms;

namespace Portal.Web.Areas.CMS.Models
{
    public class AddControlViewModel : Portal.Web.Models.PageViewModel
    {
        private IControl _control = null;
        private IControl _parentControl = null;
        private string _location = null;

        private IList<IControl> _controlsFromOtherPages = null;

        public AddControlViewModel(IWebsite website, IControl control, IControl parentControl, string location)
            : base(website)
        {
            this._control = control;
            this._parentControl = parentControl;
            this._location = location;

            if (string.IsNullOrEmpty(this._location))
            {
                this._location = parentControl.Location;
            }
        }

        public IControl Control
        {
            get { return this._control; }
        }

        public IControl ParentControl
        {
            get { return this._parentControl; }
        }

        public string Location
        {
            get { return this._location; }
        }
    }
}