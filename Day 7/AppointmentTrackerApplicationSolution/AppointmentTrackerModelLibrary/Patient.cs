using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerModelLibrary
{
    public class Patient
    {
        public Doctor PatientDoctor { get; set; }
        public int PatientId { get; set; }
        public int PatientAge { get; set; }
        public string PatientName { get; set; }
        public string PatientIllness { get; set; }

        public Patient()
        {
            PatientId = 0;
            PatientAge = 0;
            PatientName = string.Empty;
            PatientIllness = string.Empty;
            PatientDoctor = new Doctor();
        }

        public Patient(Doctor patientDoctor, int patientId, int age, string patientName, string patientIllness)
        {
            PatientDoctor = patientDoctor;
            PatientId = patientId;
            PatientAge = age;
            PatientName = patientName;
            PatientIllness = patientIllness;
        }

        public Patient(int patientAge, string patientName, string patientIllness)
        {
            PatientAge = patientAge;
            PatientName = patientName ?? "";
            PatientIllness = patientIllness ?? "";
        }

        public override bool Equals(object? obj)
        {
            return this.PatientId.Equals((obj as Patient).PatientId);
        }

        public override string ToString()
        {
            return "Patient ID:"+PatientId
                + "\nPatient Name:"+PatientName
                + "\nPatient Age:"+PatientAge
                + "\nPatient Illness:"+PatientIllness
                + "\nDoctor assigned to the patient:"+PatientDoctor;
        }
    }
}
