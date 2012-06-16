using System;
using System.Collections.Generic;
using System.Text;
using Castlerock.Properties.Models;

namespace Castlerock.Properties.Interfaces
{
    public interface IInvestmentDao : Common.Nhibernate.IBaseDao<Investment, int>
    {

        /// <summary>
        /// Gets all the investments
        /// </summary>
        /// <returns></returns>
        IList<Investment> GetInvestments();
    }
}
