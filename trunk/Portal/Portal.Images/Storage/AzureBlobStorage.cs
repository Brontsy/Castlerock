using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Portal.Images.Interfaces;
using Portal.Images.Models;
using Common.Extensions;

namespace Portal.Images.Storage
{
    public class AzureBlobStorage : IImageStorage
    {

        /// <summary>
        /// Uploads a colletion of files to the image server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        public IList<ImageUploadResult> UploadImages(HttpFileCollectionBase files, string domain, string imagePath)
        {
            IList<ImageUploadResult> result = new List<ImageUploadResult>();


            foreach (string key in files.Keys)
            {
                result.Add(this.UploadImage(files[key], domain, imagePath));
            }

            return result;
        }

        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="files">the file to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        public ImageUploadResult UploadImage(HttpPostedFileBase file, string domain, string imagePath)
        {
            ImageUploadResult uploadResult = new ImageUploadResult();

            CloudBlobContainer blobContainer = this.GetCloudBlobContainer(domain);

            string fileName = new Random().String(12) + "-" + file.FileName;

            CloudBlob blob = blobContainer.GetBlobReference(imagePath + fileName);

            // Create or overwrite the "myblob" blob with contents from a local file
            blob.UploadFromStream(file.InputStream);

            // Create a new image so we can calculate the width and height
            var image = System.Drawing.Image.FromStream(file.InputStream);

            uploadResult.Source = blob.Uri.ToString();
            uploadResult.Width = image.Width;
            uploadResult.Height = image.Height;
            uploadResult.StorageId = fileName;

            return uploadResult;
        }

        private CloudBlobContainer GetCloudBlobContainer(string domain)
        {

            string connectionInfo = ConfigurationManager.AppSettings["BlobStorageConnectionString"];

            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionInfo);

            // Create the blob client 
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(domain);

            // Create the container if it doesn't already exist
            if (blobContainer.CreateIfNotExist())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }
    }
}
