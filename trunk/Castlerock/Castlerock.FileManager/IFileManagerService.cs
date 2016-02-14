using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castlerock.FileManager.Models;
using System.Web;
using Castlerock.FileManager.Interfaces;

namespace Castlerock.FileManager
{
    public interface IFileManagerService
    {
        /// <summary>
        /// Creates a new folder in the file manager
        /// </summary>
        /// <param name="website">the website that this folder belongs to</param>
        /// <param name="folderName">the name of the folder</param>
        /// <param name="relativePath">the path relative to the root directory where the folder should be located</param>
        /// <returns>the newly created folder</returns>
        Folder CreateFolder(string folderName, string storageItemId);


        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        IStorageItem DeleteFolder(string storageItemId);


        /// <summary>
        /// Deletes a storage item from the file system
        /// </summary>
        /// <returns></returns>
        bool DeleteFile(string storageItemId);


        /// <summary>
        /// Uploads a colletion of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the files to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        IList<IStorageItem> UploadFiles(HttpFileCollectionBase files, string parentFolderId);

        
        /// <summary>
        /// Gets a list of all the storage items for a parent
        /// </summary>
        /// <param name="path">the id of the parent storage item</param>
        IList<IStorageItem> GetStorageItems(string parentId);

        /// <summary>
        /// Gets a specfic storage item from teh database
        /// </summary>
        /// <param name="storageItemId">the id of the storage item</param>
        /// <returns></returns>
        IStorageItem GetStorageItem(string storageItemId);


        IList<IStorageItem> GetBlobStorageItems();


        void DeleteBlobStorageItem(string path);
    }
}
