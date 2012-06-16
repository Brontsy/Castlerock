using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace Common.Nhibernate
{
    public class NhibernateSessionManager
    {
        private static ISessionFactory _sessionFactory;
        private static ISession _session = null;

        static NhibernateSessionManager()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
            }

            return _session;
        }

        public static ISessionFactory CreateSessionFactory()
        {
            if (NhibernateSessionManager._sessionFactory == null)
            {
                NhibernateSessionManager._sessionFactory = new Configuration().Configure().BuildSessionFactory();
            }
            return NhibernateSessionManager._sessionFactory;
        }

    }
}
