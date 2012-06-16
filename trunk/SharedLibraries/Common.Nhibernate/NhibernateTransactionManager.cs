using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace Common.Nhibernate
{
    /// <summary>
    /// This class implements the ITransaction manager so that the business layer can call 
    /// nhibernate without having to know about the implementation so that this can be replaced
    /// at runtime for testing etc
    /// </summary>
    public class NhibernateTransactionManager : ITransactionManager
    {
        private ISession _session;
        /// <summary>
        /// Requires the current session that is being used
        /// </summary>
        /// <param name="session"></param>
        public NhibernateTransactionManager(ISession session)
        {
            //throw an exception if the session is null
            if (session == null)
            {
                throw new ApplicationException("The nhibernate session passed into NhibernateTransactionManager was null.");
            }

            _session = session;
        }

        #region ITransactionManager Members

        /// <summary>
        /// Is the current database connection being used in a transaction. Should
        /// only support one active transaction on one connection at one time.
        /// </summary>
        /// <returns></returns>
        public bool IsInTransaction()
        {
            bool returnValue = false;

            if (_session.Transaction != null && _session.Transaction.IsActive)
            {
                return true;
            }

            return returnValue;
        }

        /// <summary>
        /// This function will check that the object passed in has not been modified,
        /// if this is done inside a transaction with a high enough isolation level
        /// then this will mean that others can not read the data while the transaction
        /// is in progress.
        /// </summary>
        /// <param name="objectToReadLock"></param>
        public void LockObjectForRead(object objectToReadLock)
        {
            _session.Lock(objectToReadLock, LockMode.Read);
        }


        /// <summary>
        /// Will begin a transaction. 
        /// </summary>
        public void BeginTransaction()
        {
            _session.BeginTransaction();
        }

        public void BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            _session.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction()
        {
            _session.Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (_session.Transaction != null && _session.Transaction.IsActive)
            {
                _session.Transaction.Rollback();
            }
        }

        public System.Data.IDbConnection CurrentDatabaseConnection()
        {
            return _session.Connection;
        }

        #endregion
    }
}
