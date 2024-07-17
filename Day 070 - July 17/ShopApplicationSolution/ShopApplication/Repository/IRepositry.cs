using ShopApplication.Models;

namespace ShopApplication.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }

}
