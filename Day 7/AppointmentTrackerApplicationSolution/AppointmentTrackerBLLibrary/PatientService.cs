using AppointmentTrackerBLLibrary.Exceptions;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary
{
    public class PatientService :IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }
        public PatientService(IRepository<int, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
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

        public Patient DeletePatient(int id)
        {
            var result = _patientRepository.Delete(id);
            if (result != null)
            {
                return result;
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

        public Patient GetPatientById(int id)
        {
            var result = _patientRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Patient");
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
