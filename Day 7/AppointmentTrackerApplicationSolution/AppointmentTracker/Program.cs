
using AppointmentTrackerBLLibrary;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;

namespace AppointmentTracker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IRepository<int, Doctor> repository;
            IDoctorService doctorService;
            repository = new DoctorRepository();
            //Doctor doctor = new Doctor() { DoctorName = "Ash", DoctorAge = 25, Speciality = "Cardio" };
            //repository.Add(doctor);
            doctorService = new DoctorService(repository);
            Doctor doctor2 = new Doctor() { DoctorName = "Blue", DoctorAge = 29, Speciality = "Ca" };
            var result = doctorService.AddDoctor(doctor2);
            Console.WriteLine(result);
        }
        
    }
}
