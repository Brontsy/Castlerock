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

        public static Common.Nhibernate.ITransactionManager GetCastlerockTransactionManager()
        {
            return new Common.Nhibernate.NhibernateTransactionManager(GetCurrentSession());
        }

        public static IWebsite GetWebsite()
        {
            IWebsiteDao websiteDao = new WebsiteNhibernateDao(GetCurrentSession());
            return new WebsiteService(websiteDao).GetWebsiteByHostUrl(HttpContext.Current.Request.Url.Host);
        }
    }
}
