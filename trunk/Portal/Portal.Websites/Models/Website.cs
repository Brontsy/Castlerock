using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Interfaces;

namespace Portal.Websites.Models
{
    public class Website : IWebsite
    {
        private int _id;
        private string _name = string.Empty;
        private string _domain = string.Empty;
        private string _url = string.Empty;
        private string _portalUrl = string.Empty;
        private string _host = string.Empty;
        private string _logoImageUrl = string.Empty;
        private IList<Component> _components = new List<Component>();

        /// <summary>
        /// Gets and sets the id of the website
        /// </summary>
        public int Id
        {
            get { return this._id; }
            internal set { this._id = value; }
        }

        /// <summary>
        /// Gets and sets the name of the website
        /// </summary>
        public string Name
        {
            get { return this._name; }
            internal set { this._name = value; }
        }

        /// <summary>
        /// Gets and sets the domain of the website
        /// </summary>
        public string Domain
        {
            get { return this._domain; }
            internal set { this._domain = value; }
        }

        /// <summary>
        /// Gets and sets the url for this website
        /// </summary>
        public string Url
        {
            get { return this._url; }
            internal set { this._url = value; }
        }

        /// <summary>
        /// Gets and sets the url for the portal website
        /// </summary>
        public string PortalUrl
        {
            get { return this._portalUrl; }
            internal set { this._portalUrl = value; }
        }

        /// <summary>
        /// Gets and sets the url for the portal website
        /// </summary>
        public string Host
        {
            get { return this._host; }
            internal set { this._host = value; }
        }

        /// <summary>
        /// Gets the url for this websites logo
        /// </summary>
        public string LogoImageUrl
        {
            get { return this._logoImageUrl; }
            internal set { this._logoImageUrl = value; }
        }

        /// <summary>
        /// Gets and Sets a list of all the components this website has installed.
        /// Things like CMS, Membership Etc
        /// </summary>
        public IList<Component> Components
        {
            get { return this._components; }
            internal set { this._components = value; }
        }
    }
}
