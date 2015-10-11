using Autofac;
using Auslink.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auslink.FileManager.Interfaces;
using Auslink.FileManager.Storage;

namespace Auslink.FileManager.Ioc
{
    public class Bindings : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureBlobStorage>().As<IStorageItemRepository>();
            builder.RegisterType<AzureBlobStorage>().As<IFileStorage>();
            builder.RegisterType<FileManagerService>().As<IFileManagerService>();
        }
    }
}
