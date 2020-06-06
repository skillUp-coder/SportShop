using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using SportShop.DAL.EF;
using SportShop.DLL.Infrastructure;
using SportShop.WebUI.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SportShop.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule serviceModuleWebUI = new ServiceModuleWebUI();
            NinjectModule serviceModuleBL = new ServiceModule("ConnectionString");
            var kernel = new StandardKernel(serviceModuleBL, serviceModuleWebUI);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
