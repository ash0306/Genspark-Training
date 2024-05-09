using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        public Task<int> OpenRequest(Request request);
        public Task<bool> CloseRequest(int RequestId, Employee employee);
        public Task<bool> UpdateRequestStatus(int RequestId, string ReqStatus);
        public Task<IList<Request>> GetAllRequests();
        public Task<Request> GetRequestById(int RequestId);
    }
}
