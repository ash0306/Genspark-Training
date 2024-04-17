using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace ReqstTrackerBLLibrary
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

    }
}
