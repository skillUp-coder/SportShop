using Microsoft.AspNet.Identity.EntityFramework;

namespace SportShop.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
