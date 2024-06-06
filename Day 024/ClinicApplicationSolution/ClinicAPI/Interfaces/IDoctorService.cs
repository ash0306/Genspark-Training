using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality);
        public Task<Doctor> UpdateDoctorExperience(int id, int experience);
        public Task<Doctor> AddDoctor(Doctor doctor);
        public Task<int> DeleteDoctor(int id);
    }
}
