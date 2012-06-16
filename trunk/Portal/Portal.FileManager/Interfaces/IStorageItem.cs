using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.FileManager.Interfaces
{
    public interface IStorageItem
    {
        /// <summary>
        /// Gets the url to access this storage item
        /// </summary>
        Uri Url { get; }
        
        /// <summary>
        /// Gets the name of the storage item.
        /// </summary>
        string Name { get; }
    }
}
