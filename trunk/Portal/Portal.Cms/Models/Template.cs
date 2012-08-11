using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Websites.Interfaces;
using Newtonsoft.Json;

namespace Portal.Cms.Models
{
    public class Template
    {
        public int _id;
        public string _name;
        public string _html;
        private string _locationsJson;

        public IList<IPage> _pages;
        public IWebsite _website;
        private IList<string> _locations = null;

        /// <summary>
        /// Gets and sets the id of this template
        /// </summary>
        public int Id
        {
            get { return this._id; }
            internal set { this._id = value; }
        }

        /// <summary>
        /// Gets and sets the name of this template
        /// </summary>
        public string Name
        {
            get { return this._name; }
            internal set { this._name = value; }
        }

        /// <summary>
        /// Gets and sets all the locations a control can be places inside this template
        /// </summary>
        public IList<string> Locations
        {
            get 
            {
                if (this._locations == null)
                {
                    try
                    {
                        this._locations = JsonConvert.DeserializeObject<List<string>>(this._locationsJson);
                    }
                    catch (Exception exception)
                    {
                        this._locations = new List<string>();
                    }
                }

                if (this._locations == null)
                {
                    this._locations = new List<string>();
                }

                return this._locations; 
            }
        }

        public string LocationsJson
        {
            get { return this._locationsJson; }
            internal set { this._locationsJson = value; }
        }

        /// <summary>
        /// Gets and sets the html of this template
        /// </summary>
        public string Html
        {
            get { return this._html; }
            internal set { this._html = value; }
        }

        /// <summary>
        /// Gets and sets all the pages that use this template
        /// </summary>
        public IList<IPage> Pages
        {
            get { return this._pages; }
            internal set { this._pages = value; }
        }

        /// <summary>
        /// Gets and sets the website that this template belongs to
        /// </summary>
        public IWebsite Website
        {
            get { return this._website; }
            internal set { this._website = value; }
        }
    }
}
