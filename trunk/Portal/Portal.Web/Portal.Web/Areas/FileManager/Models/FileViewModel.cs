using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.FileManager.Models;

namespace Portal.Web.Areas.FileManager.Models
{
    public class FileViewModel : IStorageItemViewModel
    {
        
        private File _file = null;

        public FileViewModel(File file)
        {
            this._file = file;
        }

        /// <summary>
        /// Gets the name of the view to render this storage item
        /// </summary>
        public string View 
        { 
            get { return "File"; } 
        }

        /// <summary>
        /// Gets all the route values to navigate to this file
        /// </summary>
        public object RouteValues
        {
            get { return new { storageItemId = string.Format("{0}{1}", this._file.Path, this._file.Name), path = this.PathForUrl }; }
        }

        /// <summary>
        /// Gets the name of the file
        /// </summary>
        public string Name
        {
            get { return this._file.Name; }
        }

        /// <summary>
        /// Gets a friendly url version of the path. We basically replace all the '/' with a '-'
        /// </summary>
        private string PathForUrl
        {
            get
            {
                if (string.IsNullOrEmpty(this._file.Path))
                {
                    return this._file.Name;
                }

                return string.Format("{0}{1}", this._file.Path, this._file.Name).Replace("/", "-");
            }
        }

        /// <summary>
        /// Gets the url to this file
        /// </summary>
        public string Url
        {
            get { return this._file.Uri.ToString(); }
        }

        /// <summary>
        /// Gets the file extension of this file jpg, gif, png etc
        /// </summary>
        public string FileExtension
        {
            get
            {
                string[] fileParts = this._file.Uri.Segments[this._file.Uri.Segments.Length - 1].Split('.');

                return fileParts[fileParts.Length - 1];
            }
        }
    }
}