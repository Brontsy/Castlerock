using Castlerock.Properties.Enums;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Castlerock.Properties.Repository
{
    internal interface IPropertyRepository
    {
        IList<IProperty> GetProperties(State state);

        IList<IProperty> GetProperties();

        IProperty GetPropertyById(int id);

        IList<IProperty> GetManagedProperties();
    }

    internal class PropertyRepository : IPropertyRepository
    {
        private string _connectionString;

        public PropertyRepository()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["Castlerock"].ToString();
        }

        public IList<IProperty> GetProperties(State state)
        {
            string sql = @"Select * From Properties Where State = @State Order By [Order]";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                IList<Property> properties = connection.Query<Property>(sql, new { state = state.ToString() }).ToList();

                return properties.Select(o => o as IProperty).ToList();
            }
        }

        public IList<IProperty> GetProperties()
        {
            string sql = @"Select * From Properties";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                IList<Property> properties = connection.Query<Property>(sql, new { }).ToList();

                return properties.Select(o => o as IProperty).ToList();
            }
        }

        public IProperty GetPropertyById(int id)
        {
            string sql = @"Select * From Properties Where PropertyId = @PropertyId";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                IList<Property> properties = connection.Query<Property>(sql, new { PropertyId = id }).ToList();

                if (properties.Any())
                {
                    return properties.First() as IProperty;
                }

                return null;
            }
        }

        public IList<IProperty> GetManagedProperties()
        {
            string sql = @"Select * From Properties Where IsManaged = 1 Order By [Order]";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                IList<Property> properties = connection.Query<Property>(sql, new { }).ToList();

                return properties.Select(o => o as IProperty).ToList();
            }
        }
    }
}
