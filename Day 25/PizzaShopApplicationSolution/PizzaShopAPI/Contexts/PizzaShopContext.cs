using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Contexts
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 101, Name = "Veggie Overload", Description = "", QuantityInStock = 10, type = "Veg", price = 120},
                new Pizza() { Id = 102, Name = "Pepporoni", Description = "", QuantityInStock = 15, type = "Non-veg", price = 150 },
                new Pizza() { Id = 103, Name = "Italian Sausage", Description = "", QuantityInStock = 5, type = "Non-veg", price = 180 }
                );
        }
    }
}
