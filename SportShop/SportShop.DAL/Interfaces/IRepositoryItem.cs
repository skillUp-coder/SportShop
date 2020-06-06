using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IRepositoryItem<T>where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        int Count(string category);
        int MatchingCategories(string name, string category);
        IEnumerable<string> FindByCategoryName();
        decimal FindByCost();
        IEnumerable<T> GetDatasMatchingCategories(int page, int PageSize, string name, string category);
        IEnumerable<T> GetSortedDatas(string category);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
