using Auslink.QuarterlyUpdates.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.QuarterlyUpdates.Repositories
{
    internal interface IQuarterlyUpdatesRepository
    {
        IList<QuarterlyUpdate> GetQuarterlyUpdates();

        QuarterlyUpdate GetQuarterlyUpdateById(int quarterlyUpdateId);

        void Save(QuarterlyUpdate quarterlyUpdate);

        void Delete(int quarterlyUpdateId);
    }

    internal class QuarterlyUpdatesRepository : IQuarterlyUpdatesRepository
    {
        private string _connectionString;

        public QuarterlyUpdatesRepository()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["Castlerock"].ToString();
        }

        public IList<QuarterlyUpdate> GetQuarterlyUpdates()
        {
            string sql = "Select * From QuarterlyUpdates Order By [Year], [Month] Desc";
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<QuarterlyUpdate>(sql, new { }).ToList();
            }
        }

        public QuarterlyUpdate GetQuarterlyUpdateById(int quarterlyUpdateId)
        {
            string sql = "Select * From QuarterlyUpdates Where Id = @Id";
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<QuarterlyUpdate>(sql, new { Id = quarterlyUpdateId }).FirstOrDefault();
            }
        }


        public void Save(QuarterlyUpdate quarterlyUpdate)
        {
            if(quarterlyUpdate.Id == 0)
            {
                string sql = "Insert Into QuarterlyUpdates (Text,  DownloadLink, Month, Year) Values (@Text, @DownloadLink, @Month, @Year)";

                using (SqlConnection connection = new SqlConnection(this._connectionString))
                {
                    connection.Execute(sql, new 
                    {
                        Text = quarterlyUpdate.Text,
                        DownloadLink = quarterlyUpdate.DownloadLink,
                        Month = quarterlyUpdate.Month,
                        Year = quarterlyUpdate.Year
                    });
                }
            }
            else
            {
                string sql = "Update QuarterlyUpdates Set Text = @Text, DownloadLink = @DownloadLink, Month = @Month, Year = @Year Where Id = @Id";
                
                using (SqlConnection connection = new SqlConnection(this._connectionString))
                {
                    connection.Execute(sql, new
                    {
                        Id = quarterlyUpdate.Id,
                        Text = quarterlyUpdate.Text,
                        DownloadLink = quarterlyUpdate.DownloadLink,
                        Month = quarterlyUpdate.Month,
                        Year = quarterlyUpdate.Year
                    });
                }
            }
        }


        public void Delete(int quarterlyUpdateId)
        {
            string sql = "Delete QuarterlyUpdates Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Execute(sql, new
                {
                    Id = quarterlyUpdateId
                });
            }
        }
    }
}
