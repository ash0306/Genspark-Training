using AppointmentTrackerBLLibrary.Exceptions;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;

namespace AppointmentTrackerBLLibrary
{
    public class DoctorService : IDoctorService
    {
        readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorService(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public int AddDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);
            Console.WriteLine(result);
            if (result != null)
            {
                return result.DoctorId;
            }
            throw new DuplicateFoundException("Doctor");
        }

        public Doctor DeleteDoctor(int id)
        {
            var result = _doctorRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Doctor");
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if (doctors.Count == 0)
            {
                throw new NotFoundException("Doctor");
            }
            return doctors;
        }

        public Doctor GetDoctorById(int id)
        {
            var result = _doctorRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Doctor");
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Update(doctor);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Doctor");
        }
    }
}
