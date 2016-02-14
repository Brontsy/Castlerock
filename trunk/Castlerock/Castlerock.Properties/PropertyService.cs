using System;
using System.Collections.Generic;
using System.Text;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Models;
using Castlerock.Properties.Enums;
using Castlerock.Properties.Repository;

namespace Castlerock.Properties
{
    internal class PropertyService : IPropertyService
    {
        private IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
        }

        public IList<IProperty> GetProperties(State state)
        {
            return this._propertyRepository.GetProperties(state);
        }

        /// <summary>
        /// Gets all the properties in the database
        /// </summary>
        public IList<IProperty> GetProperties()
        {
            return this._propertyRepository.GetProperties();
        }

        public IProperty GetPropertyById(int id)
        {
            return this._propertyRepository.GetPropertyById(id);
        }

        /// <summary>
        /// Gets a list of all hte properties that are managed by castle rock
        /// </summary>
        /// <returns></returns>
        public IList<IProperty> GetManagedProperties()
        {
            return this._propertyRepository.GetManagedProperties();
        }


        /// <summary>
        /// Saves a property back to the database
        /// </summary>
        /// <param name="property"></param>
        public void SaveProperty(IProperty property)
        {
            //try
            //{
            //    this._transactionManager.BeginTransaction();

            //    this._propertyDao.SaveOrUpdate((Property)property);

            //    this._transactionManager.CommitTransaction();
            //}
            //catch (Exception e)
            //{
            //    if (this._transactionManager.IsInTransaction())
            //    {
            //        this._transactionManager.RollbackTransaction();
            //    }

            //    // Add additional data about the member to a new exception
            //    ApplicationException exception = new ApplicationException("Probelm saving property", e);
            //    exception.Data.Add("Property Id", property.PropertyId);

            //    throw exception;
            //}
        }
    }
}
