using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerDALLibrary.Model;

namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        dbRequestTrackerContext context = new dbRequestTrackerContext();
        private List<Department> _departments;
        public DepartmentRepository()
        {
            _departments = context.Departments.ToList();
        }

        int GenerateId()
        {
            if (_departments.Count == 0)
            {
                return 1;
            }
            int id = _departments.Count;
            return ++id;
        }

        public Department Add(Department item)
        {
            context.Departments.Add(item);
            context.SaveChanges();
            _departments = context.Departments.ToList();
            if(_departments.Contains(item)) return item;
            return null;
        }

        public Department Delete(int key)
        {
            _departments = context.Departments.ToList();
            var department = _departments.SingleOrDefault(d => d.Id == key);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                _departments = context.Departments.ToList();
                return department;
            }
            return null;
        }

        public List<Department> GetAll()
        {
            if (_departments.Count == 0)
                return null;
            return _departments;
        }

        public Department GetByID(int key)
        {
            var department = _departments.SingleOrDefault(d => d.Id == key);
            if (department != null)
            {
                return department;
            }
            return null;
        }

        public Department Update(Department item)
        {
            _departments = context.Departments.ToList();
            var department = _departments.SingleOrDefault(d => d.Id == item.Id);
            if (department != null)
            {
                department = item;
                context.Departments.Update(department);
                context.SaveChanges();
                _departments = context.Departments.ToList();
                return department;
            }
            return null;
        }
    }
}
