using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Intefaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
