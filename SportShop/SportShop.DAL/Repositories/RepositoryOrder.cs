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
    public class RepositoryOrder : IRepositoryOrder<Order>
    {
        private DatabaseContext context;
        public RepositoryOrder(DatabaseContext context)
        {
            this.context = context;
        }
        public void Create(Order item)
        {
            context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = context.Orders.Find(id);
            if (order != null)
                context.Orders.Remove(order);
        }

        public Order Get(int id)
        {
            return context.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetOrder(string Email)
        {
            return context.Orders.Where(x => x.Username == Email).FirstOrDefault();
        }

        public void Update(Order item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
