using SportShop.DAL.Entities;
using SportShop.DAL.Interfaces;
using SportShop.DLL.DTO;
using SportShop.DLL.Infrastructure;
using SportShop.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SportShop.DLL.Services
{
    public class ServiceCart : IServiceCart
    {
        private IUnitOfWork Database;
        public ServiceCart(IUnitOfWork Database)
        {
            this.Database = Database;
        }
        public string CartSessionKey { get { return "CartId"; }}
        public string ShoppingCartId { get; set; }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void GetAddToCart(ItemDTO item)
        {
            if (item == null)
                throw new ValidationException("Don`tFound data","");

            Item _item = new Item 
            {
                 ItemId = item.ItemId
            };
            Database.Carts.AddToCart(_item, ShoppingCartId);
            Database.Save();
        }

        public  ServiceCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public ServiceCart GetCart(HttpContextBase context)
        {
            ServiceCart cart = new ServiceCart(Database);
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public int GetCountFromCart()
        {
            return Database.Carts.GetCount(ShoppingCartId);
        }

        public int GetCreateOrder(OrderDTO orderDTO)
        {
            if(orderDTO == null)
                throw new ValidationException("Don`t Found data", "");

            Order getOrder = Database.Orders.GetOrder(orderDTO.Username);
            //Order orderId = new Order 
            //{
            //     OrderId = orderDTO.OrderId
            //};
            return Database.Carts.CreateOrder(getOrder, ShoppingCartId);
        }

        public void GetEmtyCart()
        {
            Database.Carts.EmtyCart(ShoppingCartId);
            Database.Save();
        }

        public string GetItemName(int? id)
        {
            if(id == null)
                throw new ValidationException("Don`t Found data", "");

            return Database.Carts.ItemName(id.Value);
        }

        public List<Cart> GetItemsCart()
        {
            return Database.Carts.GetCartItems(ShoppingCartId);
        }

        public void GetMigrateCart(string Email)
        {
            if(Email == null)
                throw new ValidationException("Don`t Found data", "");

            Database.Carts.MigrateCart(Email, ShoppingCartId);
            Database.Save();
        }

        public int GetRemoveFromCart(int? id)
        {
            if(id == null)
                throw new ValidationException("Don`t Found data", "");

            return Database.Carts.RemoveFromCart(ShoppingCartId, id.Value);
        }

        public decimal GetTotalFromCart()
        {
            return Database.Carts.GetTotal(ShoppingCartId);
        }
    }
}
