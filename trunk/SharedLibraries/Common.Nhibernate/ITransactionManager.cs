using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Nhibernate
{
    /// <summary>
    /// This interface allows the business logic of the application to access transaction
    /// features on the database. Providing this interface allows for inversion of control
    /// so that the the business logic can be easily unit tested.
    /// </summary>
    public interface ITransactionManager
    {
        bool IsInTransaction();
        void BeginTransaction();
        void BeginTransaction(System.Data.IsolationLevel isolationLevel);
        void CommitTransaction();
        void RollbackTransaction();
        System.Data.IDbConnection CurrentDatabaseConnection();
        void LockObjectForRead(object objectToLock);
    }
}
