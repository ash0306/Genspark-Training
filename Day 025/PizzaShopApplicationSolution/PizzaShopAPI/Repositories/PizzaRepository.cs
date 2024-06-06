using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Exceptions;

namespace PizzaShopAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaShopContext _context;

        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                _context.SaveChanges();
                return pizza;
            }
            throw new NoSuchPizzaException();
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            return pizzas;
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(e => e.Id == key);
            return pizza;
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.Id);
            if (pizza != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync();
                return pizza;
            }
            throw new NoSuchPizzaException();
        }
    }
}
