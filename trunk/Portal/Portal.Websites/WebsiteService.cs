using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Models;
using Portal.Websites.Interfaces;

namespace Portal.Websites
{
    public class WebsiteService : IWebsiteService
    {
        private IWebsiteDao _websiteDao = null;

        public WebsiteService(IWebsiteDao websiteDao)
        {
            this._websiteDao = websiteDao;
        }

        /// <summary>
        /// Gets a specific website by its Id
        /// </summary>
        /// <param name="websiteId">the Id of the website to find</param>
        public IWebsite GetWebsiteById(int websiteId)
        {
            return this._websiteDao.GetById(websiteId);
        }

        public IWebsite GetWebsiteByHostUrl(string hostUrl)
        {
            return this._websiteDao.GetWebsiteByHostUrl(hostUrl);
        }
    }
}
