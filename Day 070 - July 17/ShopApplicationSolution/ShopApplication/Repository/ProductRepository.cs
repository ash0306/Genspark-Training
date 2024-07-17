using Microsoft.EntityFrameworkCore;
using ShopApplication.Contexts;
using ShopApplication.Models;

namespace ShopApplication.Repository
{
    public class ProductRepository : IRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }

}
