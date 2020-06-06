using System.Collections.Generic;



namespace SportShop.DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
