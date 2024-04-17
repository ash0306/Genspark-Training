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

        public Doctor(int doctorId, string doctorName, string speciality)
        {
            DoctorId = doctorId;
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
            d2 = obj as Doctor;//Casting in a more symanctic way
            return d1.DoctorId.Equals(d2.DoctorId);
        }
    }
}
