using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementDALLibrary
{
    public class SalesRepository : IRepository<int, Sales>
    {
        private readonly Dictionary<int, Sales> _sales;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesRepository()
        {
            _sales = new Dictionary<int, Sales>();
        }

        /// <summary>
        /// Function to generate ID
        /// </summary>
        /// <returns></returns>
        private int GenerateId()
        {
            if (_sales.Count == 0) return 1;
            int id = _sales.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Add a sale
        /// </summary>
        /// <param name="item">sales class object</param>
        /// <returns></returns>
        public Sales Add(Sales item)
        {
            if (_sales.ContainsValue(item)) return null;
            int id = GenerateId();
            item.TransactionId = id;
            _sales.Add(id, item);
            return item;
        }

        /// <summary>
        /// Delete a sale
        /// </summary>
        /// <param name="key">ID of the sales to be deleted</param>
        /// <returns></returns>
        public Sales Delete(int key)
        {
            if (_sales.ContainsKey(key))
            {
                var sales = _sales[key];
                _sales.Remove(key);
                return sales;
            }
            return null;
        }

        /// <summary>
        /// Display all sales
        /// </summary>
        /// <returns></returns>
        public List<Sales> GetAll()
        {
            if (_sales.Count == 0) return null;
            return _sales.Values.ToList();
        }

        /// <summary>
        /// Get details of 1 sale
        /// </summary>
        /// <param name="key">ID of sales to be fetched</param>
        /// <returns></returns>
        public Sales GetByID(int key)
        {
            return _sales.ContainsKey(key) ? _sales[key] : null;
        }

        /// <summary>
        /// Update the details
        /// </summary>
        /// <param name="item">sales class object</param>
        /// <returns></returns>
        public Sales Update(Sales item)
        {
            if (_sales.ContainsKey(item.TransactionId))
            {
                _sales[item.TransactionId] = item;
                return item;
            }
            return null;
        }
    }
}
