using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Services;
using OneTrip3G.IRepositories;
using Autofac;
using OneTrip3G.Infrastructure;

namespace OneTrip3G.IServices
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new SettingService(c.Resolve<ISettingRepository>()))
                .As<ISettingService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new PlaceService(c.Resolve<IPlaceRepository>(), c.Resolve<IUnitOfWork>(), c.Resolve<ISettingService>()))
                .As<IPlaceService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new UserService(c.Resolve<IUserRepository>(), c.Resolve<IUnitOfWork>()))
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
    }
}
