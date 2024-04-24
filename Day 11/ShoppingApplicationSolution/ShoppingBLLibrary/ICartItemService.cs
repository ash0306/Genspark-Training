using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartItemService
    {
        int AddCartItem(CartItem cartItem);
        CartItem GetCartItemById(int id);
        List<CartItem> GetAllCartItems();
        CartItem UpdateCartItem(CartItem cartItem);
        CartItem DeleteCartItem(int id);
    }
}
