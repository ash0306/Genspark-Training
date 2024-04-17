using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;

namespace AppointmentTrackerBLLibrary
{
    public class DoctorService : IDoctorService
    {
        readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }
        public int AddDoctor(Doctor doctor)
        {
            Doctor newDoc = _doctorRepository.Add(doctor);
            return newDoc != null ? newDoc.DoctorId : 0;
        }

        public Doctor DeleteDoctor(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorRepository.GetByID(id);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }
    }
}
