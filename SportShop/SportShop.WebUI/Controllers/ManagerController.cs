using SportShop.DLL.DTO;
using SportShop.DLL.Interfaces;
using SportShop.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SportShop.WebUI.Controllers
{
    /// <summary>
    /// The process of adding new things, deleting and changing them.
    /// </summary>
    [Authorize(Users = "manager@gmail.com")]
    public class ManagerController : Controller
    {
        private IServiceCatogory serviceCatogory;
        private IServiceManager serviceManager;
        private IServiceDescription serviceDescription;

        public ManagerController( IServiceCatogory serviceCatogory, IServiceManager serviceManager, IServiceDescription serviceDescription)
        {
            this.serviceDescription = serviceDescription;
            this.serviceCatogory = serviceCatogory;
            this.serviceManager = serviceManager;
        }
        public ActionResult Index()
        {
            IEnumerable<ItemManager> items = serviceManager.GetAllItems();
            return View(items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(serviceCatogory.GetAllCategories(), "CategoryId", "Name");
            ViewBag.DescriptionItemId = new SelectList(serviceDescription.GetAllDescription(), "DescriptionItemId", "Category");
            ViewBag.ItemCategory = new SelectList(serviceCatogory.GetAllCategories(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemViewModel item)
        {
            ItemManager itemDTO = new ItemManager
            {
                CategoryId = item.CategoryId,
                ColorItem = item.ColorItem,
                DescriptionItemId = item.DescriptionItemId,
                ItemArtUrl1 = item.ItemArtUrl1,
                ItemArtUrl2 = item.ItemArtUrl2,
                ItemArtUrl3 = item.ItemArtUrl3,
                ItemArtUrl4 = item.ItemArtUrl4,
                ItemArtUrl5 = item.ItemArtUrl5,
                ItemCategory = item.ItemCategory,
                ItemName = item.ItemName,
                Price = item.Price
            };
            if (ModelState.IsValid)
            {
                serviceManager.GetCreateItem(itemDTO);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryId = new SelectList(serviceCatogory.GetAllCategories(), "CategoryId", "Name");
                ViewBag.DescriptionItemId = new SelectList(serviceDescription.GetAllDescription(), "DescriptionItemId", "Category");
                ViewBag.ItemCategory = new SelectList(serviceCatogory.GetAllCategories(), "Name", "Name");
                return View(item);
            }
        }

        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            ItemManager getItem = serviceManager.GetItem(id.Value);
            if (getItem == null)
                return HttpNotFound();

            ViewBag.CategoryId = new SelectList(serviceCatogory.GetAllCategories(), "CategoryId", "Name");
            ViewBag.DescriptionItemId = new SelectList(serviceDescription.GetAllDescription(), "DescriptionItemId", "Category");
            ViewBag.ItemCategory = new SelectList(serviceCatogory.GetAllCategories(), "Name", "Name");
            return View(getItem);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemManager item) 
        {
            if (ModelState.IsValid)
            {
                serviceManager.GetEditItem(item);
                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.CategoryId = new SelectList(serviceCatogory.GetAllCategories(), "CategoryId", "Name");
                ViewBag.DescriptionItemId = new SelectList(serviceDescription.GetAllDescription(), "DescriptionItemId", "Category");
                ViewBag.ItemCategory = new SelectList(serviceCatogory.GetAllCategories(), "Name", "Name");
                return View(item);
            }
        }

        [HttpGet]
        public ActionResult DeleteItem(int ? id ) 
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            serviceManager.GerRemoveItem(id.Value);
            return RedirectToAction("Index");

        }
        protected override void Dispose(bool disposing)
        {
            serviceCatogory.Dispose();
            serviceManager.Dispose();
            serviceDescription.Dispose();
            base.Dispose(disposing);
        }
    }

    
}