using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PP.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PP.ServiceLocation;
using PP.ServiceLocation.ServiceLocator;

[assembly: OwinStartup(typeof(PP.API.Startup))]

namespace PP.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var config = new HttpConfiguration();
            InstallUnity(config);
            app.UseWebApi(config);
            WebApiConfig.Register(config);
            
            ConfigureOpenAuth(app);
        }

        private void ConfigureOpenAuth(IAppBuilder app)
        {
            var oAuthAuthorizationServer
                = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new SimpleAuthorizationServerProvider()
                };
           
            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthAuthorizationServer);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static void InstallUnity(HttpConfiguration config)
        {
            var container = new UnityContainer();
            UnityInstaller.Install(container);
            IControllerFactory factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<AccountController>(new InjectionConstructor());

            IDependencyResolver resolver = DependencyResolver.Current;
            IDependencyResolver newResolver = new UnityDependencyResolver(container, resolver);
            DependencyResolver.SetResolver(newResolver);

         //   config.DependencyResolver = new UnityResolver(container);
        }
    }

    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        private IDependencyResolver resolver;

        public UnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            this.container = container;
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch
            {
                return this.resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch
            {
                return this.resolver.GetServices(serviceType);
            }
        }
    }
}