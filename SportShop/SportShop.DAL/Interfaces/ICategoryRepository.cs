using System.Collections.Generic;
using System.Data.Entity.Infrastructure;


namespace SportShop.DAL.Interfaces
{
    public interface ICategoryRepository<T> where T:class
    {
        T GetCategory(string category);
        IEnumerable<T> AllCategories();
        T CategoryFind(int id);
        IEnumerable<string> FindByNameItem(string category);

    }
}
