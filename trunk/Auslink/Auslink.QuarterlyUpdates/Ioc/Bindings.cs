using Auslink.QuarterlyUpdates.Repositories;
using Auslink.QuarterlyUpdates.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.QuarterlyUpdates.Ioc
{
    public class Bindings : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QuarterlyUpdatesRepository>().As<IQuarterlyUpdatesRepository>();
            builder.RegisterType<QuarterlyUpdatesService>().As<IQuarterlyUpdatesService>();
        }
    }
}
