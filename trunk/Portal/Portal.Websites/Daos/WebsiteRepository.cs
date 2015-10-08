using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Models;
using Portal.Websites.Interfaces;
using NHibernate;
using System.Data.SqlClient;
using System.Configuration;

namespace Portal.Websites.Daos
{
    public class WebsiteDao : IWebsiteDao
    {
        private string _connectionString;

        public WebsiteDao()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["Portal"].ToString();
        }

        public IWebsite GetWebsiteByHostUrl(string hostUrl)
        {
            using(SqlConnection connection = new SqlConnection(this._connectionString))
            {
                Website website = connection.Query<Website>("Select WebsiteId as Id, * From Websites Where Host = @Host", new { Host = hostUrl }).First();
                website.Components = this.GetWebsiteComponents(website.Id);

                return website;
            }
        }

        private IList<Component> GetWebsiteComponents(int websiteId)
        {
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<Component>("select * from Components Inner Join WebsiteComponents On Components.ComponentId = WebsiteComponents.ComponentId Where WebsiteId = @WebsiteId", new { WebsiteId = websiteId }).ToList();
            }
        }

        public Website GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Website Save(Website entity)
        {
            throw new NotImplementedException();
        }

        public Website SaveOrUpdate(Website entity)
        {
            throw new NotImplementedException();
        }

        public ISession Session
        {
            get { throw new NotImplementedException(); }
        }

        public void Delete(Website entity)
        {
            throw new NotImplementedException();
        }
    }
}
