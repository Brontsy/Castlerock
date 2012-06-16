using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Models;
using Portal.Websites.Interfaces;

namespace Portal.Websites
{
    public interface IWebsiteService
    {
        /// <summary>
        /// Gets a specific website by its Id
        /// </summary>
        /// <param name="websiteId">the Id of the website to find</param>
        IWebsite GetWebsiteById(int websiteId);

        IWebsite GetWebsiteByHostUrl(string portalUrl);
    }
}
