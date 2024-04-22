using PharmacyManagementBLLibrary.Exceptions;
using PharmacyManagementDALLibrary;
using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public class PatientBL : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PatientBL()
        {
            _patientRepository = new PatientRepository();
        }

        /// <summary>
        /// Adds a patient
        /// </summary>
        /// <param name="Patient">Patient class object</param>
        /// <returns></returns>
        /// <exception cref="DuplicateFoundException"></exception>
        public int AddPatient(Patient Patient)
        {
            var result = _patientRepository.Add(Patient);
            if (result != null)
            {
                return result.PatientId;
            }
            throw new DuplicateFoundException("Patient");
        }

        /// <summary>
        /// Delete a patient
        /// </summary>
        /// <param name="id">ID od the patient to be deleted</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public int DeletePatient(int id)
        {
            var result = _patientRepository.Delete(id);
            if (result != null)
            {
                return result.PatientId;
            }
            throw new NotFoundException("Patient");
        }

        /// <summary>
        /// Get a list of all the patients
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = _patientRepository.GetAll();
            if (patients.Count == 0)
            {
                throw new NotFoundException("Patient");
            }
            return patients;
        }

        /// <summary>
        /// Get patient details using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Patient GetPatientByID(int id)
        {
            var result = _patientRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Patient");
        }

        /// <summary>
        /// Get details of a patient by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Patient GetPatientByName(string name)
        {
            var patient = _patientRepository.GetAll().Find(d => d.PatientName == name);
            if (patient == null)
            {
                throw new NotFoundException("Patient");
            }
            return patient;
        }

        public Patient UpdatePatient(Patient Patient)
        {
            var result = _patientRepository.Update(Patient);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Patient");
        }
    }
}
