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
    /// Displaying certain things by category.
    /// </summary>
    public class StoreController : Controller
    {
        private IServiceCatogory serviceCategory;
        private IServiceItem serviceItem;
        private IServiceDescription serviceDescription;
        public StoreController(IServiceCatogory service, IServiceItem serviceItem , IServiceDescription serviceDescription)
        {
            this.serviceCategory = service;
            this.serviceItem = serviceItem;
            this.serviceDescription = serviceDescription;
        }
        
        public PartialViewResult Index() 
        {
            var model = serviceCategory.GetAllCategories();
            return PartialView(model);
        }
        public ActionResult Browse(string category,string name = null, int page = 1, string cost = null)
        {
            int PageSize = 1;
            IEnumerable<ItemDTO> datas;
            switch (cost)
            {
                case "to-cheap":
                    datas = serviceItem.SortedDatas(category);
                    break;
                default:
                    datas = serviceItem.DatasMatchingCategories(page, PageSize, name, category);
                    break;
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
            ViewBag.ItemName = name;
            
            SortCategoryViewModel _model = new SortCategoryViewModel
            {
                CategoryModel = serviceCategory.GetCategory(category),
                DescriptionModel = serviceDescription.GetDescriptionCategory(category),
                CurrentCategory = name,
                Info = new InfoOfPage
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = serviceItem.Count(name, category)
                },
                Items = mapper.Map<IEnumerable<ItemDTO>, IList<ItemViewModel>>(datas)
            }; 
            //var categoryModel = serviceCategory.GetCategory(category);
            return View(_model);
        }
        public ActionResult Details(int id) 
        {
            var Item = serviceItem.GetItem(id);
            return View(Item);
        }
        protected override void Dispose(bool disposing)
        {
            serviceItem.Dispose();
            serviceCategory.Dispose();
            base.Dispose(disposing);
        }
    }
}