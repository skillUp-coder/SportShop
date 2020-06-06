using SportShop.DAL.Entities;
using System.Collections.Generic;


namespace SportShop.WebUI.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public string returnUrl { get; set; }
    }
}