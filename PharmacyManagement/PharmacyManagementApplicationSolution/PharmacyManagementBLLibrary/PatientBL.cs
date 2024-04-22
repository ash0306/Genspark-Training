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
        public PatientBL()
        {
            _patientRepository = new PatientRepository();
        }
        public int AddPatient(Patient Patient)
        {
            var result = _patientRepository.Add(Patient);
            if (result != null)
            {
                return result.PatientId;
            }
            throw new DuplicateFoundException("Patient");
        }

        public int DeletePatient(int id)
        {
            var result = _patientRepository.Delete(id);
            if (result != null)
            {
                return result.PatientId;
            }
            throw new NotFoundException("Patient");
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = _patientRepository.GetAll();
            if (patients.Count == 0)
            {
                throw new NotFoundException("Patient");
            }
            return patients;
        }

        public Patient GetPatientByID(int id)
        {
            var result = _patientRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Patient");
        }

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
