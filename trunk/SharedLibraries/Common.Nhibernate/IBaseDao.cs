using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Nhibernate
{
    public interface IBaseDao<T, IdT>
    {
        T GetById(IdT id);
        T Save(T entity);
        T SaveOrUpdate(T entity);
        NHibernate.ISession Session { get; }
        void Delete(T entity);
    }
}
