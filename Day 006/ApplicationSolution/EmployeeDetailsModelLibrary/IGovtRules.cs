using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsModelLibrary
{
    public interface IGovtRules
    {
        public double EmployeePF();
        public string LeaveDetails();
        public double gratuityAmount();
    }
}
