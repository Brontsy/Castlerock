using System;
using NHibernate;
using Castlerock.Properties;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Models;
using Common.Nhibernate;
using Portal.Websites.Models;
using Portal.Websites;
using System.Web;
using Portal.Websites.Interfaces;
using Portal.Websites.Daos;
using Portal.Membership;
using Portal.Membership.Interfaces;
using Portal.Membership.Daos;
using Portal.FileManager;
using Portal.FileManager.Storage;
using Portal.FileManager.Interfaces;
using Portal.FileManager.Daos;

namespace Castlerock.Web
{
    public static class ServiceLocator
    {

        public static ISession GetCurrentSession()
        {
            ISession session = NHibernateSessionPerRequest.GetCurrentSession();
            return session;
        }


        public static IPropertyService GetPropertyService()
        {
            IPropertyDao propertyDao = new PropertyNhibernateDao(GetCurrentSession());
            return new PropertyService(propertyDao, GetCastlerockTransactionManager());
        }

        //public static IImageService GetImageService()
        //{
        //    IImageRepository repoistory = new ImageNhibernateRepository(GetCurrentSession());
        //    IImageStorage storage = new AzureBlobStorage();

        //    return new ImageService(GetWebsite(), storage, repoistory, GetCastlerockTransactionManager());
        //}

        public static IMembershipService GetMembershipService()
        {
            IMemberDao memberDao = new MemberNhibernateDao(GetCurrentSession());
            IRoleDao roleDao = new RoleNhibernateDao(GetCurrentSession());
            return new MembershipService(GetWebsite(), memberDao, roleDao, GetCastlerockTransactionManager());
        }

        public static Common.Nhibernate.ITransactionManager GetCastlerockTransactionManager()
        {
            return new Common.Nhibernate.NhibernateTransactionManager(GetCurrentSession());
        }

        public static IWebsite GetWebsite()
        {
            IWebsiteDao websiteDao = new WebsiteNhibernateDao(GetCurrentSession());

            string host = System.Web.HttpContext.Current.Request.Url.Host;

            return new WebsiteService(websiteDao).GetWebsiteByHostUrl(host.Replace("dev.", string.Empty).Replace("www.", string.Empty).Replace("portal.", string.Empty));
            //return new WebsiteService(websiteDao).GetWebsiteByHostUrl(HttpContext.Current.Request.Url.Host);
        }

        public static IFileManagerService GetFileManagerService()
        {
            IFileStorage fileStorage = new AzureBlobStorage();
            IStorageItemRepository repository = new StorageItemNhibernateRepository(GetCurrentSession());

            return new FileManagerService(GetWebsite(), fileStorage, repository, GetCastlerockTransactionManager());
        }
    }
}
