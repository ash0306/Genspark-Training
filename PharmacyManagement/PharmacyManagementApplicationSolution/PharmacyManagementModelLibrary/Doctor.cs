using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementModelLibrary
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Doctor()
        {
            DoctorId = 0;
            DoctorName = string.Empty;
        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="doctorId">Doctor ID as integer</param>
        /// <param name="doctorName">Doctor name as string</param>
        public Doctor(int doctorId, string doctorName)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
        }

        /// <summary>
        /// Overide of the ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Doctor ID: " + DoctorId
                + "\nDoctor Name: " + DoctorName;
        }

        /// <summary>
        /// Override of Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            Doctor doc1, doc2;
            doc1 = this;
            Doctor? doctor = obj as Doctor;
            doc2 = doctor;
            return doc1.DoctorId.Equals(doc2.DoctorId);
        }
    }
}
