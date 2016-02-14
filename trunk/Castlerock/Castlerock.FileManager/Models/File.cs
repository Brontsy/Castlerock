using Castlerock.FileManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castlerock.FileManager.Models
{
    public class File : StorageItem
    {
        public File()
        {
        }

        public File(string domain, Uri url)
            : base(StorageItemType.File, domain, url) 
        {
        }


        public static string GetFileName(Uri uri)
        {
            if(string.IsNullOrEmpty(uri.ToString()))
            {
                return null;
            }

            var segments = uri.ToString().Split('/');

            return segments[segments.Length - 1];
        }
    }
}
