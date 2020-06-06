
using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.Interfaces
{
    public interface IServiceDescription
    {
        IEnumerable<DescriptionItemDTO> GetAllDescription();
        DescriptionItemDTO GetDescriptionCategory(string category);
        void Dispose();
    }
}
