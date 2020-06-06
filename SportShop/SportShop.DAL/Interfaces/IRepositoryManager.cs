using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IRepositoryManager<T> where T:class
    {
        void RemoveItem(int id);
        void EditItem(T item);
        void CreateItem(T item);
        T GetItem(int id);
        IEnumerable<T> GetItems();
    }
}
