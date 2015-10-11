using Auslink.Web.New.Providers;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New
{
    public class AutofacConfig
    {
        public static void RegisterBindings()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new Auslink.Membership.Ioc.Bindings());
            builder.RegisterModule(new Auslink.QuarterlyUpdates.Ioc.Bindings());
            builder.RegisterModule(new Auslink.FileManager.Ioc.Bindings());
            builder.RegisterModule(new Auslink.Cms.Ioc.Bindings());

            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            builder.RegisterFilterProvider();
            //builder.RegisterType<HandleExceptionAttribute>().AsExceptionFilterFor<Controller>().InstancePerRequest().PropertiesAutowired();

            builder.RegisterType<LoginProvider>().As<ILoginProvider>();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
