using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Nhibernate;
using NHibernate;
using Portal.FileManager.Models;
using Portal.FileManager.Interfaces;
using Portal.Websites.Interfaces;

namespace Portal.FileManager.Daos
{
    public class StorageItemNhibernateRepository : AbstractNHibernateDao<StorageItem, string>, IStorageItemRepository
    {
        public StorageItemNhibernateRepository(ISession session)
            :base(session)
        {

        }


        public IStorageItem GetById(IWebsite website, string path)
        {
            return null;
        }


        /// <summary>
        /// Does the file already exist in the database or not
        /// </summary>
        /// <param name="file">the to see if it already exists</param>
        public bool FileExists(IWebsite website, File file)
        {
            IQuery query = this.Session.CreateQuery("Select f From File f Inner Join Fetch f.Website w Where f.Path = :path And f.Name = :name And w.Id = :websiteId");

            query.SetParameter("path", file.Path);
            query.SetParameter("name", file.Name);
            query.SetParameter("websiteId", website.Id);

            return query.List<File>().Count > 0;
        }


        /// <summary>
        /// gets a specific file from the datbasae
        /// </summary>
        /// <param name="path">the path to the file</param>
        /// <param name="fileName">the name of the file</param>
        /// <returns></returns>
        public File GetFile(IWebsite website, File file)
        {
            IQuery query = this.Session.CreateQuery("Select f From File f Inner Join Fetch f.Website w Where f.Path = :path And f.Name = :name And w.Id = :websiteId");

            query.SetParameter("path", file.Path);
            query.SetParameter("name", file.Name);
            query.SetParameter("websiteId", website.Id);

            return query.UniqueResult<File>();
        }


        /// <summary>
        /// Gets all the storage items for a specfic parent.
        /// If the parent is null then it will return all the files in the root directory
        /// </summary>
        /// <param name="website">the website that the files / folders belong to</param>
        /// <param name="parentId">the id of the parent</param>
        /// <returns></returns>
        public IList<IStorageItem> GetStorageItems(IWebsite website, string parentId)
        {
            IList<IStorageItem> storageItems = new List<IStorageItem>();
            IQuery query = null;

            if (string.IsNullOrEmpty(parentId))
            {
                query = this.Session.CreateQuery("Select storageItem From StorageItem storageItem Inner Join Fetch storageItem.Website w Where storageItem.Parent Is Null And w.Id = :websiteId");
            }
            else
            {
                query = this.Session.CreateQuery("Select storageItem From StorageItem storageItem Inner Join Fetch storageItem.Website w Where storageItem.Parent.Id = :parentId And w.Id = :websiteId");

                query.SetParameter("parentId", parentId);
            }

            query.SetParameter("websiteId", website.Id);
            var items = query.List<IStorageItem>();

            return items;
        }
    }
}
