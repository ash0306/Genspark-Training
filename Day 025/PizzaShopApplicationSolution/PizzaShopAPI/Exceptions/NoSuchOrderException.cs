using System.Runtime.Serialization;

namespace PizzaShopAPI.Exceptions
{
    [Serializable]
    internal class NoSuchOrderException : Exception
    {
        string msg;
        public NoSuchOrderException()
        {
            msg = "No such order found!!";
        }

        public override string Message => msg;
        public NoSuchOrderException(string? message) : base(message)
        {
        }

    }
}