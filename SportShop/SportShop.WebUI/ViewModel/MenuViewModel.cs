using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.WebUI.ViewModel
{
    public class MenuViewModel
    {
        public IEnumerable<string> CategoryName { get; set; }
        public CategoryDTO GetCategory { get; set; }
    }
}