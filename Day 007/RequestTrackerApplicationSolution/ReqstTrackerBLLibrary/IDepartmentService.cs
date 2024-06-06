//using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary.Model;

namespace RequestTrackerBLLibrary
{
    public interface IDepartmentService
    {
        int? AddDepartment(Department department);
        Department UpdateDepartment(int id);
        Department GetDepartmentById(int id);
        Department GetDepartmentByName(string departmentName);
        int? GetDepartmentHeadId(int departmentId);
        List<Department> GetDepartmentList();
        bool DeleteDepartment(int departmentId);
    }
}