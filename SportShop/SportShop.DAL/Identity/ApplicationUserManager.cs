using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportShop.DAL.Entities;


namespace SportShop.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
