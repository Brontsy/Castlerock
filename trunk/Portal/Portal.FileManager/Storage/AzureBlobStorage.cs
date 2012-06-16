using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Portal.FileManager.Interfaces;
using Portal.FileManager.Models;
using Portal.Websites.Interfaces;
using System.IO;
using File = Portal.FileManager.Models.File;
using System.Reflection;

namespace Portal.FileManager.Storage
{
    public class AzureBlobStorage : IFileStorage
    {

        /// <summary>
        /// Upload a collection of files to the server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="website">the website these files are for</param>
        /// <param name="path">the path to the location to upload the files to</param>
        /// <returns>a colletion of result objects</returns>
        public IList<FileUploadResult> UploadFiles(HttpFileCollectionBase files, IWebsite website, string path)
        {
            IList<FileUploadResult> result = new List<FileUploadResult>();

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
        public FileUploadResult UploadFile(HttpPostedFileBase file, IWebsite website, string path)
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
        public FileUploadResult UploadFile(Stream file, string fileName, IWebsite website, string path)
        {
            FileUploadResult uploadResult = new FileUploadResult();

            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);

            if (!string.IsNullOrEmpty(path) && !path.EndsWith("/"))
            {
                path += "/";
            }

            CloudBlob blob = blobContainer.GetBlobReference(path + fileName);

            blob.Properties.ContentType = this.GetContentType(fileName);
            // Create or overwrite the "myblob" blob with contents from a local file
            blob.UploadFromStream(file);

            // Create a new image so we can calculate the width and height
            uploadResult.Source = blob.Uri.ToString();
            uploadResult.StorageId = fileName;

            if (!string.IsNullOrEmpty(path))
            {
                CloudBlob cloudBlob = blobContainer.GetBlobReference(path);
                cloudBlob.DeleteIfExists();
            }

            return uploadResult;
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
            if (blobContainer.CreateIfNotExist())
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

            foreach (IListBlobItem blobItem in blobItems)
            {
                if (this.IsFolder(blobItem))
                {
                    folders.Add(new Folder(blobItem.Uri));
                }
                else
                {
                    files.Add(new File(blobItem.Uri));
                }
            }

            files = files.OrderBy(o => o.Name).ToList();
            folders = folders.OrderBy(o => o.Name).ToList();

            folders.AddRange(files);

            return folders;
        }

        private bool IsFolder(IListBlobItem blobItem)
        {
            string[] segments = blobItem.Uri.ToString().Split('/');

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
        public bool CreateFolder(IWebsite website, string folderName, string path)
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            assemblyLocation = new System.Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath + "/folder.txt";

            FileStream file = System.IO.File.Open(assemblyLocation, FileMode.OpenOrCreate);

            this.UploadFile(file, folderName + "/", website, path);

            file.Close();

            return true;
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

            CloudBlob cloudBlob = blobContainer.GetBlobReference(path);

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
        public bool DeleteFolder(IWebsite website, string path)
        {
            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(website);
            
            // We must add a forward slash to the end because of azure. See when creating a folder we also
            // add a forward slash to the end.
            CloudBlobDirectory directory = blobContainer.GetDirectoryReference(path + "/");

            var blobs = directory.ListBlobs();

            foreach (IListBlobItem blob in blobs)
            {
                if ((blob as CloudBlob) != null)
                {
                    ((CloudBlob)blob).DeleteIfExists();
                }
            }

            CloudBlob cloudBlob = blobContainer.GetBlobReference(path + "/");

            // If we cannot delete a direct reference (ie a file) then we must be deleting a directory
            cloudBlob.DeleteIfExists();


            return true;
        }
    }
}
