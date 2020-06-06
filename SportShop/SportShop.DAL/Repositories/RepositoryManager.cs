using SportShop.DAL.EF;
using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SportShop.DAL.Interfaces;

namespace SportShop.DAL.Repositories
{
    public class RepositoryManager:IRepositoryManager<Item>
    {
        private DatabaseContext context;
        public RepositoryManager(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Item> GetItems() 
        {
            var items = context.Items.Include(x => x.Category).Include(x => x.DescriptionItem);
            return items.ToList();
        }

        public Item GetItem(int id) 
        {
            Item item = context.Items.Find(id);
            return item;
        }

        public void CreateItem(Item item)
        {
            context.Items.Add(item);

        }

        public void EditItem(Item item) 
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void RemoveItem(int id) 
        {
            var data = context.Items.Find(id);
            if (data != null)
                context.Items.Remove(data);
        }


    }
}
