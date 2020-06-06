using SportShop.DAL.Entities;
using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.WebUI.ViewModel
{
    public class CategoryViewModel
    {
        public CategoryDTO Category { get; set; }
        public List<Item> Items { get; set; }
    }
}