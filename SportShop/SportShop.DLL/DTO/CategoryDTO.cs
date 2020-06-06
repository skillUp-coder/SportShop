using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DLL.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
    }
}
