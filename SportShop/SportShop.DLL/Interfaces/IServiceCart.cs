using SportShop.DAL.Entities;
using SportShop.DAL.Repositories;
using SportShop.DLL.DTO;
using SportShop.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SportShop.DLL.Interfaces
{
    public interface IServiceCart
    {
        //CartDTO, SportSupplementDTO, ServiceCart
        int GetCreateOrder(OrderDTO orderDTO);
        string GetItemName(int? id);
        string CartSessionKey { get;}
        string GetCartId(HttpContextBase context);
        ServiceCart GetCart(Controller controller);
        ServiceCart GetCart(HttpContextBase context);
        string ShoppingCartId { get; set; }
        void GetAddToCart(ItemDTO item);
        int GetRemoveFromCart(int? id);
        void GetEmtyCart();
        List<Cart> GetItemsCart();
        int GetCountFromCart();
        decimal GetTotalFromCart();
        void GetMigrateCart(string Email);
        void Dispose();
    }
}
