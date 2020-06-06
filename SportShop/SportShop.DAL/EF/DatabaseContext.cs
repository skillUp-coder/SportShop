using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connection) : base(connection) { }

        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new InitializerDatabaseContext());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<DescriptionItem> DescriptionItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
