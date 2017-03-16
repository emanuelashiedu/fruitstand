using AutoMapper;
using FruitStand.Data.Abstract;
using FruitStand.Data.Concrete;
using FruitStand.Providers;
using FruitStand.Services.Abstract;
using FruitStand.Services.Concrete;
using FruitStand.Services.Provider;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FruitStand
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Register<IService, Service>();
            container.Register<IRepository, Repository>();
            // AreaRegistration.RegisterAllAreas();

            //mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperAppProfileConfig());
                cfg.AddProfile(new AutoMapperServicesConfig());
            });

            config.AssertConfigurationIsValid();
            container.RegisterSingleton(config);
            container.Register(() => config.CreateMapper(container.GetInstance));
            container.Verify();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
