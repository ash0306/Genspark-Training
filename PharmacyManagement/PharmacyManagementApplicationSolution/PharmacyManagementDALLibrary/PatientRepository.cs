using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly Dictionary<int, Patient> _patients;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }

        /// <summary>
        /// Function to generate ID
        /// </summary>
        /// <returns></returns>
        private int GenerateId()
        {
            if (_patients.Count == 0) return 1;
            int id = _patients.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Add a patient
        /// </summary>
        /// <param name="item">patient class object</param>
        /// <returns></returns>
        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item)) return null;
            int id = GenerateId();
            item.PatientId = id;
            _patients.Add(id, item);
            return item;
        }

        /// <summary>
        /// Delete a patient
        /// </summary>
        /// <param name="key">ID of the patient to be deleted</param>
        /// <returns></returns>
        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var patient = _patients[key];
                _patients.Remove(key);
                return patient;
            }
            return null;
        }

        /// <summary>
        /// Display all patients
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetAll()
        {
            if (_patients.Count == 0) return null;
            return _patients.Values.ToList();
        }

        /// <summary>
        /// Get details of 1 patient
        /// </summary>
        /// <param name="key">ID of patient to be fetched</param>
        /// <returns></returns>
        public Patient GetByID(int key)
        {
            return _patients.ContainsKey(key) ? _patients[key] : null;
        }

        /// <summary>
        /// Update the details
        /// </summary>
        /// <param name="item">patient class object</param>
        /// <returns></returns>
        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.PatientId))
            {
                _patients[item.PatientId] = item;
                return item;
            }
            return null;
        }
    }
}
