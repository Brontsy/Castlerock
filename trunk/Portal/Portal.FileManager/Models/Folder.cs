using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.FileManager.Enums;
using Portal.Websites.Interfaces;

namespace Portal.FileManager.Models
{
    public class Folder : StorageItem
    {
        public Folder()
        {
        }

        public Folder(IWebsite website, Uri url)
            : base(StorageItemType.Folder, website, url) 
        {
        }
    }
}
