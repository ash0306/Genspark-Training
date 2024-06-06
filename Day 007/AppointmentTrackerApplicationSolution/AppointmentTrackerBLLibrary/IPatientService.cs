using AppointmentTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary
{
    public interface IPatientService
    {
        int AddPatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        Patient UpdatePatient(Patient patient);
        Patient DeletePatient(int id);
    }
}
