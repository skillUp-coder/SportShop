using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportShop.WebUI.ViewModel
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }

        public decimal Price { get; set; }

        public string ItemName { get; set; }

        public string ItemCategory { get; set; }
        public int DescriptionItemId { get; set; }

        public string ItemArtUrl1 { get; set; }
        public string ItemArtUrl2 { get; set; }
        public string ItemArtUrl3 { get; set; }
        public string ItemArtUrl4 { get; set; }
        public string ItemArtUrl5 { get; set; }
        public int CategoryId { get; set; }
        public string ColorItem { get; set; }
    }
}