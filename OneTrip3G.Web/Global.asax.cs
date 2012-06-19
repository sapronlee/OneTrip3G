using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using OneTrip3G.IRepositories;
using OneTrip3G.IServices;
using OneTrip3G.Infrastructure;
using OneTrip3G.Models;
using StackExchange.Profiling;

namespace OneTrip3G.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static SettingViewModel Settings { get; set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "LoginOrLogout",
                "{loginorLogout}",
                new { controller = "Users", action = "Login" },
                new { loginorLogout = @"login|logout" },
                new[] { "OneTrip3G.Web.Controllers" }
            );

            routes.MapRoute(
                "PlaceMap",
                "places/{urlKey}/Map",
                new { controller = "Places", action = "Map" },
                new[] { "OneTrip3G.Web.Controllers" }
            );

            routes.MapRoute(
                "ShowPlace",
                "places/{urlKey}",
                new { controller = "Places", action = "Show" },
                new[] { "OneTrip3G.Web.Controllers" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "OneTrip3G.Web.Controllers" }
            );

        }

        protected void Application_BeginRequest()
        {
            //开启MiniProfiler
            if (Request.IsLocal)
                MiniProfiler.Start();
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        protected void Application_Start()
        {
            var container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Settings = DependencyResolver.Current.GetService<ISettingService>().GetSettings<SettingViewModel>();
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new ServicesModule());

            return builder.Build();
        }
    }
}