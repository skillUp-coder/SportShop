using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Interfaces
{
    public interface IServiceCatogory
    {
        IEnumerable<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategory(string category);
        CategoryDTO GetCategoryFind(int? id);
        IEnumerable<string> GetFindByNameItem(string category);
        void Dispose();
    }
}
