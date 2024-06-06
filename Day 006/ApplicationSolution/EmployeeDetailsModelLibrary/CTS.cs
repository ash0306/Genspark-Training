using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsModelLibrary
{
    public class CTS : Employee
    {
        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="empId">Employee ID</param>
        /// <param name="empName">Employee Name as string</param>
        /// <param name="dept">Employee Department as String</param>
        /// <param name="desig">Employee Designation as string</param>
        /// <param name="basicSalary">Basic Salary of the Employee</param>
        /// <param name="workExp">Work experience of the employee as an integer</param>
        /// <param name="companyName">Name of the company of the employee</param>
        public CTS(int empId, string empName, string dept, string desig, double basicSalary, int workExp, string companyName) : base(empId, empName, dept, desig, basicSalary, workExp, companyName)
        {
        }

        /// <summary>
        /// Calculates the PF of the employee
        /// </summary>
        /// <returns></returns>
        public override double EmployeePF()
        {
            double EmployeePF = (BasicSalary * 12) / 100;
            double EmployerPF = (BasicSalary * 8.33) / 100;
            return (EmployerPF + EmployeePF);
        }

        /// <summary>
        /// Calculates the gratuity amount for the employee
        /// </summary>
        /// <returns></returns>
        public override double gratuityAmount()
        {
            double gratuity = 0.0;

            if (WorkExp < 5)
            {
                gratuity = 0.0;
            }
            else if (WorkExp > 5 && WorkExp < 10)
            {
                gratuity = BasicSalary;
            }
            else if (WorkExp > 10 && WorkExp < 20)
            {
                gratuity = 2 * BasicSalary;
            }
            else if (WorkExp > 20)
            {
                gratuity = 3 * BasicSalary;
            }

            return gratuity;
        }

        /// <summary>
        /// Shows the leave details of the employee
        /// </summary>
        /// <returns></returns>
        public override string LeaveDetails()
        {
            return "Leave Details for CTS is\n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year";

        }
    }
}
