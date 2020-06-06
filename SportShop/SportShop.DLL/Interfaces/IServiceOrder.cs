using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Interfaces
{
    public interface IServiceOrder
    {
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetOrder(int? id);
        void CreateOrder(OrderDTO order);
        void Dispose();

    }
}
