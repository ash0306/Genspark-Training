using EmployeeDetailsModelLibrary;

namespace EmployeeDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Accenture accenture1 = new Accenture(101, "Ash", "AppDev", "Intern", 10000, 12, "Accenture");
            CTS cts1 = new CTS(201, "Neil", "Testing", "Intern", 120000, 20, "CTS");
            accenture1.PrintEmployeeDetails();
            cts1.PrintEmployeeDetails();
            
            Company company = new Company();
            Console.WriteLine("Govt Rules for Accenture:");
            company.CompanyGovtRules(accenture1);
            Console.WriteLine("Govt Rules for CTS:");
            company.CompanyGovtRules(cts1);

        }
    }
}
