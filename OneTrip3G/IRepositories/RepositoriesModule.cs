using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Repositories;
using Autofac;

namespace OneTrip3G.IRepositories
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SettingRepository>()
                .As<ISettingRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
