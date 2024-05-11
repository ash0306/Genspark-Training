using AppointmentTrackerDALLibrary;
using AppointmentTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {

        dbAppointmentTrackerContext context = new dbAppointmentTrackerContext();
        private List<Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = context.Doctors.ToList();
        }

        public Doctor Add(Doctor item)
        {
            context.Doctors.Add(item);
            context.SaveChanges();
            _doctors = context.Doctors.ToList();
            if (_doctors.Contains(item))
                return item;
            return null;
        }

        public Doctor Delete(int key)
        {
            var department = _doctors.SingleOrDefault(d => d.DoctorId == key);
            if (department != null)
            {
                context.Doctors.Remove(department);
                context.SaveChanges();
                _doctors = context.Doctors.ToList();
                return department;
            }
            return null!;
        }

        public Doctor GetByID(int key)
        {

            var doctor = _doctors.SingleOrDefault(d => d.DoctorId == key);
            if (doctor != null)
            {
                return doctor;
            }
            return null;

        }

        public List<Doctor> GetAll()
        {
            var list = context.Doctors.ToList();
            if (list.Count == 0)
                return null;

            return list;
        }

        public Doctor Update(Doctor item)
        {
            var doctor = _doctors.SingleOrDefault(d => d.DoctorId == item.DoctorId);
            if (doctor != null)
            {
                doctor = item;
                context.Doctors.Update(doctor);
                context.SaveChanges();
                return doctor;
            }
            return null;
        }

        //private int GenerateId()
        //{
        //    return _doctors.Count == 0 ? 1 : _doctors.Keys.Max() + 1;
        //}

    }
}
