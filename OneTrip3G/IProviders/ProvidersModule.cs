using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Providers;
using OneTrip3G.IRepositories;
using Autofac;

namespace OneTrip3G.IProviders
{
    public class ProvidersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new GlobalSettingProvider(c.Resolve<ISettingRepository>()))
                .As<IGlobalSettingProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
