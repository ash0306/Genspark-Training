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
        int AddCart(Cart cart);
        Cart GetCartById(int id);
        List<Cart> GetAllCarts();
        Cart UpdateCart(Cart cart);
        Cart DeleteCart(int id);
    }
}
