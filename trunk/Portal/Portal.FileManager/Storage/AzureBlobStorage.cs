using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.WindowsAzure;
/*using Microsoft.WindowsAzure.ServiceRuntime;*/
using Portal.FileManager.Interfaces;
using Portal.FileManager.Models;
using Portal.Websites.Interfaces;
using System.IO;
using File = Portal.FileManager.Models.File;
using System.Reflection;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace Portal.FileManager.Storage
{
    public class AzureBlobStorage : IFileStorage, IStorageItemRepository
    {

        /// <summary>
        /// Upload a collection of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="website">the website these files are for</param>
        /// <param name="path">the path to the location to upload the files to</param>
        /// <returns>a colletion of result objects</returns>
        public IList<IStorageItem> UploadFiles(HttpFileCollectionBase files, IWebsite website, string path)
        {
            IList<IStorageItem> result = new List<IStorageItem>();

            foreach (string key in files.Keys)
            {
                result.Add(this.UploadFile(files[key], website, path));
            }

            return result;
        }

        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="file">the file to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="path">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        public IStorageItem UploadFile(HttpPostedFileBase file, IWebsite website, string path)
        {
            return this.UploadFile(file.InputStream, file.FileName, website, path);
        }

        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="file">the file to upload</param>
        /// <param name="fileName">the name of the file to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="path">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        public IStorageItem UploadFile(Stream file, string fileName, IWebsite website, string path)
        {
            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);

            if (!string.IsNullOrEmpty(path) && !path.EndsWith("/"))
            {
                path += "/";
            }

            ICloudBlob blob = blobContainer.GetBlobReferenceFromServer(path + fileName);

            blob.Properties.ContentType = this.GetContentType(fileName);
            // Create or overwrite the "myblob" blob with contents from a local file
            blob.UploadFromStream(file);

            if (!string.IsNullOrEmpty(path))
            {
                //CloudBlob cloudBlob = blobContainer.GetBlobReference(path);
                //cloudBlob.DeleteIfExists();
            }

            string host = blob.Uri.Host;
            for (int i = 0; i < 2; i++) { host += blob.Uri.Segments[i]; }

            File uploadFile = new File(website, blob.Uri);
            uploadFile.Type = this.GetContentType(fileName);

            return uploadFile;
        }

        private string GetContentType(string fileName)
        {
            if(fileName.Contains('.'))
            {
                string[] segments = fileName.Split('.');
                switch (segments[segments.Length - 1])
                {
                    case "pdf":
                        return "application/pdf";
                    case "jpg":
                    case "jpeg":
                        return "image/jpg";
                    case "png":
                        return "image/png";
                    case "gif":
                        return "image/gif";
                }
            }

            return "application/octet-stream";
        }

        private CloudBlobContainer GetCloudBlobContainer(IWebsite website)
        {

            string connectionInfo = ConfigurationManager.AppSettings["BlobStorageConnectionString"];

            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionInfo);

            // Create the blob client 
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(website.Domain);

            // Create the container if it doesn't already exist
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }


        public IList<IStorageItem> GetStorageItems(IWebsite website, string path)
        {
            List<IStorageItem> folders = new List<IStorageItem>();
            List<IStorageItem> files = new List<IStorageItem>();

            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);

            IEnumerable<IListBlobItem> blobItems = new List<IListBlobItem>();

            if (string.IsNullOrEmpty(path))
            {
                blobItems = blobContainer.ListBlobs();
            }
            else
            {
                CloudBlobDirectory directory = blobContainer.GetDirectoryReference(path);
                blobItems = directory.ListBlobs().Where(o => o.Uri != directory.Uri);
            }


            foreach (var item in blobItems.Where(o => !o.Uri.PathAndQuery.Contains("folder.txt")))
            {
                IStorageItem storageItem = null;

                if(this.IsFolder(item.Uri))
                {
                    Folder folder = this.CreateFolderFromUri(website, item.Uri);

                    storageItem = folder;
                }
                else
                {
                    File file = this.CreateFileFromUri(website, item.Uri);

                    storageItem = file;
                }

                files.Add(storageItem);
            }

            return files;


            //foreach (IListBlobItem blobItem in blobItems)
            //{
            //    if (this.IsFolder(blobItem))
            //    {
            //        folders.Add(new Folder(blobItem.Uri));
            //    }
            //    else
            //    {
            //        files.Add(this.CreateFileFromUri(website, blobItem.Uri));
            //    }
            //}

            //files = files.OrderBy(o => o.Name).ToList();
            //folders = folders.OrderBy(o => o.Name).ToList();

            //folders.AddRange(files);

            //return folders;
        }

        private File CreateFileFromUri(IWebsite website, Uri uri)
        {
            string host = uri.Host;
            string path = string.Empty;
            string fileName = uri.Segments[uri.Segments.Length - 1];
            for (int i = 0; i < 2; i++) { host += uri.Segments[i]; }
            for (int i = 2; i < uri.Segments.Length - 1; i++) { path += uri.Segments[i]; }

            return new File(website, uri);
        }

        private bool IsFolder(Uri url)
        {
            string[] segments = url.ToString().Split('/');

            if (segments[segments.Length - 1].Contains("."))
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Creates a new folder in our file system
        /// </summary>
        /// <param name="website">the website that the folder is for</param>
        /// <param name="folderName">the name of the folder</param>
        /// <param name="path">the relative path to where the folder will live it</param>
        /// <returns></returns>
        public Folder CreateFolder(IWebsite website, string folderName, string path)
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            assemblyLocation = new System.Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath + "/folder2.txt";

            FileStream file = System.IO.File.Open(assemblyLocation, FileMode.OpenOrCreate);

           IStorageItem uploadedFile = this.UploadFile(file, folderName + "/folder.txt", website, path);

            file.Close();

            return this.CreateFolderFromUri(website, uploadedFile.Uri);
        }

        private Folder CreateFolderFromUri(IWebsite website, Uri uri)
        {
            string host = uri.Host;
            string path = string.Empty;
            string fileName = uri.Segments[uri.Segments.Length - 1];
            for (int i = 0; i < 2; i++) { host += uri.Segments[i]; }
            for (int i = 2; i < uri.Segments.Length - 1; i++) { path += uri.Segments[i]; }

            return new Folder(website, uri);
        }


        /// <summary>
        /// Deletes a file from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the folder to be deleted</param>
        /// <returns></returns>
        public bool DeleteFile(IWebsite website, string path)
        {
            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);

            ICloudBlob cloudBlob = blobContainer.GetBlobReferenceFromServer(path);

            // If we cannot delete a direct reference (ie a file) then we must be deleting a directory
            if (!cloudBlob.DeleteIfExists())
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Deletes a folder from the file system
        /// </summary>
        /// <param name="website">the website that we are deleting the folder from</param>
        /// <param name="path">the path of the file to be deleted</param>
        public IStorageItem DeleteFolder(IWebsite website, string path)
        {
            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);
            
            // We must add a forward slash to the end because of azure. See when creating a folder we also
            // add a forward slash to the end.
            CloudBlobDirectory directory = blobContainer.GetDirectoryReference(path + "/");

            var blobs = directory.ListBlobs();

            foreach (IListBlobItem blob in blobs)
            {
                if ((blob as ICloudBlob) != null)
                {
                    ((ICloudBlob)blob).DeleteIfExists();
                }
            }

            ICloudBlob cloudBlob = blobContainer.GetBlobReferenceFromServer(path + "/");

            // If we cannot delete a direct reference (ie a file) then we must be deleting a directory
            cloudBlob.DeleteIfExists();

            if (this.IsFolder(cloudBlob.Uri))
            {
                return new Folder(website, cloudBlob.Uri);
            }

            return new File(website, cloudBlob.Uri);
        }

        #region IStorageItemRepository Members

        public bool FileExists(IWebsite website, File file)
        {
            throw new NotImplementedException();
        }

        public File GetFile(IWebsite website, File file)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBaseDao<StorageItem,string> Members

        public StorageItem GetById(string path)
        {
            throw new NotImplementedException();
        }

        public IStorageItem GetById(IWebsite website, string path)
        {
            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);

            ICloudBlob cloudBlob = blobContainer.GetBlobReferenceFromServer(path);

            if (this.IsFolder(cloudBlob.Uri))
            {
                return this.CreateFolderFromUri(website, cloudBlob.Uri);
            }
            else
            {
                return this.CreateFileFromUri(website, cloudBlob.Uri);
            }
        }

        public StorageItem Save(StorageItem entity)
        {
            throw new NotImplementedException();
        }

        public StorageItem SaveOrUpdate(StorageItem entity)
        {
            throw new NotImplementedException();
        }

        public NHibernate.ISession Session
        {
            get { throw new NotImplementedException(); }
        }

        public void Delete(StorageItem entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
