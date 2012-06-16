using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Models;

namespace Portal.Websites.Interfaces
{
    public interface IWebsiteDao : Common.Nhibernate.IBaseDao<Website, int>
    {

        IWebsite GetWebsiteByHostUrl(string hostUrl);
    }
}
