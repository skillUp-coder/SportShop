using SportShop.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.WebUI.ViewModel
{
    public class CartSummaryViewModel
    {
        public ServiceCart Cart { get; set; }
        public string ReturnUrl { get; set; }

    }
}