using EmployeeTracker.Models;
namespace EmployeeTracker
{
    internal class Program
    {
        Employee CreateEmployeeByTakingDetails()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee ID:");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            employee.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Employee Date Of Birth:");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Employee Salary:");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            employee.Salary = salary;
            Console.WriteLine("Enter Employee Department:");
            employee.Department = Console.ReadLine() ?? "";

            return employee;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int numOfEntries;
            Console.WriteLine("Enter the number of entries you want to add:");
            numOfEntries = Convert.ToInt32(Console.ReadLine());

            Employee[] employees = new Employee[numOfEntries];

            for (int i = 0; i < numOfEntries; i++)
            {
                employees[i] = program.CreateEmployeeByTakingDetails();
            }

            for (int i = 0; i<numOfEntries; i++)
            {
                employees[i].PrintEmployeeDetails();
            }
        }
    }
}
