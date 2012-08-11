using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.FileManager.Interfaces;
using Portal.Websites.Interfaces;
using Portal.FileManager.Enums;

namespace Portal.FileManager.Models
{
    public class StorageItem : IStorageItem
    {
        protected StorageItemType _storageItemType;

        private int _id;
        private IWebsite _website = null;
        private string _scheme;
        private string _host;
        private string _path;
        private string _name;
        private Uri _uri = null;
        private string _type = null;

        private IList<IStorageItem> _children = null;
        private IStorageItem _parent = null;

        public StorageItem()
        {
        }

        public StorageItem(StorageItemType type)
        {
            this._storageItemType = type;
        }


        public StorageItem(StorageItemType type, IWebsite website, string scheme, string host, string path, string name)
        {
            this._website = website;
            this._scheme = scheme;
            this._host = host;
            this._path = path;
            this._name = name;
        }


        /// <summary>
        /// Gets the id of this file in our database
        /// </summary>
        public int Id
        {
            get { return this._id; }
            internal set { this._id = value; }
        }

        /// <summary>
        /// Gets the website that this file belongs to
        /// </summary>
        public IWebsite Website
        {
            get { return this._website; }
            internal set { this._website = value; }
        }

        /// <summary>
        /// Gets a list of all the children for this storage item (files and folders)
        /// </summary>
        public IList<IStorageItem> Children
        {
            get { return this._children; }
            internal set { this._children = value; }
        }

        /// <summary>
        /// Gets the parent of this storage item (like a folder)
        /// </summary>
        public IStorageItem Parent
        {
            get { return this._parent; }
            internal set { this._parent = value; }
        }

        /// <summary>
        /// Gets the scheme of this file http or https
        /// </summary>
        public string Scheme
        {
            get { return this._scheme; }
            internal set { this._scheme = value; }
        }

        /// <summary>
        /// Gets the host of this file www.castlerockproeprty.com.au etc
        /// </summary>
        public string Host
        {
            get { return this._host; }
            internal set { this._host = value; }
        }

        /// <summary>
        /// Gets the path to the location of this file
        /// </summary>
        public string Path
        {
            get { return this._path; }
            internal set { this._path = value; }
        }

        /// <summary>
        /// Gets the name of the storage iten
        /// </summary>
        public string Name
        {
            get { return this._name; }
            internal set { this._name = value; }
        }

        /// <summary>
        /// Gets the type of file this is image, pdf etc
        /// </summary>
        public string Type
        {
            get { return this._type; }
            internal set { this._type = value; }
        }

        /// <summary>
        /// Gets the url to access this storage item
        /// </summary>
        public Uri Uri
        {
            get
            {
                if (this._uri == null)
                {
                    this._uri = new Uri(this.Scheme + "://" + this.Host + this.Path + this.Name);
                }

                return this._uri;
            }
        }
    }
}
