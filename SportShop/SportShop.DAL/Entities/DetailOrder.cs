using System.ComponentModel.DataAnnotations;

namespace SportShop.DAL.Entities
{
    public class DetailOrder
    {
        [Key]
        public int DetailOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        public int ItemId { get; set; }
        public virtual Item  Item { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}