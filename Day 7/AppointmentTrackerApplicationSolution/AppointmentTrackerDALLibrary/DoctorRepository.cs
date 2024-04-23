using AppointmentTrackerModelLibrary;

namespace AppointmentTrackerDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }
        int GenerateID()
        {
            if(_doctors.Count == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
                return null!;
            int id = GenerateID();
            item.DoctorId = id;
            _doctors.Add(id, item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var doctor = _doctors[key];
                _doctors.Remove(key);
                return doctor;
            }
            return null!;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null!;
            return _doctors.Values.ToList();
        }

        public Doctor GetByID(int key) => _doctors.ContainsKey(key) ? _doctors[key] : null!;

        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.DoctorId))
            {
                _doctors[item.DoctorId] = item;
                return item;
            }
            return null!;
        }
    }
}
