using System;
using System.Collections.Generic;
using System.Text;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Models;
using Common.Nhibernate;
using Portal.Images;
using Castlerock.Properties.Enums;

namespace Castlerock.Properties
{
    public class PropertyService : IPropertyService
    {
        private IPropertyDao _propertyDao = null;
        private IImageService _imageService = null;
        private ITransactionManager _transactionManager = null;

        public PropertyService(IPropertyDao propertyDao, IImageService imageService, ITransactionManager transactionManager)
        {
            this._propertyDao = propertyDao;
            this._imageService = imageService;
            this._transactionManager = transactionManager;
        }

        public IList<IProperty> GetProperties(State state)
        {
            return this._propertyDao.GetProperties(state);
        }

        /// <summary>
        /// Gets all the properties in the database
        /// </summary>
        public IList<IProperty> GetProperties()
        {
            return this._propertyDao.GetProperties();
        }

        public IProperty GetPropertyById(int id)
        {
            return (IProperty)this._propertyDao.GetById(id);
        }

        /// <summary>
        /// Gets a list of all hte properties that are managed by castle rock
        /// </summary>
        /// <returns></returns>
        public IList<IProperty> GetManagedProperties()
        {
            return this._propertyDao.GetManagedProperties();
        }


        /// <summary>
        /// Saves a property back to the database
        /// </summary>
        /// <param name="property"></param>
        public void SaveProperty(IProperty property)
        {
            try
            {
                this._transactionManager.BeginTransaction();

                this._propertyDao.SaveOrUpdate((Property)property);

                this._transactionManager.CommitTransaction();
            }
            catch (Exception e)
            {
                if (this._transactionManager.IsInTransaction())
                {
                    this._transactionManager.RollbackTransaction();
                }

                // Add additional data about the member to a new exception
                ApplicationException exception = new ApplicationException("Probelm saving property", e);
                exception.Data.Add("Property Id", property.PropertyId);

                throw exception;
            }
        }
    }
}
