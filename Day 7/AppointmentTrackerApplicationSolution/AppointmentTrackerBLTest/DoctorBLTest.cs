using AppointmentTrackerBLLibrary;
using AppointmentTrackerBLLibrary.Exceptions;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;

namespace AppointmentTrackerBLTest
{
    public class DoctorBLTests
    {
        IRepository<int, Doctor> repository;
        IDoctorService doctorService;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            Doctor doctor = new Doctor() { DoctorName = "Ash", DoctorAge = 25, Speciality = "Cardio" };
            repository.Add(doctor);
            doctorService = new DoctorService(repository);
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { DoctorName = "Blue", DoctorAge = 29, Speciality = "Gastro" };
            var result = doctorService.AddDoctor(doctor);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddFailureTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "Neil", DoctorAge = 39, Speciality = "Ca" };
            var result = doctorService.AddDoctor(doctor);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddExceptionTest()
        {
            Doctor doctor = new Doctor() { DoctorId = 1, DoctorName = "Leo", DoctorAge = 30};
            Assert.Throws<DuplicateFoundException>(() => doctorService.AddDoctor(doctor));
        }

        //DELETE

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            int doctorIdToDelete = 1;
            var result = doctorService.DeleteDoctor(doctorIdToDelete);
            Assert.AreEqual(1, result.DoctorId);
        }

        [Test]
        public void DeleteDoctorFailureTest()
        {
            int nonExistentDoctorId = 999;
            int invalidDoctorId = -1;
            Assert.Throws<NotFoundException>(() => doctorService.DeleteDoctor(invalidDoctorId));
        }

        [Test]
        public void DeleteDoctorExceptionTest()
        {
            int invalidDoctorId = -1;
            Assert.Throws<NotFoundException>(() => doctorService.DeleteDoctor(invalidDoctorId));
        }

        //GET ALL
        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            List<Doctor> doctors = doctorService.GetAllDoctors();
            Assert.IsNotNull(doctors);
        }

        [Test]
        public void GetAllDoctorsFailureTest()
        {

            List<Doctor> doctors = doctorService.GetAllDoctors();
            Assert.IsNotNull(doctors);
        }

        [Test]
        public void GetAllDoctorsExceptionTest()
        {
            repository = new DoctorRepository();
            doctorService = new DoctorService(repository);
            Assert.Throws<NullReferenceException>(() => doctorService.GetAllDoctors());
        }

        //GET BY ID
        [Test]
        public void GetDoctorByIdSuccessTest()
        {
            int doctorId = 1;
            Doctor doctor = doctorService.GetDoctorById(doctorId);
            Assert.AreEqual(doctorId, doctor.DoctorId);
        }

        [Test]
        public void GetDoctorByIdFailureTest()
        {
            int nonExistentDoctorId = 999;
            Assert.Throws<NotFoundException>(() => doctorService.GetDoctorById(nonExistentDoctorId));
        }

        [Test]
        public void GetDoctorByIdExceptionTest()
        {
            int invalidDoctorId = -1;
            Assert.Throws<NotFoundException>(() => doctorService.GetDoctorById(invalidDoctorId));
        }


        //UPDATE

        [Test]
        public void UpdateDoctorSuccessTest()
        {
            int doctorIdToUpdate = 1;
            Doctor updatedDoctor = new Doctor() { DoctorId = doctorIdToUpdate, DoctorName = "UpdatedName", DoctorAge = 30 };
            Doctor result = doctorService.UpdateDoctor(updatedDoctor);
            Assert.IsNotNull(result);
            Assert.AreEqual(doctorIdToUpdate, result.DoctorId);
        }

        [Test]
        public void UpdateDoctorFailureTest()
        {
            int nonExistentDoctorId = 999; 
            Doctor updatedDoctor = new Doctor() { DoctorId = nonExistentDoctorId, DoctorName = "UpdatedName", DoctorAge = 30 };
            Assert.Throws<NotFoundException>(() => doctorService.UpdateDoctor(updatedDoctor));
        }

        [Test]
        public void UpdateDoctorExceptionTest()
        {
            int nonExistentDoctorId = 999;
            Doctor nullDoctor = new Doctor() {DoctorId = nonExistentDoctorId, DoctorName = "UpdatedName", DoctorAge = 30 };
                                                                                                                                                                     // Action & Assert
            Assert.Throws<NotFoundException>(() => doctorService.UpdateDoctor(nullDoctor));
        }


    }
}