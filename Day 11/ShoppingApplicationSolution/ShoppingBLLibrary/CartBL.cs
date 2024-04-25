using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartService
    {

        readonly IRepository<int, Cart> _cartRepository;

        [ExcludeFromCodeCoverage]
        public CartBL()
        {
            _cartRepository = new CartRepository();
        }
        [ExcludeFromCodeCoverage]
        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart AddCart(Cart cart)
        {
            ProcessCart(cart);
            Cart result = _cartRepository.Add(cart);
            if(result != null)
            {
                return result;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart DeleteCart(int id)
        {
            var result = _cartRepository.Delete(id);
            if(result != null)
            {
                return result;
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
                totalPrice += item.Price * item.Quantity;
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
