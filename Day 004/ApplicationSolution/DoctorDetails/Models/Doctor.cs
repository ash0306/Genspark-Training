using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDetails.Models
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Speciality { get; set; }
        public string Qualification { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Experience = 0;
            Speciality = string.Empty;
            Qualification = string.Empty;
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="id">Doctor's ID</param>
        /// <param name="name">Doctor's name as string</param>
        /// <param name="age">Doctor's age</param>
        /// <param name="experience">Doctor's experience in years</param>
        /// <param name="speciality">Doctor's speciality as string</param>
        public Doctor(int id, string name, int age, int experience, string speciality, string qualification)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Speciality = speciality;
            Qualification = qualification;
        }

        /// <summary>
        /// Prints all the Doctor details
        /// </summary>
        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Doctor ID:\t{Id}");
            Console.WriteLine($"Doctor Name:\t{Name}");
            Console.WriteLine($"Doctor Age:\t{Age}");
            Console.WriteLine($"Doctor Experience:\t{Experience}");
            Console.WriteLine($"Doctor Speciality:\t{Speciality}");
            Console.WriteLine($"Doctor Qualification:\t{Qualification}");
        }
    }
}
