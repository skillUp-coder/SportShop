using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IRepositoryDescription<T> where T:class
    {
        IEnumerable<T> GetDescriptions();
        T GetDescription(string category);
    }
}
