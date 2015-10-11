using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auslink.FileManager.Interfaces;
using Auslink.FileManager.Enums;

namespace Auslink.FileManager.Models
{
    public class StorageItem : IStorageItem
    {
        protected StorageItemType _storageItemType;

        private int _id;
        private string _domain = null;
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


        public StorageItem(StorageItemType type, string domain, Uri url)//string scheme, string host, string path, string name)
        {
            this._domain = domain;
            this._scheme = url.Scheme;
            this._host = url.Host + "/" + url.Segments[1];

            string localPath = url.LocalPath;

            if (localPath.EndsWith("/"))
            {
                localPath = localPath.Substring(0, localPath.Length - 1);
            }

            var segments = localPath.Split('/');

            this._name = segments[segments.Length - 1];
            for (int i = 2; i < segments.Length - 1; i++) { this._path += segments[i] + "/"; }

            if (type == StorageItemType.Folder)
            {
                //this._name = this._name.Substring(0, this._name.Length - 1);
            }

            //return new Folder(website, uri.Scheme, host, path, fileName.Substring(0, fileName.Length - 1));



            //string fileName = uri.Segments[uri.Segments.Length - 1];
            //for (int i = 0; i < 2; i++) { host += uri.Segments[i]; }
            //for (int i = 2; i < uri.Segments.Length - 1; i++) { path += uri.Segments[i]; }


            //this._path = path;
            //this._name = name;

            if (!string.IsNullOrEmpty(this._path))
            {
                string[] parents = this._path.Split('/');

                string parentPath = string.Empty;
                if (parents.Length >= 2)
                {
                    string parentFileName = parents[parents.Length - 2];
                    for (int i = 0; i < parents.Length - 2; i++) { parentPath += parents[i]; }

                    this.Parent = new Folder(this._domain, new Uri(this._scheme + "://" + this._host + this._path));
                }
            }
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
        public string Domain
        {
            get { return this._domain; }
            internal set { this._domain = value; }
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
