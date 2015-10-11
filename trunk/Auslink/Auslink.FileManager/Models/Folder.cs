using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auslink.FileManager.Enums;

namespace Auslink.FileManager.Models
{
    public class Folder : StorageItem
    {
        public Folder()
        {
        }

        public Folder(string domain, Uri url)
            : base(StorageItemType.Folder, domain, url) 
        {
        }
    }
}
