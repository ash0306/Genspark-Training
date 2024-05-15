using System.Runtime.Serialization;

namespace PizzaShopAPI.Exceptions
{
    [Serializable]
    internal class NoSuchUserException : Exception
    {
        string msg;
        public NoSuchUserException()
        {
            msg = "No such User found!!";
        }
        public override string Message => msg;
        public NoSuchUserException(string? message) : base(message)
        {
        }

    }
}