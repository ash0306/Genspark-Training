using AppointmentTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        dbAppointmentTrackerContext context = new dbAppointmentTrackerContext();
        private List<Patient> _patients;
        public PatientRepository()
        {
            _patients = context.Patients.ToList();
        }
        //int GenerateID()
        //{
        //    if (_patients.Count == 0)
        //        return 1;
        //    int id = _patients.Keys.Max();
        //    return ++id;
        //}
        public Patient Add(Patient item)
        {
            context.Patients.Add(item);
            context.SaveChanges();
            _patients = context.Patients.ToList();
            if (_patients.Contains(item)) return item;
            return null;
        }

        public Patient Delete(int key)
        {
            _patients = context.Patients.ToList();
            var patient = _patients.SingleOrDefault(p=>p.PatientId == key);
            if(patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
                _patients = context.Patients.ToList();
                return patient;
            }
            return null;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null!;
            return _patients;
        }

        public Patient GetByID(int key)
        {
            var patient = _patients.SingleOrDefault(p => p.PatientId == key);
            if(patient != null)
            {
                return patient;
            }
            return null;
        }

        public Patient Update(Patient item)
        {
            _patients = context.Patients.ToList();
            var patient = _patients.SingleOrDefault(d => d.PatientId == item.PatientId);
            if (patient != null)
            {
                patient = item;
                context.Patients.Update(patient);
                context.SaveChanges();
                _patients = context.Patients.ToList();
                return patient;
            }
            return null;
        }
    }
}
