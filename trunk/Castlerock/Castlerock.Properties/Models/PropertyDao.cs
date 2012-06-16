using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Enums;

namespace Castlerock.Properties.Models
{
    public class PropertyNhibernateDao : Common.Nhibernate.AbstractNHibernateDao<Property,int>, IPropertyDao
    {
        public PropertyNhibernateDao(NHibernate.ISession session) : base(session)
        {

        }

        public IList<IProperty> GetProperties(State state)
        {
            IQuery query = Session.CreateQuery("From Property Where state = :state Order By Name");
            query.SetParameter("state", state.ToString());

            IList<IProperty> properties = query.List<IProperty>();

            return properties;
        }

        /// <summary>
        /// Gets all the properties in the database
        /// </summary>
        public IList<IProperty> GetProperties()
        {
            IQuery query = Session.CreateQuery("From Property Order By Name");

            IList<IProperty> properties = query.List<IProperty>();

            return properties;
        }


        /// <summary>
        /// Gets a list of all hte properties that are managed by castle rock
        /// </summary>
        /// <returns></returns>
        public IList<IProperty> GetManagedProperties()
        {
            IQuery query = Session.CreateQuery("From Property Where IsManaged = 1 Order By State, Name");

            return query.List<IProperty>();
        }
    }
}
