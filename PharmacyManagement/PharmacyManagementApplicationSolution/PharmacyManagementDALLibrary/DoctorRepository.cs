using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementDALLibrary
{
    public class DoctorRepository:IRepository<int, Doctor>
    {
        private readonly Dictionary<int, Doctor> _doctors;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        /// <summary>
        /// Function to generate ID
        /// </summary>
        /// <returns></returns>
        private int GenerateId()
        {
            if (_doctors.Count == 0) return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Add a doctor
        /// </summary>
        /// <param name="item">doctor class object</param>
        /// <returns></returns>
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item)) return null;
            int id = GenerateId();
            item.DoctorId = id;
            _doctors.Add(id, item);
            return item;
        }

        /// <summary>
        /// Delete a doctor
        /// </summary>
        /// <param name="key">ID of the doctor to be deleted</param>
        /// <returns></returns>
        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var doctor = _doctors[key];
                _doctors.Remove(key);
                return doctor;
            }
            return null;
        }

        /// <summary>
        /// Display all doctors
        /// </summary>
        /// <returns></returns>
        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0) return null;
            return _doctors.Values.ToList();
        }

        /// <summary>
        /// Get details of 1 doctor
        /// </summary>
        /// <param name="key">ID of doctor to be fetched</param>
        /// <returns></returns>
        public Doctor GetByID(int key)
        {
            return _doctors.ContainsKey(key) ? _doctors[key] : null;
        }

        /// <summary>
        /// Update the details
        /// </summary>
        /// <param name="item">doctor class object</param>
        /// <returns></returns>
        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.DoctorId))
            {
                _doctors[item.DoctorId] = item;
                return item;
            }
            return null;
        }
    }
}
