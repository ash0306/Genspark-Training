using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        private readonly PizzaShopContext _context;

        public OrderRepository(PizzaShopContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order item)
        {
            if(item == null)
            {
                throw new NoSuchOrderException();
            }
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Order> Delete(int key)
        {
            var order = await Get(key);
            if (order != null)
            {
                _context.Remove(order);
                _context.SaveChanges();
                return order;
            }
            throw new NoSuchOrderException();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            if (orders == null)
            {
                throw new NoSuchOrderException();
            }
            return orders;
        }

        public async Task<Order> Get(int key)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(e => e.Id == key);
            if (order == null)
            {
                throw new NoSuchOrderException();
            }
            return order;
        }

        public async Task<Order> Update(Order item)
        {
            var order = await Get(item.Id);
            if (order != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync();
                return order;
            }
            throw new NoSuchOrderException();
        }
    }
}
