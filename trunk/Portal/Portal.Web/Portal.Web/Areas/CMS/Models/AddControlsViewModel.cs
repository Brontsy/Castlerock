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
    public class AddControlsViewModel : Portal.Web.Models.PageViewModel
    {
        private IList<IPage> _pages;
        private IControl _control = null;
        private string _location = null;

        private IList<IControl> _controlsFromOtherPages = null;

        private IList<IControl> _controlsCanBeAdded;

        public AddControlsViewModel(IWebsite website, IList<IPage> pages, IControl control, string location, IList<IControl> controls)
            : base(website)
        {
            this._pages = pages;
            this._control = control;
            this._location = location;

            if (string.IsNullOrEmpty(this._location))
            {
                this._location = control.Location;
            }

            this._controlsCanBeAdded = controls;
        }

        public IControl Control
        {
            get { return this._control; }
        }

        public string Location
        {
            get { return this._location; }
        }

        /// <summary>
        /// Gets a list of all the controls that the user might add that already exist on another page
        /// </summary>
        public IList<IControl> ControlsFromOtherPages
        {
            get
            {
                if(this._controlsFromOtherPages == null)
                {
                    this._controlsFromOtherPages = new List<IControl>();

                    foreach(IPage page in this._pages)
                    {
                        this.AddControls(page.Controls);
                    }
                }

                return this._controlsFromOtherPages;
            }
        }

        private void AddControls(IList<IControl> controls)
        {
            foreach (IControl control in controls)
            {
                this._controlsFromOtherPages.Add(control);

                if (control.Controls.Count > 0)
                {
                    this.AddControls(control.Controls);
                }
            }
        }

        public IList<IControl> AddedableControls
        {
            get
            {
                return this._controlsCanBeAdded;
                IList<IControl> controls = new List<IControl>();

                var allTypes = typeof(IControl).Assembly.GetTypes();
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                IList<Type> allowableTypes = new List<Type>();

                foreach (var assembly in assemblies)
                {
                    foreach (var actualyType in allTypes)
                    {
                        if (typeof(Control).IsAssignableFrom(actualyType) && !actualyType.IsInterface && !actualyType.IsAbstract)
                        {
                            allowableTypes.Add(actualyType);
                        }
                    }
                }

                foreach (var type in allowableTypes)
                {
                    IControl control = Activator.CreateInstance(type) as IControl;

                    controls.Add(control);
                }

                return controls;
            }
        }
    }
}