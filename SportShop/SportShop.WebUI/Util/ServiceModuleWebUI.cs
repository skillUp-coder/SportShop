using Ninject.Modules;
using SportShop.DLL.Interfaces;
using SportShop.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.WebUI.Util
{
    public class ServiceModuleWebUI : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceCatogory>().To<ServiceCategory>();
            Bind<IServiceItem>().To<ServiceItem>();
            Bind<IServiceCart>().To<ServiceCart>();
            Bind<IServiceOrder>().To<ServiceOrder>();
            Bind<IServiceDescription>().To<ServiceDescription>();
            Bind<IServiceManager>().To<ServiceManager>();
        }
    }
}