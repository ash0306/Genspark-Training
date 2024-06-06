using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        Task<Cart> AddCart(Cart cart);
        Task<Cart> GetCartById(int id);
        Task<List<Cart>> GetAllCarts();
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> DeleteCart(int id);
    }
}
