using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.DTO
{
    public class DescriptionItemDTO
    {
        public int DescriptionItemId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
