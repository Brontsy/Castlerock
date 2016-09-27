﻿using Autofac;
using Autofac.Integration.Mvc;
using Castlerock.Web.New.Providers;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Castlerock.Web.New
{
    public class AutofacConfig
    {
        public static void RegisterBindings()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new Castlerock.Membership.Ioc.Bindings());
            builder.RegisterModule(new Castlerock.Properties.Ioc.Bindings());
            builder.RegisterModule(new Castlerock.FileManager.Ioc.Bindings());

            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            builder.RegisterFilterProvider();
            //builder.RegisterType<HandleExceptionAttribute>().AsExceptionFilterFor<Controller>().InstancePerRequest().PropertiesAutowired();

            builder.RegisterType<LoginProvider>().As<ILoginProvider>();
            builder.RegisterType<MemberProvider>().As<IMemberProvider>();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}