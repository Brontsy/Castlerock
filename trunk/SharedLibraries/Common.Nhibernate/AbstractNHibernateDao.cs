using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
//using Qfx.Utils;
//using Qfx.Common.BusinessLogic;
using System.Data;

namespace Common.Nhibernate
{
    /// <summary>
    /// The super type for DAO's to inherite from. Contains all the standard nhibernate functions
    /// that can be done using the type and the id, subclasses should implement any other specific
    /// queries that the IDao interface for that entity, most of the time this will be query functions
    /// specific to that entity (like GetByName queries).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="IdT"></typeparam>
    public abstract class AbstractNHibernateDao<T, IdT> : IBaseDao<T, IdT>
    {
        private ISession _session = null;
        private Type _persitentType = typeof(T);

        public AbstractNHibernateDao()
        {
        }

        public AbstractNHibernateDao(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Gets the nhibernate session object that will be used for 
        /// persistance operations.
        /// </summary>
        public ISession Session
        {
            get { return _session; }
        }

        /// <summary>
        /// Loads an instance of type T from the Database based on its Id
        /// </summary>
        public virtual T GetById(IdT id)
        {
            return (T)this.Session.Load(this._persitentType, id);
        }

        /// <summary>
        /// For entities that have assigned ID's, you must explicitly call Save to add a new one.
        /// </summary>
        public virtual T Save(T entity)
        {
            this.Session.Save(entity);
            return entity;
        }

        /// <summary>
        /// For entities with automatatically generated IDs, such as identity, SaveOrUpdate may 
        /// be called when saving a new entity.  SaveOrUpdate can also be called to _update_ any 
        /// entity, even if its Id is assigned.
        /// </summary>
        public virtual T SaveOrUpdate(T entity)
        {
            this.Session.SaveOrUpdate(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            this.Session.Delete(entity);
        }
    }
}
