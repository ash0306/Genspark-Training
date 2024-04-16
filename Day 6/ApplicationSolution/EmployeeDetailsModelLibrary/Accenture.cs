using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsModelLibrary
{
    public class Accenture : Employee
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
        public Accenture(int empId, string empName, string dept, string desig, double basicSalary, int workExp, string companyName) : base(empId, empName, dept, desig, basicSalary, workExp, companyName)
        {

        }

        /// <summary>
        /// Calculates the PF of the employee
        /// </summary>
        /// <returns></returns>
        public override double EmployeePF()
        {
            double EmployeePF = (BasicSalary * 12) / 100;
            double EmployerPF = (BasicSalary * 12) / 100;

            return (EmployeePF + EmployerPF);            
        }

        /// <summary>
        /// Calculates the gratuity amount for the employee
        /// </summary>
        /// <returns></returns>
        public override double gratuityAmount()
        {
            return 0.0;
        }

        /// <summary>
        /// Shows the leave details of the employee
        /// </summary>
        /// <returns></returns>
        public override string LeaveDetails()
        {
            return "Leave Details for Accenture is \n2 day of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Previlage Leave per year";

        }
    }
}
