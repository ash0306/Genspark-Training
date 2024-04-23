using AppointmentTrackerBLLibrary.Exceptions;
using AppointmentTrackerDALLibrary;
using AppointmentTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary
{
    public class AppointmentService : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentRepository;
        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public AppointmentService(IRepository<int, Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public int AddAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Add(appointment);
            Console.WriteLine(result);
            if (result != null)
            {
                return result.AppointmentId;
            }
            throw new DuplicateFoundException("Appointment");
        }

        public Appointment DeleteAppointment(int id)
        {
            var result = _appointmentRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Appointment");
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            if (appointments.Count == 0)
            {
                throw new NotFoundException("Appointment");
            }
            return appointments;
        }

        public Appointment GetAppointmentById(int id)
        {
            var result = _appointmentRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Appointment");
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Update(appointment);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Appointment");
        }
    }
}
