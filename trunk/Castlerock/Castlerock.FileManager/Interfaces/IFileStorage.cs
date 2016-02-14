using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castlerock.FileManager.Models;
using System.IO;
using File = Castlerock.FileManager.Models;

namespace Castlerock.FileManager.Interfaces
{
    /// <summary>
    /// Interface to save and load files to.
    /// Eg. Local c:, azure blob storage etc
    /// </summary>
    public interface IFileStorage
    {
        IStorageItem GetById(string path);
        
        /// <summary>
        /// Upload a collection of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="website">the website these files are for</param>
        /// <param name="path">the path to the location to upload the files to</param>
        /// <returns>a colletion of result objects</returns>
        IList<IStorageItem> UploadFiles(HttpFileCollectionBase files, string path);


        /// <summary>
        /// Uploads a file to the file manager
        /// </summary>
        /// <param name="files">the file to upload</param>
        /// <param name="domain">the website that is uploading the file in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        IStorageItem UploadFile(HttpPostedFileBase file, string imagePath);

        
        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="file">the file to upload</param>
        /// <param name="fileName">the name of the file to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="path">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        IStorageItem UploadFile(Stream file, string fileName, string path);

        
        /// <summary>
        /// Gets a list of all the storage items for a specific path
        /// </summary>
        /// <param name="path">the path to the storage items</param>
        IList<IStorageItem> GetStorageItems(string path);


        /// <summary>
        /// Creates a new folder in our file system
        /// </summary>
        /// <param name="website">the website that the folder is for</param>
        /// <param name="folderName">the name of the folder</param>
        /// <param name="path">the relative path to where the folder will live it</param>
        /// <returns></returns>
        Folder CreateFolder(string folderName, string path);

        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        IStorageItem DeleteFolder(string path);
        
        /// <summary>
        /// Deletes a file from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the file to be deleted</param>
        bool DeleteFile(string path);
    }
}
