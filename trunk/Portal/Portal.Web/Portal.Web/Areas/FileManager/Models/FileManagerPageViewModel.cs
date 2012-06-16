using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Microsoft.WindowsAzure.StorageClient;
using Portal.Web.Areas.FileManager.Models;
using System.IO;
using Microsoft.WindowsAzure;
using Portal.FileManager.Interfaces;

namespace Portal.Web.Areas.FileManager.Models
{
    public class FileManagerPageViewModel : PageViewModel
    {
        private string _path;

        public FileManagerPageViewModel(IWebsite website, IList<IStorageItem> storageItems, string path)
            : base(website)
        {
            this._path = path == null ? string.Empty : path;

            this.Files = storageItems.Select(o => new StorageItemViewModel(o)).ToList();
        }

        public string Path
        {
            get { return this._path; }
        }

        public IList<StorageItemViewModel> Files
        {
            get;
            private set;
        }

        public string ParentPath
        {
            get
            {
                string[] segments = this._path.ToString().Split('/');

                if (segments.Length > 1)
                {
                    return segments[segments.Length - 2];
                }

                return string.Empty;
            }
        }
    }
}