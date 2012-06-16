using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Cms.Extensions;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace Portal.Cms.Controls
{
    public abstract class Control : IControl
    {
        private int _id = 0;
        private string _name = string.Empty;
        private int _displayOrder = 1;
        private string _view = string.Empty;

        private IControl _parentControl = null;
        private IList<IControl> _controls = new List<IControl>();
        private IList<IPage> _pages = new List<IPage>();
        private IList<IParameter> _parameters = null;

        private IDictionary<string, object> _dataItems = new Dictionary<string, object>();
        private IDictionary<string, object> _htmlProperties = new Dictionary<string, object>();

        public abstract string ControlsName { get; }


        /// <summary>
        /// Gets and sets a parent control for this control
        /// </summary>
        public virtual IDictionary<string, object> DataItems
        {
            get { return this._dataItems; }
            set { this._dataItems = value; }
        }

        public virtual IDictionary<string, object> HtmlProperties
        {
            get { return this._htmlProperties; }
            set { this._htmlProperties = value; }
        }

        /// <summary>
        /// Gets and sets a parent control for this control
        /// </summary>
        public virtual IControl ParentControl
        {
            get { return this._parentControl; }
            set { this._parentControl = value; }
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
        /// Gets and sets a list of pages this control belongs to
        /// </summary>
        public virtual IList<IPage> Pages
        {
            get { return this._pages; }
            set { this._pages = value; }
        }

        /// <summary>
        /// Gets the id of the control
        /// </summary>
        public virtual int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// Gets and sets the display order for this control
        /// </summary>
        public virtual int DisplayOrder
        {
            get { return this._displayOrder; }
            set { this._displayOrder = value; }
        }

        /// <summary>
        /// Gets the name of this control
        /// </summary>
        public virtual string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Gets the name of the view to render the control
        /// </summary>
        public virtual string View
        {
            get { return this._view; }
            set { this._view = value; }
        }

        /// <summary>
        /// Gets a list of parameters this control needs to edit and save itself
        /// </summary>
        public abstract IList<IParameter> Parameters { get;}

        /// <summary>
        /// Update / Save function to update a controls parameters. Using this we can then update
        /// internal proeprties to be ready to save
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual bool Update(NameValueCollection parameters)
        {
            if (this.IsValid(parameters))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks to see if the parameters are all valid or not
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual bool IsValid(NameValueCollection parameters)
        {
            // refresh the parameters
            this._parameters = this.Parameters.Update(parameters);

            // check to see if the paramaters are valid or not
            return this._parameters.IsValid();
        }

        /// <summary>
        /// Does this control already exist on the page?
        /// This will check through each parent control as well, to make sure that the parent
        /// doesnt also already exist
        /// </summary>
        public virtual bool AlreadyExistsOnPage(int pageId)
        {
            if (this.ParentControl != null)
            {
                if (this.ParentControl.AlreadyExistsOnPage(pageId))
                {
                    return true;
                }
            }

            if (this.Pages.ToList().Exists(o => o.Id == pageId))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a list of all the pages including all the pages the parent control
        /// exists on
        /// </summary>
        public virtual IList<IPage> GetAllPages(IList<IPage> pages)
        {
            if(this.ParentControl != null)
            {
                pages = this.ParentControl.GetAllPages(pages);
            }

            foreach(IPage page in this.Pages)
            {
                if(!pages.ToList().Exists(o => o.Id == page.Id))
                {
                    pages.Add(page);
                }
            }

            return pages;
        }
    }
}
