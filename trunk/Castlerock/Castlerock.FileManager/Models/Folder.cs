using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castlerock.FileManager.Enums;

namespace Castlerock.FileManager.Models
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
