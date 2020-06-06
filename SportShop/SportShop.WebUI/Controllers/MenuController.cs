using SportShop.DLL.Interfaces;
using SportShop.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop.WebUI.Controllers
{
    /// <summary>
    /// Navigation in progress.
    /// </summary>
    public class MenuController : Controller
    {
        private IServiceItem serviceItem;
        private IServiceCatogory serviceCatogory;
        public MenuController(IServiceItem serviceItem, IServiceCatogory serviceCatogory)
        {
            this.serviceItem = serviceItem;
            this.serviceCatogory = serviceCatogory;
        }
        
        public PartialViewResult Menu(string category = null,string name = null, string cost = null)
        {
            ViewBag.SelectedCategory = name;
            ViewBag.SelectedCost = cost;
            ViewBag.Category = category;
            MenuViewModel model = new MenuViewModel 
            {
               CategoryName = serviceCatogory.GetFindByNameItem(category),
               GetCategory = serviceCatogory.GetCategory(category)
            };
            //IEnumerable<string> CategoryName = serviceCatogory.GetFindByNameItem(category);
                //serviceItem.GetByCategoryName(); 
            return PartialView(model);
        }

        protected override void Dispose(bool disposing)
        {
            serviceItem.Dispose();
            base.Dispose(disposing);
        }
    }
}