using Autofac;
using Castlerock.Properties.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castlerock.Properties.Ioc
{
    public class Bindings : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PropertyRepository>().As<IPropertyRepository>();
            builder.RegisterType<PropertyService>().As<IPropertyService>();
        }
    }
}
