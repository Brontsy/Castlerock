using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.FileManager.Interfaces;

namespace Portal.FileManager.Models
{
    public class File : IStorageItem
    {
        public File(Uri url)
        {
            this.Url = url;
        }

        /// <summary>
        /// Gets the url to access this storage item
        /// </summary>
        public Uri Url
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the file. This simply gets the last segment of the Uri
        /// </summary>
        public string Name
        {
            get
            {
                string[] segments = this.Url.ToString().Split('/');

                return segments[segments.Length - 1];
            }
        }
    }
}
