using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public interface IPatientService
    {
        int AddPatient(Patient Patient);
        Patient UpdatePatient(Patient Patient);
        int DeletePatient(int id);
        Patient GetPatientByID(int id);
        Patient GetPatientByName(string name);
        List<Patient> GetAllPatients();
    }
}
