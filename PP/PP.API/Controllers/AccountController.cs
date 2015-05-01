using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using PP.API.Core.Models;
using Microsoft.AspNet.Identity;
using PP.BL.Interfaces;

namespace PP.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
         private readonly IAuthBl _authBl;

        public AccountController()
        { }

        public AccountController(IAuthBl authBl)
        {
            _authBl = authBl;
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