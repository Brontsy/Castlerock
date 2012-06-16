using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.FileManager.Interfaces;

namespace Portal.FileManager.Models
{
    public class Folder : IStorageItem
    {
        public Folder(Uri url)
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
        /// Gets the name of the folder. This simply gets the last segment of the Uri
        /// </summary>
        public string Name
        {
            get
            {
                string[] segments = this.Url.ToString().Split('/');

                for (int i = segments.Length - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrEmpty(segments[i]))
                    {
                        return segments[i];
                    }
                }

                return string.Empty;
            }
        }
    }
}
