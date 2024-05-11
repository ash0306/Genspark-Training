using AppointmentTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        dbAppointmentTrackerContext context = new dbAppointmentTrackerContext();
        private List<Appointment> _appointments;
        public AppointmentRepository()
        {
            _appointments = context.Appointments.ToList();
        }
        //int GenerateID()
        //{
        //    if (_appointments.Count == 0)
        //        return 1;
        //    int id = _appointments.Keys.Max();
        //    return ++id;
        //}
        public Appointment Add(Appointment item)
        {
            context.Appointments.Add(item);
            context.SaveChanges();
            _appointments = context.Appointments.ToList();
            if (_appointments.Contains(item)) return item;
            return null;
        }

        public Appointment Delete(int key)
        {
            _appointments = context.Appointments.ToList();
            var appointment = _appointments.SingleOrDefault(d => d.AppointmentId == key);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                context.SaveChanges();
                _appointments = context.Appointments.ToList();
                return appointment;
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments;
        }

        public Appointment GetByID(int key)
        {
            var appointment = _appointments.SingleOrDefault(d => d.AppointmentId == key);
            if (appointment != null)
            {
                return appointment;
            }
            return null;
        }

        public Appointment Update(Appointment item)
        {
            _appointments = context.Appointments.ToList();
            var appointment = _appointments.SingleOrDefault(d => d.AppointmentId == item.AppointmentId);
            if (appointment != null)
            {
                appointment = item;
                context.Appointments.Update(appointment);
                context.SaveChanges();
                _appointments = context.Appointments.ToList();
                return appointment;
            }
            return null;
        }
    }
}
