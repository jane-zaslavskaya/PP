using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using PP.API.Providers;

[assembly: OwinStartup(typeof(PP.API.Startup))]

namespace PP.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ConfigureOpenAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            App_Start.AutoMapper.Map();
        }

        private void ConfigureOpenAuth(IAppBuilder app)
        {
            var oAuthAuthorixationServer =
                new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new SimpleAuthorizationServerProvider()
                };

            // Token generation
            app.UseOAuthAuthorizationServer(oAuthAuthorixationServer);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}