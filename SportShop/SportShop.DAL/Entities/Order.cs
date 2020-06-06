using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public decimal Total { get; set; }
        public string ColorItem { get; set; }
        public int SizeItem { get; set; }
        public List<DetailOrder> DetailOrder { get; set; }
    }
}
