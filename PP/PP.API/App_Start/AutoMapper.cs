using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using PP.API.Core.Models;

namespace PP.API.App_Start
{
    public class AutoMapper
    {
        public static void Map()
        {
            Mapper.CreateMap<AuthUserModel, IdentityUser>();
        }
    }
}