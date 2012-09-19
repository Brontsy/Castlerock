using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.FileManager.Models;

namespace Portal.Web.Areas.FileManager.Models
{
    public class FolderViewModel : IStorageItemViewModel
    {
        private Folder _folder = null;

        public FolderViewModel(Folder folder)
        {
            this._folder = folder;
        }

        /// <summary>
        /// Gets the name of the view to render this storage item
        /// </summary>
        public string View
        {
            get { return "Folder"; }
        }

        /// <summary>
        /// Gets all the route values to navigate to this folder
        /// </summary>
        public object RouteValues
        {
            get { return new { storageItemId = this.Path, path = this.PathForUrl }; }
        }

        /// <summary>
        /// Gets the name of the folder
        /// </summary>
        public string Name
        {
            get { return this._folder.Name; }
        }

        /// <summary>
        /// Gets a friendly url version of the path. We basically replace all the '/' with a '-'
        /// </summary>
        private string PathForUrl
        {
            get
            {
                if (string.IsNullOrEmpty(this._folder.Path))
                {
                    return this._folder.Name;
                }

                return string.Format("{0}{1}", this._folder.Path, this._folder.Name).Replace("/", "-");
            }
        }

        private string Path
        {
            get
            {
                if (string.IsNullOrEmpty(this._folder.Path))
                {
                    return this._folder.Name;
                }

                return string.Format("{0}{1}", this._folder.Path, this._folder.Name);
            }
        }

    }
}