using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace OneTrip3G.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DatabaseFactory>()
                .As<IDatabaseFactory>()
                .InstancePerLifetimeScope();

            builder.Register(c => new UnitOfWork(c.Resolve<IDatabaseFactory>()))
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
