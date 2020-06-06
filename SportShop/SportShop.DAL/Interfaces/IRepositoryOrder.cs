using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IRepositoryOrder<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        T GetOrder(string Email);
        void Update(T item);
    }
}
