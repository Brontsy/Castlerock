using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace Portal.Meassaging.Worker
{
    public class WorkerRole : RoleEntryPoint
    {
        private CloudQueueClient qc;
        private CloudQueue q;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("Portal.Meassaging.Worker entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine("Working", "Information");

                CloudStorageAccount sa = CloudStorageAccount.FromConfigurationSetting("DefaultEndpointsProtocol=http;AccountName=castlerockproperty;AccountKey=sJW/sg5hx9uKm1+vP95maVK3szPBNVqzapvypfb5AEihzN6gE7Kwck+e/JUuR9Qc1bCLbmHuE0RdRo24GUTW4Q==");
                qc = sa.CreateCloudQueueClient();
                q = qc.GetQueueReference("FileUpdates");
                q.CreateIfNotExist();


                IEnumerable<CloudQueueMessage> messages = q.PeekMessages(2);
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
