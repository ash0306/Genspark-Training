using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int, Request> _repository;
        public RequestBL()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<int> OpenRequest(Request request)
        {
            request.RequestStatus = "Open";
            var result = await _repository.Add(request);
            return result.RequestNumber;
        }

        public async Task<bool> CloseRequest(int RequestId, Employee employee)
        {
            var request = await _repository.Get(RequestId);
            if(request == null)
            {
                return false;
            }
            request.ClosedDate = DateTime.Now;
            request.RequestClosedBy = employee.Id;
            //request.RequestClosedByEmployee = employee;
            request.RequestStatus = "Closed";
            var req = await _repository.Update(request);
            return true;
        }
        public async Task<bool> UpdateRequestStatus(int RequestId, string ReqStatus)
        {
            var request = await _repository.Get(RequestId);
            if (request == null)
            {
                return false;
            }
            request.RequestStatus = ReqStatus;
            var req = await _repository.Update(request);
            return true;
        }

        public async Task<IList<Request>> GetAllRequests()
        {
            IList<Request> requests = await _repository.GetAll();
            if(requests.Count == 0)
            {
                return null;
            }
            return requests;
        }

        public async Task<Request> GetRequestById(int RequestId)
        {
            Request request = await _repository.Get(RequestId);
            return request;
        }
    }
}
