using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportShop.DAL.Entities;

namespace SportShop.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString, throwIfV1Schema: false) { }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
