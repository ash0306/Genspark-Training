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
        public int AddAppointment(Appointment appointment)
        {
            Appointment newAppoint = _appointmentRepository.Add(appointment);
            return newAppoint!=null ? newAppoint.AppointmentId : 0;
        }

        public Appointment DeleteAppointment(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.GetByID(id);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }
    }
}
