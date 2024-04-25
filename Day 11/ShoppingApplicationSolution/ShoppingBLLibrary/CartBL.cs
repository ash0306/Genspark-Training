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

        public Cart AddCart(Cart cart)
        {
            //List<CartItem> cartItems = (List<CartItem>)_cartItemRepository.GetAll().Where(item => item.CartId==cart.Id);
            //cart.CartItems = cartItems;

            ProcessCart(cart);

            Cart result = _cartRepository.Add(cart);
            if(result == null)
            {
                throw new NoCartWithGivenIdException();
            }
            foreach(var cartItem in cart.CartItems)
            {
                cartItem.Product.QuantityInHand -= cartItem.Quantity;
                //_productRepository.Update(cartItem.Product);
            }
            return result;

        }

        public Cart DeleteCart(int id)
        {
            var result = _cartRepository.Delete(id);
            if(result != null)
            {
                return result;
            }
            foreach(var item in result.CartItems)
            {
                //_cartItemRepository.Delete(item.CartItemId);
            }
            throw new NoCartWithGivenIdException();
        }

        public List<Cart> GetAllCarts()
        {
            var result = _cartRepository.GetAll();
            if(result.Count != 0)
            {
                return (List<Cart>)result;
            }
            throw new NoCartWithGivenIdException() ;
        }

        public Cart GetCartById(int id)
        {
            if(id == 0)
            {
                throw new NoCartWithGivenIdException();
            }
            var result = _cartRepository.GetByKey(id);
            if(result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart UpdateCart(Cart cart)
        {
            ProcessCart(cart);
            var result = _cartRepository.Update(cart);
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
