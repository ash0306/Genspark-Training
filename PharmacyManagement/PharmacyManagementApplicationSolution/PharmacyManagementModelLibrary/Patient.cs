using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementModelLibrary
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set;}

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Patient()
        {
            PatientId = 0;
            PatientName = string.Empty;
        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="patientName"></param>
        public Patient(int patientId, string patientName)
        {
            PatientId = patientId;
            PatientName = patientName;
        }

        /// <summary>
        /// Override of the ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Patient ID: " + PatientId
                + "\nPatient Name: " + PatientName;
        }

        /// <summary>
        /// Override of the Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            Patient p1, p2;
            p1 = this;
            Patient? patient = obj as Patient;
            p2 = patient;
            return p1.PatientId.Equals(p2.PatientId);
        }
    }
}
