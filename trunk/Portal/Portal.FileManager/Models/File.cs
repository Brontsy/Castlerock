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
        public File()
        {
        }

        public File(IWebsite website, Uri url)
            : base(StorageItemType.File, website, url) 
        {
        }
    }
}
