using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary.Exceptions
{
    public class DuplicateFoundException : Exception
    {
        string msg;
        public DuplicateFoundException(string content)
        {
            msg = content + " with the specified name already exists";
        }
        public override string Message => msg;
    }
}
