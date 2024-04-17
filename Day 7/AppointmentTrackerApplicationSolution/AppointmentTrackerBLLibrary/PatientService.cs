using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary
{
    public class PatientService : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }
        public int AddPatient(Patient patient)
        {
            Patient newPatient = _patientRepository.Add(patient);
            return newPatient != null ? newPatient.PatientId : 0;
        }

        public Patient DeletePatient(int id)
        {
            return _patientRepository.Delete(id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.GetByID(id);
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _patientRepository.Update(patient);
        }
    }
}
