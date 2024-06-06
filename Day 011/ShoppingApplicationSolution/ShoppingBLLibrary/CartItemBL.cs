using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartItemBL : ICartItemService
    {
        readonly IRepository<int, CartItem> _cartItemRepository;
        [ExcludeFromCodeCoverage]
        public CartItemBL()
        {
            _cartItemRepository = new CartItemRepository();
        }
        [ExcludeFromCodeCoverage]
        public CartItemBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<int> AddCartItem(CartItem cartItem)
        {
            ProcessCartItem(cartItem);
            CartItem result = await _cartItemRepository.Add(cartItem);
            if (result != null)
            {
                return result.ProductId;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<CartItem> DeleteCartItem(int id)
        {
            var result = await _cartItemRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<List<CartItem>> GetAllCartItems()
        {
            var result = await _cartItemRepository.GetAll();
            if (result.Count != 0)
            {
                return (List<CartItem>)result;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<CartItem> GetCartItemById(int id)
        {
            var result = await _cartItemRepository.GetByKey(id);
            if (result != null)
            {
                return result;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public async Task<CartItem> UpdateCartItem(CartItem CartItem)
        {
            ProcessCartItem(CartItem);
            var result = await _cartItemRepository.Update(CartItem);
            if (result != null)
            {
                return result;
            }
            throw new NoCartItemWithGivenIdException();
        }


        [ExcludeFromCodeCoverage]
        public void ProcessCartItem(CartItem cartItem)
        {
            if(cartItem.Quantity > 5)
            {
                throw new ArgumentException("Maximum quantity of product in cart should be less than 5");
            }
        }
    }
}
