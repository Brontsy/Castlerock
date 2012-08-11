using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Interfaces;
using Portal.FileManager.Enums;

namespace Portal.FileManager.Models
{
    public class File : StorageItem
    {
        public File() : base (StorageItemType.File) { }

        public File(IWebsite website, string scheme, string host, string path, string fileName)
            : base(StorageItemType.File, website, scheme, host, path, fileName) 
        {
        }
    }
}
