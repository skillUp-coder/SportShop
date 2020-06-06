using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IRepositoryCart<T1,T2> 
                                    where T1:class
                                    where T2:class
    {
        string ItemName(int id);
        void AddToCart(T2 item, string id);
        int RemoveFromCart(string ShoppingCartId, int id);
        void EmtyCart(string id);
        List<T1> GetCartItems(string id);
        int GetCount(string ShoppingCartId);
        decimal GetTotal(string id);
        void MigrateCart(string Email, string id);
        int CreateOrder(Order order, string id);

    }
}
