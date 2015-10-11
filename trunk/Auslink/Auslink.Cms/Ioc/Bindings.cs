using Auslink.Cms.Repositories;
using Auslink.Cms.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Cms.Ioc
{
    public class Bindings : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PageRepository>().As<IPageRepository>();
            builder.RegisterType<PageService>().As<IPageService>();
        }
    }
}
