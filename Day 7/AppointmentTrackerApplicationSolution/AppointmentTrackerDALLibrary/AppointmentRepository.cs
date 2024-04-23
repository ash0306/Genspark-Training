using AppointmentTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;
        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }
        int GenerateID()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
                return null!;
            int id = GenerateID();
            item.AppointmentId = id;
            _appointments.Add(id, item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var doctor = _appointments[key];
                _appointments.Remove(key);
                return doctor;
            }
            return null!;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null!;
            return _appointments.Values.ToList();
        }

        public Appointment GetByID(int key) => _appointments.ContainsKey(key) ? _appointments[key] : null!;

        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.AppointmentId))
            {
                _appointments[item.AppointmentId] = item;
                return item;
            }
            return null!;
        }
    }
}
