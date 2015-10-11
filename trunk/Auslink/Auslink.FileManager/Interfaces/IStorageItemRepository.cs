using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auslink.FileManager.Models;

namespace Auslink.FileManager.Interfaces
{
    /// <summary>
    /// Interface to save and retrieve the location of images
    /// </summary>
    public interface IStorageItemRepository 
    {

        IStorageItem GetById(string path);

        /// <summary>
        /// Does the file already exist in the database or not
        /// </summary>
        /// <param name="file">the to see if it already exists</param>
        bool FileExists(File file);

        /// <summary>
        /// gets a specific file from the datbasae
        /// </summary>
        /// <param name="path">the path to the file</param>
        /// <param name="fileName">the name of the file</param>
        /// <returns></returns>
        File GetFile(File file);

        /// <summary>
        /// Gets all the storage items for a specfic parent.
        /// If the parent is null then it will return all the files in the root directory
        /// </summary>
        /// <param name="website">the website that the files / folders belong to</param>
        /// <param name="parentId">the id of the parent</param>
        /// <returns></returns>
        IList<IStorageItem> GetStorageItems(string parentId);
    }
}
