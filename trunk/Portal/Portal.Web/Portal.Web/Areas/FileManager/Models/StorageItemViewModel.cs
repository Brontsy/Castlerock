using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Portal.FileManager.Interfaces;
using Portal.FileManager.Models;

namespace Portal.Web.Areas.FileManager.Models
{
    public class StorageItemViewModel
    {
        private IStorageItem _storageItem = null;

        public StorageItemViewModel(IStorageItem storageItem)
        {
            this._storageItem = storageItem;
        }

        /// <summary>
        /// Gets the url to this file
        /// </summary>
        public string Url
        {
            get { return this._storageItem.Url.ToString(); }
        }

        public string Path
        {
            get 
            {
                string path = string.Empty;
                for(int i = 2; i < this._storageItem.Url.Segments.Length; i++)
                {
                    path += this._storageItem.Url.Segments[i];
                }

                return (path.EndsWith("/") ? path.Substring(0, path.Length - 1) : path);
            }
        }

        public string Name
        {
            get { return this._storageItem.Name; }
        }

        public string View
        {
            get { return (this._storageItem is Folder ? "Folder" : "File"); }
        }

        public string FileExtension
        {
            get
            {
                string[] fileParts = this._storageItem.Url.Segments[this._storageItem.Url.Segments.Length - 1].Split('.');

                return fileParts[1]+".jpg";
            }
        }
    }
}
