using System;
using System.Collections.Generic;

namespace AppointmentTrackerDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? PatientAge { get; set; }
        public string? PatientIllness { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
