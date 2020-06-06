using SportShop.DAL.EF;
using SportShop.DAL.Entities;
using SportShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Repositories
{
    public class RepositoryCart : IRepositoryCart<Cart, Item>
    {
        private DatabaseContext context;
        public RepositoryCart(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddToCart(Item item, string id)
        {
            var cartItem = context.Carts.SingleOrDefault(x => x.CartId == id && x.ItemId == item.ItemId);
            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ItemId = item.ItemId,
                    CartId = id,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                context.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
        }

        public int CreateOrder(Order order, string id)
        {
            decimal orderTotal = 0;
            var cartItem = GetCartItems(id);
            foreach (var item in cartItem)
            {
                var orderDetail = new DetailOrder
                {
                    ItemId = item.ItemId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Item.Price,
                    Quantity = item.Count
                };
                orderTotal += (item.Count * item.Item.Price);
                context.DetailOrders.Add(orderDetail);
            }
            order.Total = orderTotal;
            EmtyCart(id);
            context.SaveChanges();
            
            return order.OrderId;
        }

        public void EmtyCart(string id)
        {
            var cartItems = context.Carts.Where
                (
                    cart => cart.CartId == id
                );
            foreach (var cartItem in cartItems)
            {
                context.Carts.Remove(cartItem);
            }
        }

        public List<Cart> GetCartItems(string id)
        {
            return context.Carts.Where
                (
                    x => x.CartId == id
                ).ToList();
        }

        public int GetCount(string ShoppingCartId)
        {
            int? count = (from cartItems in context.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }

        public decimal GetTotal(string id)
        {
            decimal? total = (from cartItems in context.Carts
                              where cartItems.CartId == id
                              select (int?)cartItems.Count * cartItems.Item.Price).Sum();
            return total ?? decimal.Zero;
        }

        public string ItemName(int id)
        {
            return context.Carts.Single(item => item.RecordId == id).Item.ItemName;
        }

        public void MigrateCart(string Email, string id)
        {
            var shopingCart = context.Carts.Where
                (
                    x => x.CartId == id
                );
            foreach (var item in shopingCart)
            {
                item.CartId = Email;
            }
        }

        public int RemoveFromCart(string ShoppingCartId, int id)
        {
            var cartItem = context.Carts.Single(x => x.CartId == ShoppingCartId && x.RecordId == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    context.Carts.Remove(cartItem);
                }
                context.SaveChanges();
            }

            return itemCount;
        }
    }
}
