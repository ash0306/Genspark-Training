using System.Runtime.Serialization;

namespace PizzaShopAPI.Exceptions
{
    [Serializable]
    internal class NoSuchPizzaException : Exception
    {
        string message;
        public NoSuchPizzaException()
        {
            message = "No such Pizza found";
        }
        public override string Message => message;
        public NoSuchPizzaException(string? message) : base(message)
        {
        }
    }
}