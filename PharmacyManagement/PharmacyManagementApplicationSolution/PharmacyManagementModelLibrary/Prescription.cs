﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementModelLibrary
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Drug Drug { get; set; }
        public int Dosage { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Prescription()
        {
            Patient = new Patient();
            Doctor = new Doctor();
            Drug = new Drug();
            Dosage = 0;
        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="patient">Patient details as class object</param>
        /// <param name="doctor">Doctor details asclass object</param>
        /// <param name="drug">Drug details as class object</param>
        /// <param name="dosage"></param>
        public Prescription(Patient patient, Doctor doctor, Drug drug, int dosage)
        {
            Patient = patient;
            Doctor = doctor;
            Drug = drug;
            Dosage = dosage;
        }

        public override string ToString()
        {
            return "Prescription ID: " + PrescriptionId
                + "Patient Details: " + Patient.ToString()
                + "Doctor Details: " + Doctor.ToString()
                + "Drug: " + Drug
                + "Dosage: " + Dosage;
        }
    }
}
