using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerDALLibrary
{
    public interface IRepository<K, T>
    {
        List<T> GetAll();
        T GetByID(K key);
        T Add(T item);
        T Update(T item);
        T Delete(K key);

    }
}
