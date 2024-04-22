using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public interface IPrescription
    {
        int AddPrescription(Prescription Prescription);
        int DeletePrescription(int id);
        Prescription GetPrescriptionByID(int id);
        List<Prescription> GetAllPrescriptions();
        List<Drug> CheckAvailability();
    }
}
