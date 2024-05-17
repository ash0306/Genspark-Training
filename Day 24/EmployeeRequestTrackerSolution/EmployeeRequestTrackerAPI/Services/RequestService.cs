using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Intefaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _repository;

        public RequestService(IRepository<int, Request> repository)
        {
            _repository = repository;
        }

        public async Task<AddRequestReturnDTO> AddRequest(AddRequestReturnDTO addRequestReturnDTO)
        {
            try
            {
                Request request = MapRequestDTOToRequest(addRequestReturnDTO);
                var result = await _repository.Add(request);
                if(result == null)
                {
                    throw new UnableToAddRequestException("Unable to register!!");
                }
                return addRequestReturnDTO;
            }
            catch(Exception ex)
            {
                throw new UnableToAddRequestException("Unable to register!!");
            }
        }

        private Request MapRequestDTOToRequest(AddRequestReturnDTO addRequestReturnDTO)
        {
            Request request = new Request() { 
                RequestRaisedBy = addRequestReturnDTO.RequestReaisedBy,
                RequestDescription = addRequestReturnDTO.RequestDescription
            };
            return request;
        }

        public async Task<IEnumerable<Request>> GetAllAdminRequests()
        {
            try
            {
                var requests = (await _repository.Get())
                    .Where(r=>r.IsSolved == false)
                    .OrderBy(r => r.RequestRaisedOn)
                    .ToList();
                if (requests.Count == 0)
                    throw new NoSuchRequestException();
                return requests;
            }
            catch (Exception ex)
            {
                throw new NoSuchRequestException();
            }
        }

        public async Task<IEnumerable<Request>> GetAllUserRequests(int employeeId)
        {
            try
            {
                var requests = (await _repository.Get())
                    .Where(r => r.RequestRaisedBy == employeeId)
                    .ToList();
                if (requests.Count == 0)
                    throw new NoSuchRequestException();
                return requests;
            }
            catch (Exception ex)
            {
                throw new NoSuchRequestException();
            }
        }
    }
}
