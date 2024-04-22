using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementDALLibrary
{
    public class DrugRepository : IRepository<int, Drug>
    {
        private readonly Dictionary<int, Drug> _drugs;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DrugRepository()
        {
            _drugs = new Dictionary<int, Drug>();
        }

        /// <summary>
        /// Function to generate ID
        /// </summary>
        /// <returns></returns>
        private int GenerateId()
        {
            if(_drugs.Count == 0) return 1;
            int id = _drugs.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Add a drug
        /// </summary>
        /// <param name="item">Drug class object</param>
        /// <returns></returns>
        public Drug Add(Drug item)
        {
            if (_drugs.ContainsValue(item)) return null;
            int id = GenerateId();
            item.DrugId = id;
            _drugs.Add(id, item);
            return item;
        }

        /// <summary>
        /// Delete a drug
        /// </summary>
        /// <param name="key">ID of the drug to be deleted</param>
        /// <returns></returns>
        public Drug Delete(int key)
        {
            if (_drugs.ContainsKey(key))
            {
                var drug = _drugs[key];
                _drugs.Remove(key);
                return drug;
            }
            return null;
        }

        /// <summary>
        /// Display all drugs
        /// </summary>
        /// <returns></returns>
        public List<Drug> GetAll()
        {
            if (_drugs.Count == 0) return null;
            return _drugs.Values.ToList();
        }

        /// <summary>
        /// Get details of 1 drug
        /// </summary>
        /// <param name="key">ID of drug to be fetched</param>
        /// <returns></returns>
        public Drug GetByID(int key)
        {
            return _drugs.ContainsKey(key) ? _drugs[key] : null;
        }

        /// <summary>
        /// Update the details
        /// </summary>
        /// <param name="item">Drug class object</param>
        /// <returns></returns>
        public Drug Update(Drug item)
        {
            if (_drugs.ContainsKey(item.DrugId))
            {
                _drugs[item.DrugId] = item;
                return item;
            }
            return null;
        }
    }
}
