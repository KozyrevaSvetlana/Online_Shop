using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(b => b.UserContacts)
                .WithOne(i => i.Order)
                .HasForeignKey<UserContact>(b => b.OrderId);
                for (int i = 0; i < 20; i++)
            {
                modelBuilder.Entity<Product>()
                .HasData(ProductGenerator.GeneradeRandomProduct());
            };
        }
    }
}
