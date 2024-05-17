using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Intefaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<Request> Get(int key)
        {
            var request = _context.Requests
                //.Include(r=>r.RequestRaisedByEmployee)
                //.Include(r=>r.RequestClosedByEmployee)
                .SingleOrDefault(r => r.Id == key);
            return request;
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return await _context.Requests
                //.Include(r => r.RequestRaisedByEmployee)
                //.Include(r => r.RequestClosedByEmployee)
                .ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.Id);
            if (request != null)
            {
                _context.Entry<Request>(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return request;
        }
    }
}
