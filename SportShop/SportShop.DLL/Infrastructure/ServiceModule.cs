using Ninject.Modules;
using SportShop.DAL.Interfaces;
using SportShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            this.connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
