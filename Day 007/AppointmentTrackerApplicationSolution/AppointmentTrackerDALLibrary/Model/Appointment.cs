using System;
using System.Collections.Generic;

namespace AppointmentTrackerDALLibrary.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string? AppointmentTitle { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
