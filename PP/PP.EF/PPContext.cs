using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PP.EF
{
    public class PPContext : IdentityDbContext<IdentityUser>
    {
        public PPContext()
            : base(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=C:\Users\Jane\Documents\GitHub\PP\PP\pp.mdf;Integrated Security=True;")
        {
        }

    }
}