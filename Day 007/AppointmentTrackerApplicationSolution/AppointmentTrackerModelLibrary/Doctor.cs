namespace AppointmentTrackerModelLibrary
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Speciality { get; set; }
        public int DoctorAge { get; set; }
        public Doctor()
        {
            DoctorId = 0;
            DoctorName = string.Empty;
            Speciality = string.Empty;
            DoctorAge = 0;
        }

        public Doctor( string doctorName, string speciality)
        {
            DoctorName = doctorName;
            Speciality = speciality;
            DoctorAge = 0;
        }

        public override string ToString()
        {
            return "Doctor ID : " + DoctorId
                + "\nDoctor Name : " + DoctorName
                + "\nSpeciality : " + Speciality
                + "\nDoctorAge: " + DoctorAge;
        }
        public override bool Equals(object? obj)
        {
            Doctor d1, d2;
            d1 = this;
            d2 = obj as Doctor;
            return d1.DoctorId.Equals(d2.DoctorId);
        }

        public Doctor BuildDoctorFromConsole()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Enter the Doctor's name: ");
            doctor.DoctorName = Console.ReadLine()??"";
            Console.WriteLine("Enter the Doctor's age: ");
            doctor.DoctorAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter specialty: ");
            doctor.Speciality = Console.ReadLine()??"";

            return doctor;
        }
    }
}
