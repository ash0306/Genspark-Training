using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaShopContext _context;

        public UserRepository(PizzaShopContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == key);
            if( user == null) 
                throw new NoSuchUserException();
            return user;
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.Id);
            if (user != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchUserException();
        }
    }
}
