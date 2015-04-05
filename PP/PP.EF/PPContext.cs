using Microsoft.AspNet.Identity.EntityFramework;

namespace PP.EF
{
    public class PPContext : IdentityDbContext<IdentityUser>
    {
        public PPContext()
            : base("PPContext")
        {
        }
    }
}