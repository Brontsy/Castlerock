using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Websites.Models
{
    public class Component
    {
        private int _id;
        private string _name;
        private string _url;
        private string _area;

        /// <summary>
        /// Gets and Sets the Id of this component
        /// </summary>
        public int Id
        {
            get { return this._id; }
            internal set { this._id = value; }
        }

        /// <summary>
        /// Gets and sets the name of this component
        /// </summary>
        public string Name
        {
            get { return this._name; }
            internal set { this._name = value; }
        }

        /// <summary>
        /// Gets and Sets the url to access this component
        /// </summary>
        public string Url
        {
            get { return this._url; }
            internal set { this._url = value; }
        }

        /// <summary>
        /// Gets and Sets the area this component is. Membership, CMS etc
        /// TODO: Maybe change this to an enum
        /// </summary>
        public string Area
        {
            get { return this._area; }
            internal set { this._area = value; }
        }
    }
}
