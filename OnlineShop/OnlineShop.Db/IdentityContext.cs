using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Helper;
using OnlineShop.Db.Models;
using System.Linq;
using Image = OnlineShop.Db.Models.Image;

namespace OnlineShop.Db
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductsImages> ImagesProducts { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Product>()
            //       .HasMany(p => p.Images)
            //       .WithMany(i => i.Products)
            //       .UsingEntity<ProductsImages>(
            //           pi => pi.HasOne(prop => prop.Image).WithMany().HasForeignKey(prop => prop.ImageId),
            //           pi => pi.HasOne(prop => prop.Product).WithMany().HasForeignKey(prop => prop.ProductId),
            //           pi => pi.HasKey(prop => new { prop.ImageId, prop.ProductId})
            //           );

            builder.Entity<ProductsImages>()
                .HasKey(x => new {x.ProductId, x.ImageId});
            builder.Entity<ProductsImages>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId);
            builder.Entity<ProductsImages>()
                .HasOne(x => x.Image)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ImageId);
            //builder.Entity<Image>().HasData(ProductGenerator.GenerateImages());
            //builder.Entity<Product>().HasData(ProductGenerator.GenerateProducts());
            //builder.Entity<ProductsImages>().HasData(ProductGenerator.GenerateProductsImages());
            base.OnModelCreating(builder);
        }
    }
}