using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PP.API.Startup))]

namespace PP.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            App_Start.AutoMapper.Map();
        }
    }
}