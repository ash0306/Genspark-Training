using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;

namespace ShopApplication.Contexts
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id=101, ImageUrl= "https://shopappaswathi.blob.core.windows.net/products/fourth-wing.jpg", Name="Fourth Wing", Price=220 },
                new Product() { Id=102, ImageUrl= "https://shopappaswathi.blob.core.windows.net/products/howl.jpg", Name="Howl's Moving Castle", Price=150 }
                );
        }
    }
}
