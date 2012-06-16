using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using Castlerock.Properties.Interfaces;

namespace Castlerock.Properties.Models
{
    public class InvestmentDao : Common.Nhibernate.AbstractNHibernateDao<Investment,int>, IInvestmentDao
    {
        public InvestmentDao()
        {

        }

        public InvestmentDao(NHibernate.ISession session)
            : base(session)
        {

        }

        /// <summary>
        /// Gets all the investments
        /// </summary>
        /// <returns></returns>
        public IList<Investment> GetInvestments()
        {
            IQuery query = Session.CreateQuery("From Investment");

            return query.List<Investment>();
        }
    }
}
