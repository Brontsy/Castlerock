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
            :base (StorageItemType.Folder)
        {

        }
        public Folder(IWebsite website, string scheme, string host, string path, string folderName)
            : base(StorageItemType.Folder, website, scheme, host, path, folderName) 
        {
        }
    }
}
