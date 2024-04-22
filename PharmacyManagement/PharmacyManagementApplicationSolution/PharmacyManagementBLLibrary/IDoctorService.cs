using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public interface IDoctorService
    {
        int AddDoctor(Doctor Doctor);
        Doctor UpdateDoctor(Doctor Doctor);
        int DeleteDoctor(int id);
        Doctor GetDoctorByID(int id);
        Doctor GetDoctorByName(string name);
        List<Doctor> GetAllDoctors();
    }
}
