using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerModelLibrary
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public string AppointmentTitle { get; set; }

        public Appointment()
        {
            Patient = new Patient();
            Doctor = new Doctor();
            AppointmentId = 0;
            AppointmentTitle = string.Empty;
            AppointmentTime = DateTime.Now;
        }

        public Appointment(int appointmentId, DateTime appointmentTime, Doctor doctor, Patient patient, string appointmentTitle)
        {
            AppointmentId = appointmentId;
            AppointmentTime = appointmentTime;
            Doctor = doctor;
            Patient = patient;
            AppointmentTitle = appointmentTitle;
        }

        public override bool Equals(object? obj)
        {
            return this.AppointmentId.Equals((obj as Appointment).AppointmentId);
        }

        public override string ToString()
        {
            return "Appointment ID:"+AppointmentId
                + "\nAppointment Time:"+AppointmentTime
                + "\nAppointment Title:"+AppointmentTitle
                + "\nDoctor Details:"+Doctor
                + "\nPatient Details:"+Patient;
        }
    }
}
