using System;

namespace SportShop.DLL.DTO
{
    public class OrderDTO
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
    }
}
