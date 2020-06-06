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
    public class RepositoryItem : IRepositoryItem<Item>
    {
        DatabaseContext context;
        public RepositoryItem(DatabaseContext context)
        {
            this.context = context; 
        }

        public int Count(string category)
        {
            return context.Items.Where(x=>x.ItemCategory == category).Count();
        }

        public void Create(Item item)
        {
            context.Items.Add(item);
        }

        public void Delete(int id)
        {
            var data = context.Items.Find(id);
            if (data != null)
                context.Items.Remove(data);
        }

        public IEnumerable<Item> Find(Func<Item, bool> predicate)
        {
            return context.Items.Where(predicate).ToList();
        }

        public IEnumerable<string> FindByCategoryName()
        {
            return context.Items.Select(x => x.ItemName).Distinct();
        }

        public decimal FindByCost()
        {
            return context.Items.Select(x => x.Price).FirstOrDefault();
        }

        public Item Get(int id)
        {
            return context.Items.Find(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return context.Items;
        }

        public IEnumerable<Item> GetDatasMatchingCategories(int page, int PageSize, string name ,string category)
        {
            return context.Items.Where(x=>x.ItemCategory == category).Where(x => name == null || x.ItemName == name).OrderBy(x => x.Price).Skip((page - 1) * PageSize).Take(PageSize);
        }

        public IEnumerable<Item> GetSortedDatas(string category)
        {
            return context.Items.Where(x=>x.ItemCategory == category).OrderByDescending(x => x.Price);
        }

        public int MatchingCategories(string name ,string category)
        {
            return context.Items.Where(x => x.ItemCategory == category).Where(x=>x.ItemName == name).Count();
        }

        public void Update(Item item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
