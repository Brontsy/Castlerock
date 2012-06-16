using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Websites.Interfaces;

namespace Portal.Cms.Pages
{
    public class Page : IPage
    {
        private int _id;
        public int _websiteId;
        private string _name;
        private string _url;
        private string _key;
        private IWebsite _website = null;

        private IList<IControl> _controls = new List<IControl>();

        public IList<IControl> Controls
        {
            get { return this._controls; }
            set { this._controls = value; }
        }

        /// <summary>
        /// Gets and sets the id of this page
        /// </summary>
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// Gets and sets the id of the website that this page belongs to
        /// </summary>
        public int WebsiteId
        {
            get { return this._websiteId; }
            set { this._websiteId = value; }
        }

        /// <summary>
        /// Gets and sets the name of this page
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Gets the key for this page to be used in the url
        /// /Page/{key}/{pageId}
        /// </summary>
        public string Key
        {
            get 
            {
                if (string.IsNullOrEmpty(this._key))
                {
                    this._key = this.Name.Replace(" ", "-");
                }

                return this._key; 
            }
            set { this._key = value; }
        }

        /// <summary>
        /// Gets and sets the matching url for this page
        /// </summary>
        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        
        /// <summary>
        /// Gets the website that this page belongs to
        /// </summary>
        public IWebsite Website
        {
            get { return this._website; }
            set { this._website = value; }
        }

        /// <summary>
        /// Checks to see if a control already on the page has the same unique identifier
        /// </summary>
        public virtual bool ControlExistsOnPage(int controlId)
        {
            return this.ControlExistsOnPage(this.Controls, controlId);
        }

        private bool ControlExistsOnPage(IList<IControl> controls, int controlId)
        {
            foreach (IControl control in controls)
            {
                if (control.Controls.Count > 0)
                {
                    if (this.ControlExistsOnPage(control.Controls, controlId))
                    {
                        return true;
                    }
                }

                if (control.Id == controlId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
