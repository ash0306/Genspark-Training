using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    internal class Employee
    {
        double salary;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Salary 
        {
            get
            {
                return (salary - (salary * 10) / 100);
            }
            set
            {
                salary = value;
            }
        }

        public string Department { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Salary = 0;
            Department = string.Empty;
        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">EMployee name as String</param>
        /// <param name="dateOfBirth">Employee DOB</param>
        /// <param name="salary">Employee Salary</param>
        /// <param name="department">Employee Department as string</param>
        public Employee(int id, string name, DateTime dateOfBirth, double salary, string department)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
            Department = department;
        }
        /// <summary>
        /// Prints all the Employee Details
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee ID:\t{Id}");
            Console.WriteLine($"Employee Name:\t{Name}");
            Console.WriteLine($"Employee Salary:\t{Salary}");
            Console.WriteLine($"Employee DOB:\t{DateOfBirth}");
            Console.WriteLine($"Employee Department:\t{Department}");
        }
    }
}
