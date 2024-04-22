using PharmacyManagementDALLibrary;
using PharmacyManagementModelLibrary;
using PharmacyManagementBLLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBL()
        {
            _doctorRepository = new DoctorRepository();
        }
        public int AddDoctor(Doctor Doctor)
        {
            var result = _doctorRepository.Add(Doctor);
            if (result != null)
            {
                return result.DoctorId;
            }
            throw new DuplicateFoundException("Doctor");
        }

        public int DeleteDoctor(int id)
        {
            var result = _doctorRepository.Delete(id);
            if(result != null)
            {
                return result.DoctorId;
            }
            throw new NotFoundException("Doctor");
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if(doctors.Count == 0)
            {
                throw new NotFoundException("Doctor");
            }
            return doctors;
        }

        public Doctor GetDoctorByID(int id)
        {
            var result = _doctorRepository.GetByID(id);
            if(result != null)
            {
                return result;
            }
            throw new NotFoundException("Doctor");
        }

        public Doctor GetDoctorByName(string name)
        {
            var doctor = _doctorRepository.GetAll().Find(d => d.DoctorName == name);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor");
            }
            return doctor;
        }

        public Doctor UpdateDoctor(Doctor Doctor)
        {
            var result = _doctorRepository.Update(Doctor);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Doctor");
        }
    }
}
