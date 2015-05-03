using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using PP.API.Core.Models;
using Microsoft.AspNet.Identity;
using PP.BL.Interfaces;

namespace PP.API.Controllers
{
    [RoutePrefix("api/Account")]
    [EnableCors(origins: "http://192.168.0.103:3454", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
         private readonly IAuthBl _authBl;

        public AccountController(IAuthBl authBl)
        {
            _authBl = authBl;
        }

        public AccountController()
        {
            _authBl = (IAuthBl)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAuthBl));
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(AuthUserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = Mapper.Map<IdentityUser>(userModel);
            var result = await _authBl.RegisterUser(Mapper.Map<IdentityUser>(userModel), userModel.Password);
            var errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}