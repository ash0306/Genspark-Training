using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Intefaces
{
    public interface IEmployeeService
    {
        public Task<Employee> GetEmployeeByPhone(string phoneNumber);
        public Task<Employee> UpdateEmployeePhone(int id, string phoneNumber);
        public Task<IEnumerable<Employee>> GetEmployees();

    }
}
