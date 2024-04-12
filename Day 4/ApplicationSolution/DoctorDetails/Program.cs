using DoctorDetails.Models;
namespace DoctorDetails
{
    internal class Program
    {
        Doctor CreateDoctorByTakingDetailsFromConsole ()
        {
            Doctor doctor = new Doctor ();
            Console.WriteLine("Enter doctor's ID:");
            doctor.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter doctor's name:");
            doctor.Name = Console.ReadLine()??"";
            Console.WriteLine("Enter doctor's age:");
            doctor.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter doctor's experience:");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter doctor's speciality:");
            doctor.Speciality = Console.ReadLine() ?? "";
            Console.WriteLine("Enter doctor's qualification:");
            doctor.Qualification = Console.ReadLine() ?? "";

            return doctor;
        }
        static void Main(string[] args)
        {
            Program program = new Program ();
            int numOfEntries;
            Console.WriteLine("Enter the number of entries you want to add:");
            numOfEntries = Convert.ToInt32(Console.ReadLine());
            Doctor[] doctor = new Doctor[numOfEntries];

            for(int i = 0; i < numOfEntries; i++)
            {
                doctor[i] = program.CreateDoctorByTakingDetailsFromConsole();
            }

            for (int i = 0; i < numOfEntries; i++)
            {
                doctor[i].PrintDoctorDetails();
            }
            string specialityFromUser;
            Console.WriteLine("Enter the speciality to be searched:");
            specialityFromUser = Console.ReadLine() ?? "";

            for (int i = 0; i < numOfEntries; i++)
            {
                if (doctor[i].Speciality.Equals(specialityFromUser, StringComparison.OrdinalIgnoreCase))
                {
                    doctor[i].PrintDoctorDetails();
                }
            }

        }
    }
}
