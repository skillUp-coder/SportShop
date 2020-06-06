using SportShop.DAL.Repositories;
using SportShop.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
