using System.Runtime.Serialization;

namespace PizzaShopAPI.Exceptions
{
    [Serializable]
    internal class UnableToAddPizzaException : Exception
    {
        public UnableToAddPizzaException()
        {
        }

        public UnableToAddPizzaException(string? message) : base(message)
        {
        }

        public UnableToAddPizzaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToAddPizzaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}