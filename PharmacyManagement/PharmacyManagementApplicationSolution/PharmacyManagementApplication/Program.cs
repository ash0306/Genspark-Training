using PharmacyManagementBLLibrary;
using PharmacyManagementModelLibrary;

namespace PharmacyManagementApplication
{
    internal class Program
    {
        private PatientBL _patientService;
        private DoctorBL _doctorService;
        private PrescriptionBL _prescriptionService;
        private SalesBl _salesService;
        private DrugBL _drugService;
        public Program()
        {
            _drugService = new DrugBL();
            _patientService = new PatientBL();
            _doctorService = new DoctorBL();
            _salesService = new SalesBl();
            _prescriptionService = new PrescriptionBL();
        }
        private int GetChoiceFromUser()
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        private void PrintMainMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Manage Drugs");
            Console.WriteLine("2. Manage Doctors");
            Console.WriteLine("3. Manage Patients");
            Console.WriteLine("4. Manage Pescriptions");
            Console.WriteLine("5. Manage Sales");
            Console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
        }
        private void UserInteraction()
        {
            while (true)
            {
                PrintMainMenu();

                switch (GetChoiceFromUser())
                {
                    case 1:
                        ManageDrugs();
                        break;
                    case 2:
                        ManageDoctors();
                        break;
                    case 3:
                        ManagePatients();
                        break;
                    case 4:
                        ManagePrescriptions();
                        break;
                    case 5:
                        ManageSales();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice!! Try again!");
                        break;
                }
            }
        }
        
        
        private void PrintDrugMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Manage Drugs:");
            Console.WriteLine("1. Add Drug");
            Console.WriteLine("2. Get All Drugs");
            Console.WriteLine("3. Get Drug By ID");
            Console.WriteLine("4. Get Drug By Name");
            Console.WriteLine("5. Delete Drug");
            Console.WriteLine("6. Delete Out of Stock Drug");
            Console.WriteLine("7. Delete Expired Drug");
            Console.WriteLine("8. Update Drug");
            Console.WriteLine("9. Exit");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
        }
        private void ManageDrugs()
        {
            while (true)
            {
                PrintDrugMenu();
                switch (GetChoiceFromUser())
                {
                    case 1:
                        AddDrug();
                        break;
                    case 2:
                        GetAllDrugs();
                        break;
                    case 3:
                        GetDrugByID();
                        break;
                    case 4:
                        GetDrugByName();
                        break;
                    case 5:
                        DeleteDrug();
                        break;
                    case 6:
                        DeleteOutOfStockDrug();
                        break;
                    case 7:
                        DeleteExpiredDrug();
                        break;
                    case 8:
                        UpdateDrug();
                        break;
                    case 9:
                        return;

                }
            }
        }
        private void AddDrug()
        {
            try
            {
                Drug drug = new Drug();
                drug.BuildDrugFromConsole();
                int drugId = _drugService.AddDrug(drug);
                Console.WriteLine("Drug added with ID: " + drugId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while adding drug {ex.Message}");
            }
        }
        private void GetAllDrugs()
        {
            try
            {
                List<Drug> drugs = _drugService.GetAllDrugs();
                foreach (var drug in drugs)
                {
                    Console.WriteLine(drug.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while getting drugs {ex.Message}");
            }
        }
        private void GetDrugByID()
        {
            try
            {
                Console.WriteLine("Enter the ID of the drug:");
                int id = Convert.ToInt32(Console.ReadLine());
                Drug drug = _drugService.GetDrugByID(id);
                Console.WriteLine(drug.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while getting drugs {ex.Message}");
            }
        }
        private void GetDrugByName()
        {
            try
            {
                Console.WriteLine("Enter the name of the drug:");
                string name = Console.ReadLine() ?? "";
                Drug drug = _drugService.GetDrugByName(name);
                Console.WriteLine(drug.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while getting drugs {ex.Message}");
            }
        }
        private void DeleteDrug()
        {
            try
            {
                Console.WriteLine("Enter the ID of the drug:");
                int id = Convert.ToInt32(Console.ReadLine());
                var result = _drugService.DeleteDrug(id);
                Console.WriteLine($"Drug with ID {result} deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while deleting drugs {ex.Message}");
            }
        }
        private void DeleteOutOfStockDrug()
        {
            try
            {
                int result = _drugService.DeleteOutOfStockDrug();
                Console.WriteLine($"{result} drug(s) deleted!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while getting drugs {ex.Message}");
            }
        }
        private void DeleteExpiredDrug()
        {
            try
            {
                int result = _drugService.DeleteExpiredDrug();
                Console.WriteLine($"{result} drug(s) deleted!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while getting drugs {ex.Message}");
            }
        }
        private void UpdateDrug()
        {
            try
            {
                Console.WriteLine("Enter the details of drug to be updated:");
                Drug drug = new Drug();
                drug.BuildDrugFromConsole();
                Drug result = _drugService.UpdateDrug(drug);
                Console.WriteLine("Updated drug details:");
                Console.WriteLine(result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while getting drugs {ex.Message}");
            }
        }
        

        private void PrintDoctorMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Manage Doctors:");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Get Doctor By ID");
            Console.WriteLine("3. Get Doctor By Name");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. View All Doctors");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
        }
        private void ManageDoctors()
        {
            while(true)
            {
                PrintDoctorMenu();
                switch (GetChoiceFromUser())
                {
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        GetDoctorById();
                        break;
                    case 3:
                        GetDoctorByName();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        ViewAllDoctors();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private void AddDoctor()
        {
            try
            {
                Console.Write("Enter Doctor Name: ");
                string name = Console.ReadLine()!;

                Doctor doctor = new Doctor
                {
                    DoctorName = name
                };

                int doctorId = _doctorService.AddDoctor(doctor);
                Console.WriteLine($"Doctor added with ID: {doctorId}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding the doctor: {e.Message}");
            }
        }
        private void GetDoctorById()
        {
            try
            {
                Console.Write("Enter Doctor ID: ");
                int id = int.Parse(Console.ReadLine()!);

                Doctor doctor = _doctorService.GetDoctorByID(id);
                Console.WriteLine(doctor.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving the doctor: {e.Message}");
            }
        }
        private void GetDoctorByName()
        {
            try
            {
                Console.Write("Enter Doctor Name: ");
                string name = Console.ReadLine()??"";

                Doctor doctor = _doctorService.GetDoctorByName(name);
                Console.WriteLine(doctor.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving the doctor: {e.Message}");
            }
        }
        private void DeleteDoctor()
        {
            try
            {
                Console.Write("Enter Doctor ID: ");
                int id = int.Parse(Console.ReadLine()!);

                int result = _doctorService.DeleteDoctor(id);
                
                Console.WriteLine($"Doctor with ID {result} deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while deleting the doctor: {e.Message}");
            }
        }
        private void ViewAllDoctors()
        {
            try
            {
                var doctors = _doctorService.GetAllDoctors();
                Console.WriteLine("All Doctors:");
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"No doctors found {e.Message}.");
            }
        }


        private void PrintPatientMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Manage Patients:");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Get Patient By ID");
            Console.WriteLine("3. Get Patient By Name");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. View All Patients");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
        }
        private void ManagePatients()
        {
            while(true)
            {
                PrintPatientMenu();
                switch(GetChoiceFromUser())
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        GetPatientById();
                        break;
                    case 3:
                        GetPatientByName();
                        break;
                    case 4:
                        DeletePatient();
                        break;
                    case 5:
                        ViewAllPatients();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private void AddPatient()
        {
            try
            {
                Console.Write("Enter Patient Name: ");
                string name = Console.ReadLine()??"";

                Patient patient = new Patient
                {
                    PatientName = name
                };

                int patientId = _patientService.AddPatient(patient);
                Console.WriteLine($"Patient added with ID: {patientId}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding the patient: {e.Message}");
            }
        }
        private void GetPatientById()
        {
            try
            {
                Console.Write("Enter Patient ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Patient patient = _patientService.GetPatientByID(id);
                Console.WriteLine(patient.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving the patient: {e.Message}");
            }
        }
        private void GetPatientByName()
        {
            try
            {
                Console.Write("Enter Patient Name: ");
                string name = Console.ReadLine() ?? "";

                Patient patient = _patientService.GetPatientByName(name);
                Console.WriteLine(patient.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving the patient: {e.Message}");
            }
        }
        private void DeletePatient()
        {
            try
            {
                Console.Write("Enter Patient ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                int result = _patientService.DeletePatient(id);
                Console.WriteLine($"Patient with ID {result} deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while deleting the patient: {e.Message}");
            }
        }
        private void ViewAllPatients()
        {
            try
            {
                var patients = _patientService.GetAllPatients();
                Console.WriteLine("All Patients:");
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"No patients found {e.Message}");
            }
        }


        private void PrintPescriptionMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Manage Prescriptions:");
            Console.WriteLine("1. Add Prescription");
            Console.WriteLine("2. Get Prescription By ID");
            Console.WriteLine("3. View All Prescriptions");
            Console.WriteLine("4. Back to Main Menu");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
        }
        private void ManagePrescriptions()
        {
            while (true)
            {
                PrintPescriptionMenu();
                switch (GetChoiceFromUser())
                {
                    case 1:
                        AddPrescription();
                        break;
                    case 2:
                        GetPrescriptionById();
                        break;
                    case 3:
                        ViewAllPrescriptions();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid option!! Please try again.");
                        break;
                }
            }
        }
        private void AddPrescription()
        {
            try
            {
                Console.Write("Enter Patient ID: ");
                int patientId = int.Parse(Console.ReadLine()!);
                Patient patient = _patientService.GetPatientByID(patientId);

                Console.Write("Enter Doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine()!);
                Doctor doctor = _doctorService.GetDoctorByID(doctorId);

                Console.Write("Enter Drug Names separated by commas: ");
                string drugNamesInput = Console.ReadLine()!;
                string[] drugNames = drugNamesInput.Split(',');

                List<Drug> drugsList = new List<Drug>();
                foreach (var drugName in drugNames)
                {
                    Drug drug = _drugService.GetDrugByName(drugName.Trim());
                    drugsList.Add(drug);
                }

                Console.Write("Enter Dosage: ");
                int dosage = Convert.ToInt32(Console.ReadLine());

                Prescription prescription = new Prescription(patient, doctor, drugsList, dosage);

                int result = _prescriptionService.AddPrescription(prescription);
                Console.WriteLine($"Prescription added with ID: {result}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding the prescription: {e.Message}");
            }
        }

        private void GetPrescriptionById()
        {
            try
            {
                Console.Write("Enter Prescription ID: ");
                int id = int.Parse(Console.ReadLine()!);

                Prescription prescription = _prescriptionService.GetPrescriptionByID(id);
                if (prescription != null)
                {
                    Console.WriteLine(prescription.ToString());
                }
                else
                {
                    Console.WriteLine("Prescription not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving the prescription: {e.Message}");
            }
        }
        private void ViewAllPrescriptions()
        {
            try
            {
                var prescriptions = _prescriptionService.GetAllPrescriptions();
                Console.WriteLine("\nAll Prescriptions:");
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine(prescription.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No prescriptions found.");
            }
        }

        private void PrintSalesMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Manage Sales:");
            Console.WriteLine("1. View Sale Receipt By ID");
            Console.WriteLine("2. View All Sales");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
        }
        private void ManageSales()
        {
            while(true)
            {
                PrintSalesMenu();
                switch (GetChoiceFromUser())
                {
                    case 1:
                        ViewSaleById();
                        break;
                    case 2:
                        ViewAllSales();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private void ViewSaleById()
        {
            try
            {
                Console.Write("Enter Sale ID: ");
                int saleId = int.Parse(Console.ReadLine()!);

                Sales sale = _salesService.GetSaleByID(saleId);
                Console.WriteLine(sale.ToString());
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving the sale: {e.Message}");
            }
        }

        private void ViewAllSales()
        {
            try
            {
                var sales = _salesService.GetAllSales();
                Console.WriteLine("All Sales:");
                foreach (var sale in sales)
                {
                    Console.WriteLine(sale.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving all sales: {e.Message}");
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.UserInteraction();
        }
    }
}
