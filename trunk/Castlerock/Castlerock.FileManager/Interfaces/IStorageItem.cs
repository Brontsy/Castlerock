using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castlerock.FileManager.Interfaces
{
    public interface IStorageItem
    {
        /// <summary>
        /// Gets the id of this storage item
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the url to access this storage item
        /// </summary>
        Uri Uri { get; }
        
        /// <summary>
        /// Gets the name of the storage item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the host of this storage item www.castlerock.blobstorage.com.au etc
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets the path to this storage item /Images/Properties/Boronia etc
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets the scheme of the storage item http or https
        /// </summary>
        string Scheme { get; }

        /// <summary>
        /// Gets the parent of this storage item (ie. the folder)
        /// </summary>
        IStorageItem Parent { get; }

        /// <summary>
        /// Gets all the children of this storage item (ie. files in a folder)
        /// </summary>
        //IList<IStorageItem> Children { get; }
    }
}
