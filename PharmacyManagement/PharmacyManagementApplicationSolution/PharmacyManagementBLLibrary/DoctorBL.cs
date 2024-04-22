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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DoctorBL()
        {
            _doctorRepository = new DoctorRepository();
        }

        /// <summary>
        /// Add a doctor
        /// </summary>
        /// <param name="Doctor"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateFoundException"></exception>
        public int AddDoctor(Doctor Doctor)
        {
            var result = _doctorRepository.Add(Doctor);
            if (result != null)
            {
                return result.DoctorId;
            }
            throw new DuplicateFoundException("Doctor");
        }

        /// <summary>
        /// Delete a doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public int DeleteDoctor(int id)
        {
            var result = _doctorRepository.Delete(id);
            if(result != null)
            {
                return result.DoctorId;
            }
            throw new NotFoundException("Doctor");
        }

        /// <summary>
        /// Get a list of all doctor details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if(doctors.Count == 0)
            {
                throw new NotFoundException("Doctor");
            }
            return doctors;
        }

        /// <summary>
        /// Get doctor details using their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Doctor GetDoctorByID(int id)
        {
            var result = _doctorRepository.GetByID(id);
            if(result != null)
            {
                return result;
            }
            throw new NotFoundException("Doctor");
        }

        /// <summary>
        /// Get doctor Details using their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Doctor GetDoctorByName(string name)
        {
            var doctor = _doctorRepository.GetAll().Find(d => d.DoctorName == name);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor");
            }
            return doctor;
        }

        /// <summary>
        /// Update a doctor
        /// </summary>
        /// <param name="Doctor"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
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
