using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryManager<Item> Manager { get; }
        IRepositoryOrder<Order> Orders { get;}
        ICategoryRepository<Category> Categories { get; }
        IRepositoryCart<Cart, Item> Carts { get; }
        IRepositoryItem<Item> Items { get; }
        IRepositoryDescription<DescriptionItem> Descriptions { get; }
        void Save();
    }
}
