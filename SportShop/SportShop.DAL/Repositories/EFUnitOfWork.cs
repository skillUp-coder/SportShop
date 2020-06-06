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
    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext context;

        private RepositoryOrder repositoryOrder;
        private CategoryRepository repositoryCategory;
        private RepositoryCart repositoryCart;
        private RepositoryItem repositoryItem;
        private RepostoryDescription repostoryDescription;
        private RepositoryManager repositoryManager;
        public EFUnitOfWork(string connection)
        {
            context = new DatabaseContext(connection);
        }

        public IRepositoryItem<Item> Items { get 
            {
                if (repositoryItem == null)
                    repositoryItem = new RepositoryItem(context);
                return repositoryItem;
            } }

        public IRepositoryCart<Cart, Item> Carts { get 
            {
                if (repositoryCart == null)
                    repositoryCart = new RepositoryCart(context);
                return repositoryCart;
            } }

        public ICategoryRepository<Category> Categories { get 
            {
                if (repositoryCategory == null)
                    repositoryCategory = new CategoryRepository(context);
                return repositoryCategory;
            } }

        public IRepositoryOrder<Order> Orders { get 
            {
                if (repositoryOrder == null)
                    repositoryOrder = new RepositoryOrder(context);
                return repositoryOrder;
            } }

        public IRepositoryDescription<DescriptionItem> Descriptions { get 
            {
                if (repostoryDescription == null)
                    repostoryDescription = new RepostoryDescription(context);
                return repostoryDescription;
            } }

        public IRepositoryManager<Item> Manager { get 
            {
                if (repositoryManager == null)
                    repositoryManager = new RepositoryManager(context);
                return repositoryManager;
            } }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
