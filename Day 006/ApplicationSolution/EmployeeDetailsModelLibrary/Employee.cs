using System.Xml.Linq;

namespace EmployeeDetailsModelLibrary
{
    public class Employee : IGovtRules
    {
        public string CompanyName { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Dept { get; set; }
        public string Desig { get; set; }
        public double BasicSalary { get; set; }
        public int WorkExp { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Employee()
        {
            EmpId = 0;
            EmpName = string.Empty;
            Dept = string.Empty;
            Desig = string.Empty;
            BasicSalary = 0.0;
            WorkExp = 0;
            CompanyName = string.Empty;
        }

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
        public Employee(int empId, string empName, string dept, string desig, double basicSalary, int workExp, string companyName)
        {
            EmpId = empId;
            EmpName = empName;
            Dept = dept;
            Desig = desig;
            BasicSalary = basicSalary;
            WorkExp = workExp;
            CompanyName = companyName;
        }

        /// <summary>
        /// Prints all the employee details
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + EmpId);
            Console.WriteLine("Employee Name : " + EmpName);
            Console.WriteLine("Employee Department : " + Dept);
            Console.WriteLine("Employee Designation : " + Desig);
            Console.WriteLine("Employee Salary : Rs." + BasicSalary);
            //Console.WriteLine("Employee PF : Rs." + )
        }

        /// <summary>
        /// Calculates the PF of the employee
        /// </summary>
        /// <returns></returns>
        public virtual double EmployeePF()
        {
            return BasicSalary;
        }

        /// <summary>
        /// Shows the leave details of the employee
        /// </summary>
        /// <returns></returns>
        public virtual string LeaveDetails()
        {
            return "";
        }

        /// <summary>
        /// Calculates the gratuity amount for the employee
        /// </summary>
        /// <returns></returns>
        public virtual double gratuityAmount()
        {
            return 0.0;
        }
    }
}
