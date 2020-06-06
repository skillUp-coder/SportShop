using AutoMapper;
using SportShop.DLL.DTO;
using SportShop.DLL.Interfaces;
using SportShop.WebUI.Models;
using SportShop.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop.WebUI.Controllers
{
    /// <summary>
    /// Displaying categories with things and switching to necessary things.
    /// </summary>
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private IServiceItem serviceItem;
        public HomeController(IServiceItem serviceItem)
        {
            this.serviceItem = serviceItem;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayItems(string category, int page = 1, string cost = null)
        {
            //int PageSize = 1;
            //IEnumerable<ItemDTO> datas;
            //switch (cost) 
            //{
            //    case "to-cheap":
            //        datas = serviceItem.SortedDatas();
            //        break;
            //    default:
            //        datas = serviceItem.DatasMatchingCategories(page,PageSize,category);
            //        break;
            //}

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();

            //var model = new SortCategoryViewModel 
            //{
            //    //Items = mapper.Map<IEnumerable<ItemDTO>, IList<ItemViewModel>>(datas),
            //    Info = new InfoOfPage
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = PageSize,
            //        TotalItems = serviceItem.Count(category)
            //    },
            //    CurrentCategory = category
            //};
            return View();
        }

        public PartialViewResult Menu(string category = null, string cost = null) 
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectegCost = cost;

            MenuViewModel model = new MenuViewModel
            {
                CategoryName = serviceItem.GetByCategoryName()
            };
            return PartialView(model);
        }

        protected override void Dispose(bool disposing)
        {
            serviceItem.Dispose();
            base.Dispose(disposing);
        }
    }
}