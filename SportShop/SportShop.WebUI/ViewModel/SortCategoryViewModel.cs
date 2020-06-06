using SportShop.DAL.Entities;
using SportShop.DLL.DTO;
using SportShop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.WebUI.ViewModel
{
    public class SortCategoryViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
        public InfoOfPage Info { get; set; }
        public string CurrentCategory { get; set; }
        public CategoryDTO CategoryModel { get; set; }
        public DescriptionItemDTO DescriptionModel { get; set; }
    }
}