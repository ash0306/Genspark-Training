using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGiveIdException : Exception
    {
        string message;
        [ExcludeFromCodeCoverage]
        public NoCustomerWithGiveIdException()
        {
            message = "Customer with the given Id is not present";
        }
        public override string Message => message;
    }
}
