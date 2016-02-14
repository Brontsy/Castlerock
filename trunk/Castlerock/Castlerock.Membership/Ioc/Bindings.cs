using Castlerock.Membership.Repositories;
using Castlerock.Membership.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castlerock.Membership.Ioc
{
    public class Bindings : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MembershipRepository>().As<IMembershipRepository>();
            builder.RegisterType<MembershipService>().As<IMembershipService>();
        }
    }
}
