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
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using System.Configuration;

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
        public Folder CreateFolder(string folderName, int? storageItemId)
        {
            string path = null;
            Folder parentFolder = null;
            if (storageItemId.HasValue)
            {
                parentFolder = this._storageItemRepository.GetById(storageItemId.Value) as Folder;
                path = parentFolder.Path + parentFolder.Name + "/";
            }

            Folder folder = this._fileStorage.CreateFolder(this._website, folderName, path);
            folder.Parent = parentFolder;

            return this.SaveStorageItem(folder) as Folder;
        }

        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        public bool DeleteFolder(int storageItemId)
        {
            IStorageItem storageItem = this.GetStorageItem(storageItemId);

            if (storageItem != null)
            {
                 this._fileStorage.DeleteFolder(this._website, storageItem.Path);

                 this.DeleteStorageItem(storageItem);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes the storage item and any children
        /// </summary>
        /// <param name="storageItem"></param>
        private void DeleteStorageItem(IStorageItem storageItem)
        {
            foreach (IStorageItem item in storageItem.Children)
            {
                this.DeleteStorageItem(item);
            }

            this._storageItemRepository.Delete(storageItem as StorageItem);
        }

        /// <summary>
        /// Deletes a file from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the file to be deleted</param>
        public bool DeleteFile(int storageItemId)
        {
            IStorageItem storageItem = this.GetStorageItem(storageItemId);

            if (storageItem != null)
            {
                this._fileStorage.DeleteFile(this._website, storageItem.Path + storageItem.Name);
                
                this._storageItemRepository.Delete(storageItem as StorageItem);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Uploads a colletion of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the files to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        public IList<IStorageItem> UploadFiles(HttpFileCollectionBase files, int? parentFolderId)
        {
            string path = null;
            Folder parentFolder = null;
            if (parentFolderId.HasValue)
            {
                parentFolder = this._storageItemRepository.GetById(parentFolderId.Value) as Folder;
                path = parentFolder.Path + parentFolder.Name + "/";
            }

            // Upload the image to the storage
            IList<IStorageItem> uploadedFiles = this._fileStorage.UploadFiles(files, this._website, path);
            IList<IStorageItem> filesUploaded = new List<IStorageItem>();

            foreach (File file in uploadedFiles)
            {
                file.Parent = parentFolder;
                if (!this.FileExists(file))
                {
                    this.SaveStorageItem(file);
                    filesUploaded.Add(file);
                }
            }

            string connectionInfo = ConfigurationManager.AppSettings["BlobStorageConnectionString"];

            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionInfo);
            qc = storageAccount.CreateCloudQueueClient();
            q = qc.GetQueueReference("FileUpdates");
            q.CreateIfNotExist();

            q.AddMessage(new CloudQueueMessage("File Updates"));

            return filesUploaded;
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
        public IList<IStorageItem> GetStorageItems(int? parentId)
        {
            return this._storageItemRepository.GetStorageItems(this._website, parentId);
        }


        /// <summary>
        /// Gets a specfic storage item from teh database
        /// </summary>
        /// <param name="storageItemId">the id of the storage item</param>
        /// <returns></returns>
        public IStorageItem GetStorageItem(int storageItemId)
        {
            try
            {
                return this._storageItemRepository.GetById(storageItemId);
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
