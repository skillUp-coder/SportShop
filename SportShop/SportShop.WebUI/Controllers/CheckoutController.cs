using SportShop.DAL.Entities;
using SportShop.DLL.DTO;
using SportShop.DLL.Interfaces;
using SportShop.DLL.Services;
using SportShop.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop.WebUI.Controllers
{
    /// <summary>
    /// The necessary items are being ordered.
    /// </summary>
    public class CheckoutController : Controller
    {
        private IServiceOrder serviceOrder;
        private IServiceCart serviceCart;
        public CheckoutController(IServiceOrder serviceOrder, IServiceCart serviceCart)
        {
            this.serviceCart = serviceCart;
            this.serviceOrder = serviceOrder;
        }
        [HttpGet]
        public ActionResult Index()
        {
            ServiceCart cart = serviceCart.GetCart(this.HttpContext);
            ViewBag.Total = cart.GetTotalFromCart();
            return View();
        }
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OrderViewModel model) 
        {
            OrderDTO orderDTO = new OrderDTO();
            TryUpdateModel(orderDTO);
            if (ModelState.IsValid)
            {
                ServiceCart cart = serviceCart.GetCart(this.HttpContext);

                orderDTO.OrderDate = DateTime.Now;
                orderDTO.Total = cart.GetTotalFromCart();
                orderDTO.Username = User.Identity.Name;
                

                serviceOrder.CreateOrder(orderDTO);
                cart.GetCreateOrder(orderDTO);
                

                return RedirectToAction("index", "home");
            }
            else 
            {
                ViewBag.Error = "Error";
                ModelState.AddModelError("","Not correct datas!");
                return View(model);

            } 
        }
        protected override void Dispose(bool disposing)
        {
            serviceCart.Dispose();
            serviceOrder.Dispose();
            base.Dispose(disposing);
        }
    }
}