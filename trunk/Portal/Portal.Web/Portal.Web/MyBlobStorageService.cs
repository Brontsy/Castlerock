using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Configuration;

namespace Portal.Web
{
    public class MyBlobStorageService
    {
        private string _local = "UseDevelopmentStorage=true";
        private string _live = "DefaultEndpointsProtocol=http;AccountName=castlerockproperty;AccountKey=sJW/sg5hx9uKm1+vP95maVK3szPBNVqzapvypfb5AEihzN6gE7Kwck+e/JUuR9Qc1bCLbmHuE0RdRo24GUTW4Q==";
        public CloudBlobContainer GetCloudBlobContainer()
        {

            string connectionInfo = ConfigurationManager.AppSettings["BlobStorageConnectionString"];

            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionInfo);
                    //RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString")

            // Create the blob client 
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("castlerock");

            // Create the container if it doesn't already exist
            if (blobContainer.CreateIfNotExist())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }

        public IList<CloudBlobContainer> GetCloudBlobContainers()
        {
            string connectionInfo = ConfigurationManager.AppSettings["BlobStorageConnectionString"];

            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionInfo);
            //RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString")

            // Create the blob client 
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("castlerock");

            return blobClient.ListContainers().ToList();
        }

    }
}