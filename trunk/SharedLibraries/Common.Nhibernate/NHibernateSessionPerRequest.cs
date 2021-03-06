﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace Common.Nhibernate
{
    public class NHibernateSessionPerRequest : IHttpModule
    {
        private static ISessionFactory _sessionFactory;
        //private static ISession _session = null;

        public NHibernateSessionPerRequest()
        {
            _sessionFactory = CreateSessionFactory();
            //_session = null;
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(BeginRequest);
            context.EndRequest += new EventHandler(EndRequest);
        }

        public static ISession GetCurrentSession()
        {

            // running inside of an HttpContext (web mode)
            // the nhibernate session is a singleton to the http request
            HttpContext currentContext = HttpContext.Current;

            ISession session = currentContext.Items["NHibernateSession"] as ISession;

            if (session == null)
            {
                if (_sessionFactory == null)
                {
                    throw new Exception("Session Factory Is Null");
                }

                session = _sessionFactory.OpenSession();
                currentContext.Items["NHibernateSession"] = session;
            }

            return session;
        }

        public void Dispose() { }

        private void BeginRequest(object sender, EventArgs e)
        {

            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            context.Items["NHibernateSession"] = _sessionFactory.OpenSession();
        }

        private void EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            ISession session = context.Items["NHibernateSession"] as ISession;
            if (session != null)
            {
                try
                {
                    session.Flush();
                    session.Close();
                }
                catch { }
            }

            context.Items["NHibernateSession"] = null;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var config = new NHibernate.Cfg.Configuration();

            config.Configure();

            return config.BuildSessionFactory();
        }
    }
}
