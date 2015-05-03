using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using PP.ServiceLocation;
using PP.ServiceLocation.ServiceLocator;

namespace PP.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            App_Start.AutoMapper.Map();
        }

        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );

        //    var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
        //    jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        ////    InstallUnity(config);
        //}

        //private static void InstallUnity(HttpConfiguration config)
        //{
        //    var container = new UnityContainer();
        //    UnityInstaller.Install(container);
        //    IControllerFactory factory = new UnityControllerFactory(container);
        //    ControllerBuilder.Current.SetControllerFactory(factory);
        //    //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
        //    //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
        //    //container.RegisterType<AccountController>(new InjectionConstructor());
        //    config.DependencyResolver = new UnityResolver(container);
        //}
    }
}
