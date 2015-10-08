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
using Common.Nhibernate;
using Microsoft.WindowsAzure;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Portal.FileManager
{
    public class FileManagerService : IFileManagerService
    {
        private IFileStorage _fileStorage = null;
        private IWebsite _website = null;
        private ITransactionManager _transactionManager = null;
        private IStorageItemRepository _storageItemRepository = null;

        public FileManagerService(IWebsite website, IFileStorage fileStorage, IStorageItemRepository storageItemRepository, ITransactionManager transactionManager)
        {
            this._fileStorage = fileStorage;
            this._website = website;
            this._transactionManager = transactionManager;
            this._storageItemRepository = storageItemRepository;
        }

        /// <summary>
        /// Creates a new folder in the file manager
        /// </summary>
        /// <param name="website">the website that this folder belongs to</param>
        /// <param name="folderName">the name of the folder</param>
        /// <param name="path">the path relative to the root directory where the folder should be located</param>
        /// <returns>true if the folder was created</returns>
        public Folder CreateFolder(string folderName, string path)
        {
            return this._fileStorage.CreateFolder(this._website, folderName, path);
        }

        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        public IStorageItem DeleteFolder(string path)
        {
            return this._fileStorage.DeleteFolder(this._website, path);
        }

        /// <summary>
        /// Deletes the storage item and any children
        /// </summary>
        /// <param name="storageItem"></param>
        private void DeleteStorageItem(IStorageItem storageItem)
        {
            this._storageItemRepository.Delete(storageItem as StorageItem);
        }

        /// <summary>
        /// Deletes a file from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the file to be deleted</param>
        public bool DeleteFile(string path)
        {
            //IStorageItem storageItem = this.GetStorageItem(storageItemId);

            //if (storageItem != null)
            //{
                this._fileStorage.DeleteFile(this._website, path);
                
                //this._storageItemRepository.Delete(storageItem as StorageItem);

                return true;
            //}

            //return false;
        }

        /// <summary>
        /// Uploads a colletion of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the files to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        public IList<IStorageItem> UploadFiles(HttpFileCollectionBase files, string path)
        {
            //string path = null;
            //Folder parentFolder = null;
            //if (!string.IsNullOrEmpty(parentFolderId))
            //{
            //    parentFolder = this._storageItemRepository.GetById(parentFolderId) as Folder;
            //    path = parentFolder.Path + parentFolder.Name + "/";
            //}

            // Upload the image to the storage
            return this._fileStorage.UploadFiles(files, this._website, path);
            //IList<IStorageItem> filesUploaded = new List<IStorageItem>();

            //foreach (File file in uploadedFiles)
            //{
            //    file.Parent = parentFolder;
            //    if (!this.FileExists(file))
            //    {
            //        this.SaveStorageItem(file);
            //        filesUploaded.Add(file);
            //    }
            //}

            //return filesUploaded;
        }


        private CloudQueueClient qc;
        private CloudQueue q;

        /// <summary>
        /// Does the file already exist in the database or not
        /// </summary>
        /// <param name="file">the to see if it already exists</param>
        private bool FileExists(File file)
        {
            return this._storageItemRepository.FileExists(this._website, file);
        }
        
        
        /// <summary>
        /// Gets a list of all the storage items for a parent
        /// </summary>
        /// <param name="path">the id of the parent storage item</param>
        public IList<IStorageItem> GetStorageItems(string parentId)
        {
            return this._storageItemRepository.GetStorageItems(this._website, parentId);
        }


        /// <summary>
        /// Gets a specfic storage item from teh database
        /// </summary>
        /// <param name="storageItemId">the id of the storage item</param>
        /// <returns></returns>
        public IStorageItem GetStorageItem(string storageItemId)
        {
            try
            {
                return this._storageItemRepository.GetById(this._website, storageItemId);
            }
            catch (Exception exception)
            {
                // TODO: Log Exception
            }

            return null;
        }

        /// <summary>
        /// Saves the file back to the database
        /// </summary>
        /// <param name="file">the file to save</param>
        private StorageItem SaveStorageItem(StorageItem storageItem)
        {
            try
            {
                this._transactionManager.BeginTransaction();

                this._storageItemRepository.SaveOrUpdate(storageItem);

                this._transactionManager.CommitTransaction();
            }
            catch (Exception e)
            {
                if (this._transactionManager.IsInTransaction())
                {
                    this._transactionManager.RollbackTransaction();
                }

                throw new ApplicationException("Probelm saving file", e);
            }

            return storageItem;
        }

        public IList<IStorageItem> GetBlobStorageItems()
        {
            return this._fileStorage.GetStorageItems(this._website, string.Empty);
        }

        public void DeleteBlobStorageItem(string path)
        {
            string[] segments = path.ToString().Split('/');

            if (segments[segments.Length - 1].Contains("."))
            {
                this._fileStorage.DeleteFile(this._website, path);
            }
            else
            {
                this._fileStorage.DeleteFolder(this._website, path);
            }
        }
    }
}
