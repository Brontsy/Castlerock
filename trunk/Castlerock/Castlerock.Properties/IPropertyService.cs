using System;
using System.Collections.Generic;
using System.Text;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Enums;

namespace Castlerock.Properties
{
    public interface IPropertyService
    {
        /// <summary>
        /// Gets all the properties that are in a particular state
        /// </summary>
        /// <param name="state">the state the property is in</param>
        IList<IProperty> GetProperties(State state);

        /// <summary>
        /// Gets all the properties in the database
        /// </summary>
        IList<IProperty> GetProperties();


        IProperty GetPropertyById(int id);



        /// <summary>
        /// Gets a list of all hte properties that are managed by castle rock
        /// </summary>
        /// <returns></returns>
        IList<IProperty> GetManagedProperties();

        /// <summary>
        /// Saves a property back to the database
        /// </summary>
        /// <param name="property"></param>
        void SaveProperty(IProperty property);
    }
}
