using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartService
    {

        readonly IRepository<int, Cart> _cartRepository;
        readonly IRepository<int, CartItem> _cartItemRepository;
        readonly IRepository<int, Product> _productRepository;

        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;

        [ExcludeFromCodeCoverage]
        public CartBL(IProductService productService, ICartItemService cartItemService)
        {
            _cartRepository = new CartRepository();
            _productService = productService;
            _cartItemService = cartItemService;
        }

        [ExcludeFromCodeCoverage]
        public CartBL()
        {
            _cartRepository = new CartRepository();
        }
        [ExcludeFromCodeCoverage]
        public CartBL(IRepository<int, Cart> cartRepository, IRepository<int, CartItem> cartItemRepository, IRepository<int,Product> productRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;

        }
        [ExcludeFromCodeCoverage]
        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> AddCart(Cart cart)
        {
            ProcessCart(cart);

            Cart result = await _cartRepository.Add(cart);
            if(result == null)
            {
                throw new NoCartWithGivenIdException();
            }
            foreach(var cartItem in cart.CartItems)
            {
                cartItem.Product.QuantityInHand -= cartItem.Quantity;
                _productService.UpdateProduct(cartItem.Product);
            }
            return result;

        }

        public async Task<Cart> DeleteCart(int id)
        {
            var result = await _cartRepository.Delete(id);
            if(result != null)
            {
                return result;
            }
            foreach(var item in result.CartItems)
            {
                _cartItemService.DeleteCartItem(item.CartItemId);
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            var result = await _cartRepository.GetAll();
            if(result.Count != 0)
            {
                return (List<Cart>)result;
            }
            throw new NoCartWithGivenIdException() ;
        }

        public async Task<Cart> GetCartById(int id)
        {
            if(id == 0)
            {
                throw new NoCartWithGivenIdException();
            }
            var result = await _cartRepository.GetByKey(id);
            if(result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            ProcessCart(cart);
            var result = await _cartRepository.Update(cart);
            if(result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        [ExcludeFromCodeCoverage]
        private void ProcessCart(Cart cart)
        {
            double totalPrice = 0;
            foreach (var item in cart.CartItems)
            {
                totalPrice += item.Price;
            }

            if (totalPrice < 100)
            {
                totalPrice += 100; // shipping charge
            }

            if (cart.CartItems.Count == 3 && totalPrice >= 1500)
            {
                totalPrice -= totalPrice * 0.05; // 5% discount
            }

            foreach (var item in cart.CartItems)
            {
                if (item.Quantity > 5)
                {
                    throw new ArgumentException("Maximum quantity of product in cart should be less than 5");
                }
            }
            
            cart.TotalPrice = totalPrice;
        }
    }
}
