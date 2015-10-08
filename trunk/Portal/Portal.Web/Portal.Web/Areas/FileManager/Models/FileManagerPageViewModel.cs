using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Portal.Web.Areas.FileManager.Models;
using Portal.FileManager.Interfaces;
using Portal.FileManager.Models;

namespace Portal.Web.Areas.FileManager.Models
{
    public class FileManagerPageViewModel : PageViewModel
    {
        private IList<IStorageItem> _childStorageItems = null;
        private IList<IStorageItemViewModel> _storageItems = null;
        private IStorageItem _currentStorageItem = null;

        public FileManagerPageViewModel(IWebsite website, IStorageItem currentStorageItem, IList<IStorageItem> childStorageItems)
            : base(website)
        {
            this._childStorageItems = childStorageItems.OrderBy(o => o.Uri.ToString()).ToList();
            this._currentStorageItem = currentStorageItem;
        }

        /// <summary>
        /// Gets a list of all the storage items to render on the page
        /// </summary>
        public IList<IStorageItemViewModel> StorageItems
        {
            get
            {
                if (this._storageItems == null)
                {
                    this._storageItems = new List<IStorageItemViewModel>();

                    foreach (IStorageItem item in this._childStorageItems)
                    {
                        if (item.GetType() == typeof(Folder))
                        {
                            this._storageItems.Add(new FolderViewModel(item as Folder));
                        }
                    }

                    foreach (IStorageItem item in this._childStorageItems)
                    {
                        if (item.GetType() == typeof(File))
                        {
                            this._storageItems.Add(new FileViewModel(item as File));
                        }
                    }
                }

                return this._storageItems;
            }
        }

        /// <summary>
        /// Gets the current route values for the current stroage item / folder
        /// </summary>
        public object CurrentStorageItemRouteValues
        {
            get
            {
                //return new FolderViewModel(new Folder(null, HttpContext.Current.Request.Url)).RouteValues;
                var request = HttpContext.Current.Request;
                return new { path = request.Params["storageItemId"] };
            }
        }

        public string CurrentPath
        {
            get
            {
                var request = HttpContext.Current.Request;
                return request.Params["storageItemId"];
            }
        }

        /// <summary>
        /// Gets all the route values for the parent of the current storage item if there is one
        /// </summary>
        public object ParentFoldersRouteValues
        {
            get 
            {
                if (this._childStorageItems.Any())
                {
                    var item = this._childStorageItems.First().Parent;

                    if (item != null)
                    {
                        string path = (item.Path == null ? null : item.Path.Replace("/", "-"));
                        return new { path = path, storageItemId = item.Path };
                    }
                }

                if (this._currentStorageItem != null && this._currentStorageItem.Parent != null)
                {
                    return new FolderViewModel(this._currentStorageItem.Parent as Folder).RouteValues;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the name of the route to use when creating a new folder
        /// </summary>
        public string NewFolderRouteName
        {
            get { return "FileManager-New-Root-Folder"; }
        }

        /// <summary>
        /// Gets the id of the current storage item. It can be null because you might be at teh root level
        /// </summary>
        public int? CurrentStorageItemId
        {
            get
            {
                if (this._currentStorageItem != null)
                {
                    return this._currentStorageItem.Id;
                }

                return null;
            }
        }
    }
}