using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Interfaces;
using Portal.FileManager.Models;
using System.Web;
using Portal.FileManager.Interfaces;

namespace Portal.FileManager
{
    public interface IFileManagerService
    {
        /// <summary>
        /// Creates a new folder in the file manager
        /// </summary>
        /// <param name="website">the website that this folder belongs to</param>
        /// <param name="folderName">the name of the folder</param>
        /// <param name="relativePath">the path relative to the root directory where the folder should be located</param>
        /// <returns>true if the folder was created</returns>
        bool CreateFolder(string folderName, string relativePath);


        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        bool DeleteFolder(string path);


        /// <summary>
        /// Deletes a file from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        bool DeleteFile(string path);


        /// <summary>
        /// Uploads a colletion of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the files to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        IList<FileUploadResult> UploadFiles(HttpFileCollectionBase files, string path);

        
        /// <summary>
        /// Gets a list of all the storage items for a specific path
        /// </summary>
        /// <param name="path">the path to the storage items</param>
        IList<IStorageItem> GetStorageItems(string path);
    }
}
