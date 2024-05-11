using System;
using System.Collections.Generic;

namespace AppointmentTrackerDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Patients = new HashSet<Patient>();
        }

        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Speciality { get; set; }
        public int? DoctorAge { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
