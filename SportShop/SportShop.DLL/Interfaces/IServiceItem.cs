using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Interfaces
{
    public interface IServiceItem
    {
        void CreateItem(ItemDTO itemDTO);
        ItemDTO GetItem(int? id);
        IEnumerable<ItemDTO> GetItems();
        IEnumerable<ItemDTO> DatasMatchingCategories(int page, int PageSize, string name, string category);
        IEnumerable<ItemDTO> SortedDatas(string category);
        IEnumerable<string> GetByCategoryName();
        decimal GetByCost();
        int Count(string name, string Category);
        void Dispose();
    }
}
