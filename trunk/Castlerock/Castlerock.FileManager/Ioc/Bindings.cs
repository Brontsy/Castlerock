﻿using Autofac;
using Castlerock.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castlerock.FileManager.Interfaces;
using Castlerock.FileManager.Storage;

namespace Castlerock.FileManager.Ioc
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