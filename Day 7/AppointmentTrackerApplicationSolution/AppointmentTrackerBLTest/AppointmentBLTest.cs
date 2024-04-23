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
    public class AppointmentBLTest
    {
        IRepository<int, Appointment> repository;
        IAppointmentService appointmentService;

        [SetUp]
        public void Setup()
        {
            repository = new AppointmentRepository();
            Appointment appointment = new Appointment() { AppointmentId = 1, AppointmentTime = DateTime.Now, AppointmentTitle = "Temporary"};
            repository.Add(appointment);
            appointmentService = new AppointmentService(repository);
        }

        // ADD
        [Test]
        public void AddAppointmentSuccessTest()
        {
            Appointment newAppointment = new Appointment() { AppointmentId = 2, AppointmentTime = DateTime.Now, AppointmentTitle = "New"};
            var result = appointmentService.AddAppointment(newAppointment);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddAppointmentFailureTest()
        {
            Appointment existingAppointment = new Appointment() { AppointmentId = 1, AppointmentTime = DateTime.Now, AppointmentTitle="temp"};
            Assert.Throws<DuplicateFoundException>(() => appointmentService.AddAppointment(existingAppointment));
        }

        [Test]
        public void AddAppointmentExceptionTest()
        {
            Appointment appointment = null;
            Assert.Throws<NullReferenceException>(() => appointmentService.AddAppointment(appointment));
        }

        // DELETE
        [Test]
        public void DeleteAppointmentSuccessTest()
        {
            Appointment deletedAppointment = appointmentService.DeleteAppointment(1);
            Assert.IsNotNull(deletedAppointment);
        }

        [Test]
        public void DeleteAppointmentFailureTest()
        {
            Assert.Throws<NotFoundException>(() => appointmentService.DeleteAppointment(2));
        }

        [Test]
        public void DeleteAppointmentExceptionTest()
        {
            Assert.Throws<NotFoundException>(() => appointmentService.DeleteAppointment(0));
        }

        // GET ALL
        [Test]
        public void GetAllAppointmentsSuccessTest()
        {
            var appointments = appointmentService.GetAllAppointments();
            Assert.IsNotEmpty(appointments);
        }

        [Test]
        public void GetAllAppointmentsFailureTest()
        {
            repository.Delete(1);
            Assert.Throws<NullReferenceException>(() => appointmentService.GetAllAppointments());
        }

        [Test]
        public void GetAllAppointmentsExceptionTest()
        {
            repository = null;
            appointmentService = new AppointmentService(repository);
            Assert.Throws<NullReferenceException>(() => appointmentService.GetAllAppointments());
        }


        [Test]
        public void GetAppointmentByIdSuccessTest()
        {
            var appointment = appointmentService.GetAppointmentById(1);
            Assert.IsNotNull(appointment);
        }

        [Test]
        public void GetAppointmentByIdFailureTest()
        {
            Assert.Throws<NotFoundException>(() => appointmentService.GetAppointmentById(2));
        }

        [Test]
        public void GetAppointmentByIdExceptionTest()
        {
            Assert.Throws<NotFoundException>(() => appointmentService.GetAppointmentById(0));
        }


        [Test]
        public void UpdateAppointmentSuccessTest()
        {
            Appointment updatedAppointment = new Appointment() {AppointmentId = 1, AppointmentTime = DateTime.Now, AppointmentTitle = "Updated"};
            var result = appointmentService.UpdateAppointment(updatedAppointment);
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateAppointmentFailureTest()
        {
            Appointment invalidAppointment = new Appointment();
            Assert.Throws<NotFoundException>(() => appointmentService.UpdateAppointment(invalidAppointment));
        }

        [Test]
        public void UpdateAppointmentExceptionTest()
        {
            Appointment appointment = null;
            Assert.Throws<NullReferenceException>(() => appointmentService.UpdateAppointment(appointment));
        }
    }
}
