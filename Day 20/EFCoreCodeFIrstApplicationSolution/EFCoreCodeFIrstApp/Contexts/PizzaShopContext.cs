using EFCoreCodeFIrstApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFIrstApp.Contexts
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JHII9TQ\\DEMOINSTANCE;Integrated Security=True;Initial Catalog=dbPizzaShop;");
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
