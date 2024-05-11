using AppointmentTrackerBLLibrary;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;

namespace AppointmentTracker
{
    internal class Program
    {
        private readonly IDoctorService _doctorService = new DoctorService();
        private readonly IPatientService _patientService = new PatientService();
        private readonly IAppointmentService _appointmentService = new AppointmentService();

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Run();
        }

    }
}
