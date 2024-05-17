using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Intefaces
{
    public interface IRequestService
    {
        public Task<IEnumerable<Request>> GetAllUserRequests(int id);
        public Task<IEnumerable<Request>> GetAllAdminRequests();
        public Task<AddRequestReturnDTO> AddRequest(AddRequestReturnDTO addRequestReturnDTO);

    }
}
