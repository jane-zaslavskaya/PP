using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PP.BL.Interfaces;
using PP.EF;

namespace PP.BL.Implementation
{
    public class AuthBl : IAuthBl, IDisposable
    {
        private UserManager<IdentityUser> userManager;

        public AuthBl()
        {
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new PPContext()));
        }

        public async Task<IdentityResult> RegisterUser(IdentityUser userModel, string password)
        {
            return await this.userManager.CreateAsync(userModel, password);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await this.userManager.FindAsync(userName, password);
        }

        public void Dispose()
        {
            this.userManager.Dispose();
        }
    }
}