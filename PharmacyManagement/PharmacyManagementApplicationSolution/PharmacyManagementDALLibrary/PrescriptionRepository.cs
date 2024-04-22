using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementDALLibrary
{
    public class PrescriptionRepository : IRepository<int, Prescription>
    {
        private readonly Dictionary<int, Prescription> _prescriptions;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrescriptionRepository()
        {
            _prescriptions = new Dictionary<int, Prescription>();
        }

        /// <summary>
        /// Function to generate ID
        /// </summary>
        /// <returns></returns>
        private int GenerateId()
        {
            if (_prescriptions.Count == 0) return 1;
            int id = _prescriptions.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Add a prescription
        /// </summary>
        /// <param name="item">prescription class object</param>
        /// <returns></returns>
        public Prescription Add(Prescription item)
        {
            if (_prescriptions.ContainsValue(item)) return null;
            int id = GenerateId();
            item.PrescriptionId = id;
            _prescriptions.Add(id, item);
            return item;
        }

        /// <summary>
        /// Delete a prescription
        /// </summary>
        /// <param name="key">ID of the prescription to be deleted</param>
        /// <returns></returns>
        public Prescription Delete(int key)
        {
            if (_prescriptions.ContainsKey(key))
            {
                var prescription = _prescriptions[key];
                _prescriptions.Remove(key);
                return prescription;
            }
            return null;
        }

        /// <summary>
        /// Display all prescriptions
        /// </summary>
        /// <returns></returns>
        public List<Prescription> GetAll()
        {
            if (_prescriptions.Count == 0) return null;
            return _prescriptions.Values.ToList();
        }

        /// <summary>
        /// Get details of 1 prescription
        /// </summary>
        /// <param name="key">ID of prescription to be fetched</param>
        /// <returns></returns>
        public Prescription GetByID(int key)
        {
            return _prescriptions.ContainsKey(key) ? _prescriptions[key] : null;
        }

        /// <summary>
        /// Update the details
        /// </summary>
        /// <param name="item">prescription class object</param>
        /// <returns></returns>
        public Prescription Update(Prescription item)
        {
            if (_prescriptions.ContainsKey(item.PrescriptionId))
            {
                _prescriptions[item.PrescriptionId] = item;
                return item;
            }
            return null;
        }
    }
}
