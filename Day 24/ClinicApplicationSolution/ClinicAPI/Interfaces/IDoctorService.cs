using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality);
        public Task<int> UpdateDoctorExperience(int id, int experience);
    }
}
