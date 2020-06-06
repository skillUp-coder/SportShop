using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Interfaces
{
    public interface IServiceManager
    {
        void GerRemoveItem(int? id);
        IEnumerable<ItemManager> GetAllItems();
        ItemManager GetItem(int? id);
        void GetCreateItem(ItemManager item);
        void GetEditItem(ItemManager item);
        void Dispose();
    }
}
