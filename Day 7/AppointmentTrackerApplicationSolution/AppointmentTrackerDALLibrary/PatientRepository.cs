using AppointmentTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patients;
        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }
        int GenerateID()
        {
            if (_patients.Count == 0)
                return 1;
            int id = _patients.Keys.Max();
            return id++;
        }
        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
                return null!;
            _patients.Add(GenerateID(), item);
            return item;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var doctor = _patients[key];
                _patients.Remove(key);
                return doctor;
            }
            return null!;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null!;
            return _patients.Values.ToList();
        }

        public Patient GetByID(int key) => _patients.ContainsKey(key) ? _patients[key] : null!;

        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.PatientId))
            {
                _patients[item.PatientId] = item;
                return item;
            }
            return null!;
        }
    }
}
