using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Interfaces;
using Portal.FileManager.Interfaces;
using System.IO;
using System.Web;
using System.Reflection;
using Portal.FileManager.Models;
using File = Portal.FileManager.Models.File;

namespace Portal.FileManager
{
    public class FileManagerService : IFileManagerService
    {
        private IFileStorage _fileStorage = null;
        private IWebsite _website = null;

        public FileManagerService(IWebsite website, IFileStorage fileStorage)
        {
            this._fileStorage = fileStorage;
            this._website = website;
        }

        /// <summary>
        /// Creates a new folder in the file manager
        /// </summary>
        /// <param name="website">the website that this folder belongs to</param>
        /// <param name="folderName">the name of the folder</param>
        /// <param name="path">the path relative to the root directory where the folder should be located</param>
        /// <returns>true if the folder was created</returns>
        public bool CreateFolder(string folderName, string path)
        {
            return this._fileStorage.CreateFolder(this._website, folderName, path);
        }

        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        public bool DeleteFolder(string path)
        {
            return this._fileStorage.DeleteFolder(this._website, path);
        }


        /// <summary>
        /// Deletes a file from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the file to be deleted</param>
        public bool DeleteFile(string path)
        {
            return this._fileStorage.DeleteFile(this._website, path);
        }

        /// <summary>
        /// Uploads a colletion of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the files to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        public IList<FileUploadResult> UploadFiles(HttpFileCollectionBase files, string path)
        {
            // Upload the image to the storage
            return this._fileStorage.UploadFiles(files, this._website, path);
            // TODO: save files into the database
        }

        /// <summary>
        /// Gets a list of all the storage items for a specific path
        /// </summary>
        /// <param name="path">the path to the storage items</param>
        public IList<IStorageItem> GetStorageItems(string path)
        {
            // make sure that the path is not null
            path = (path == null ? string.Empty : path);

            return this._fileStorage.GetStorageItems(this._website, path);
        }
    }
}
