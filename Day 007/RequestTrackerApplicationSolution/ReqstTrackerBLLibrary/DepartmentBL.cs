using RequestTrackerDALLibrary;
//using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary.Model;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentrepository)
        {
            _departmentRepository = departmentrepository;
        }

        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int? AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department UpdateDepartment(int id)
        {
            Department department = GetDepartmentById(id);
            Console.WriteLine("Enter department Name:");
            department.Name = Console.ReadLine();
            Console.WriteLine("Enter department head ID:");
            department.DepartmentHead = Convert.ToInt32(Console.ReadLine());
            return _departmentRepository.Update(department);
        }

        public Department GetDepartmentById(int id)
        {
            var result = _departmentRepository.GetByID(id);
            if(result != null)
            {
                return result;
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = _departmentRepository.GetAll().Find(d => d.Name == departmentName);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            return department;
        }

        public int? GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.GetByID(departmentId);
            if(department != null)
            {
                return department.DepartmentHead;
            }
            throw new DepartmentNotFoundException();
        }

        public List<Department> GetDepartmentList()
        {
            var departments = _departmentRepository.GetAll();
            if (departments == null)
            {
                throw new DepartmentNotFoundException();
            }
            return departments;
        }

        public bool DeleteDepartment(int departmentId)
        {
            var result = _departmentRepository.Delete(departmentId);
            if(result != null)
            {
                return true;
            }
            throw new DepartmentNotFoundException();
        }
    }
}
