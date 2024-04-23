using AppointmentTrackerBLLibrary;
using AppointmentTrackerBLLibrary.Exceptions;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLTest
{
    public class PatientBLTest
    {
        IRepository<int, Patient> repository;
        IPatientService patientService;
        [SetUp]
        public void Setup()
        {
            repository = new PatientRepository();
            Patient patient = new Patient() { PatientName = "Phoenix", PatientAge = 25, PatientIllness = "Flu" };
            repository.Add(patient);
            patientService = new PatientService(repository);
        }

        // ADD
        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Patient patient = new Patient() { PatientName = "Andrew", PatientAge = 15, PatientIllness="Fracture"};
            //Action
            int result = patientService.AddPatient(patient);
            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddFailureTest()
        {
            //Arrange 
            Patient patient = new Patient() { PatientName = "Wendy", PatientAge = 50, PatientIllness = "Asthma"};
            //Action
            int result = patientService.AddPatient(patient);
            //Assert
            Assert.AreNotEqual(1, result);
        }

        [Test]
        public void AddExceptionTest()
        {
            Patient patient = new Patient() {PatientId = 1, PatientName = "Wendy", PatientAge = 50, PatientIllness = "Asthma" };
            Assert.Throws<DuplicateFoundException>(()=>patientService.AddPatient(patient));
        }

        // GET ALL

        [Test]
        public void GetAllSuccessTest()
        {
            var result = patientService.GetAllPatients();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllFailureTest()
        {
            var delete = patientService.DeletePatient(1);
            Assert.Throws<NullReferenceException>(() => patientService.GetAllPatients());
        }

        [Test]
        public void GetAllExceptionTest()
        {
            var delete = patientService.DeletePatient(1);
            Assert.Throws<NullReferenceException>(()=>patientService.GetAllPatients());
        }


        // DELETE

        [Test]
        public void DeleteSuccessTest()
        {
            var result = patientService.DeletePatient(1);
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void DeleteFailureTest()
        {
            var result = patientService.DeletePatient(1);
            Assert.AreNotEqual(result.PatientId, 0);
        }

        [Test]
        public void DeleteExceptionTest()
        {
            var result = patientService.DeletePatient(1);
            Assert.Throws<NotFoundException>(()=> patientService.DeletePatient(1));
        }

        // UPDATE

        [Test]
        public void UpdateSuccessTest()
        {
            Patient patient = new Patient() { PatientId = 1, PatientName = "Phoenix", PatientAge = 28, PatientIllness = "Flu" };
            var result = patientService.UpdatePatient(patient);
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void UpdateFailureTest()
        {
            Patient patient = new Patient() { PatientId = 1, PatientName = "Phoenix", PatientAge = 25, PatientIllness = "Flu" };
            var result = patientService.UpdatePatient(patient);
            Assert.AreNotEqual(result.PatientId, 0);
        }

        [Test]
        public void UpdateExceptionTest()
        {
            Patient patient = new Patient() { PatientId = 101, PatientName = "Phoenix", PatientAge = 25, PatientIllness = "Flu" };
            Assert.Throws<NotFoundException>(()=>patientService.UpdatePatient(patient));
        }

        // GET BY ID

        [Test]
        public void GetByIdSuccessTest()
        {
            var result = patientService.GetPatientById(1);
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void GetByIdFailTest()
        {
            Assert.Throws<NotFoundException>(() => patientService.GetPatientById(0));
        }

        [Test]
        public void GetByIdExceptionTest()
        {
            Assert.Throws<NotFoundException>(() => patientService.GetPatientById(0));
        }
    }
}
