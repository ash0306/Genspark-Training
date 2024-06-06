using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary.Exceptions
{
    public class NotFoundException:Exception
    {
        string msg;
        public NotFoundException(string content)
        {
            msg = content + " doesn't exist";
        }
        public override string Message => msg;
    }
}
