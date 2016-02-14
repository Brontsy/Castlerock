//using System;
//using System.Collections.Generic;
//using System.Text;
//using Castlerock.Properties.Models;
//using Castlerock.Properties.Enums;

//namespace Castlerock.Properties.Interfaces
//{
//    public interface IPropertyDao : Common.Nhibernate.IBaseDao<Property, int>
//    {

//        /// <summary>
//        /// Gets all the properties that are in a particular state
//        /// </summary>
//        /// <param name="state">the state the property is in</param>
//        IList<IProperty> GetProperties(State state);

//        /// <summary>
//        /// Gets all the properties in the database
//        /// </summary>
//        IList<IProperty> GetProperties();

//        /// <summary>
//        /// Gets a list of all hte properties that are managed by castle rock
//        /// </summary>
//        /// <returns></returns>
//        IList<IProperty> GetManagedProperties();
//    }
//}
