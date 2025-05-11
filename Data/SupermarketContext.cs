using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;

namespace SupermarketWEB.Data
{
    // 1 referencia
    public class SupermarketContext : DbContext
    {
        // 0 referencias
        public SupermarketContext(DbContextOptions options) : base(options)
        {
        }

        // 0 referencias
        public DbSet<Product> Products { get; set; }
        // 0 referencias
        public DbSet<Category> Categories { get; set; }

        public DbSet<Providers> Providers { get; set; }

        public DbSet<PayMode> PayModes { get; set; }
    }
}
