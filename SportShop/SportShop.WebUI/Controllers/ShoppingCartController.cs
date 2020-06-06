using SportShop.DLL.DTO;
using SportShop.DLL.Interfaces;
using SportShop.DLL.Services;
using SportShop.WebUI.ViewModel;
using System.Web.Mvc;

namespace SportShop.WebUI.Controllers
{
    /// <summary>
    /// Interaction with the map, display, addition, removal of necessary things is carried out.
    /// </summary>
    public class ShoppingCartController : Controller
    {
        private IServiceCart serviceCart;
        private IServiceItem serviceItem;

        public ShoppingCartController(IServiceCart serviceCart, IServiceItem serviceItem)
        {
            this.serviceCart = serviceCart;
            this.serviceItem = serviceItem;
        }

        public ActionResult DisplayCart(string returnUrl) 
        {
            ServiceCart cart = serviceCart.GetCart(this.HttpContext);
            ShoppingCartViewModel model = new ShoppingCartViewModel
            {
                CartItems = cart.GetItemsCart(),
                CartTotal = cart.GetTotalFromCart(),
                returnUrl = returnUrl
            };
            return View(model);
        }

        public RedirectToRouteResult AddToCart(int itemId, string returnUrl) 
        {
            ItemDTO getItem = serviceItem.GetItem(itemId);
            ServiceCart cart = serviceCart.GetCart(this.HttpContext);
            cart.GetAddToCart(getItem);
            return RedirectToAction("DisplayCart", new { returnUrl});
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id) 
        {
            string itemName = serviceCart.GetItemName(id);
            var cart = serviceCart.GetCart(this.HttpContext);
            int ItemCount = cart.GetRemoveFromCart(id);

            var model = new ShoppindCartRemoveViewModel 
            {
                Message = Server.HtmlEncode(itemName) + " has been removed from your shopping cart.",
                CartTotal = cart.GetTotalFromCart(),
                ItemCount = ItemCount,
                DeleteId = id
            };
            return Json(model);
        }
        public PartialViewResult CartSummary() 
        {
            CartSummaryViewModel model = new CartSummaryViewModel 
            {
                 Cart = serviceCart.GetCart(this.HttpContext),
                 
            };
            //ServiceCart cart = serviceCart.GetCart(this.HttpContext);
            ViewBag.CountItem = model.Cart.GetCountFromCart();/*cart.GetCountFromCart();*/
            ViewBag.TotalFromCart = model.Cart.GetTotalFromCart();
            //ViewBag.ReturnUrl = returnUrl;
            return PartialView(model);
        }
        protected override void Dispose(bool disposing)
        {
            serviceItem.Dispose();
            serviceCart.Dispose();
            base.Dispose(disposing);
        }
    }
    
}