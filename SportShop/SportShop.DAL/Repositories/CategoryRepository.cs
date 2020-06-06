using SportShop.DAL.EF;
using SportShop.DAL.Entities;
using SportShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace SportShop.DAL.Repositories
{
    public class CategoryRepository: ICategoryRepository<Category>
    {
        private DatabaseContext context;
        public CategoryRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> AllCategories()
        {
            return context.Categories.ToList();
        }

        public Category CategoryFind(int id)
        {
            return context.Categories.Find(id);
        }
        public Category GetCategory(string category) 
        {
            var _category = context.Categories.Include(x=>x.Items).Single(x=>x.Name == category);
            return _category;
        }
        public IEnumerable<string> FindByNameItem(string category) 
        {
            return context.Categories.Include(x => x.Items).Single(x => x.Name == category).Items.Select(x=>x.ItemName).Distinct();
            
        }
    }
}
