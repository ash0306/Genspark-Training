using PharmacyManagementModelLibrary;
using PharmacyManagementDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyManagementBLLibrary.Exceptions;

namespace PharmacyManagementBLLibrary
{
    public class DrugBL : IDrugService
    {
        readonly IRepository<int, Drug> _drugRepository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DrugBL()
        {
            _drugRepository = new DrugRepository();
        }

        /// <summary>
        /// Add a drug
        /// </summary>
        /// <param name="drug"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateFoundException"></exception>
        public int AddDrug(Drug drug)
        {
            var result = _drugRepository.Add(drug);
            if (result != null)
            {
                return result.DrugId;
            }
            throw new DuplicateFoundException("Drug");
        }

        /// <summary>
        /// Delete a drug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public int DeleteDrug(int id)
        {
            var result = _drugRepository.Delete(id);
            if (result != null)
            {
                return result.DrugId;
            }
            throw new NotFoundException("Drug");
        }

        /// <summary>
        /// Delete Expired drugs
        /// </summary>
        /// <returns></returns>
        public int DeleteExpiredDrug()
        {
            int count = 0;
            DateTime currentDate = DateTime.Now;

            List<Drug> drugs = _drugRepository.GetAll();

            foreach (Drug drug in drugs)
            {
                if(drug.ExpiryDate < currentDate)
                {
                    _drugRepository.Delete(drug.DrugId);
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Deletes out of stock drugs
        /// </summary>
        /// <returns></returns>
        public int DeleteOutOfStockDrug()
        {
            int count = 0;
            List<Drug> drugs = _drugRepository.GetAll();

            foreach (Drug drug in drugs)
            {
                if(drug.StockQuantity == 0)
                {
                    _drugRepository.Delete(drug.DrugId);
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// lists all the drugs
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public List<Drug> GetAllDrugs()
        {
            List<Drug> drugs = _drugRepository.GetAll();
            if(drugs.Count == 0)
            {
                throw new NotFoundException("Drug");
            }
            return drugs;
        }

        /// <summary>
        /// Get the details of a drug using its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Drug GetDrugByID(int id)
        {
            var drug = _drugRepository.GetByID(id);
            if(drug != null)
            {
                return drug;
            }
            throw new NotFoundException("Drug");
        }


        /// <summary>
        /// Get details of a drug using its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Drug GetDrugByName(string name)
        {
            var drug = _drugRepository.GetAll().Find(d => d.DrugName == name);
            if (drug == null)
            {
                throw new NotFoundException("Drug");
            }
            return drug;
        }

        /// <summary>
        /// Update a drug
        /// </summary>
        /// <param name="drug"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Drug UpdateDrug(Drug drug)
        {
            var result = _drugRepository.Update(drug);
            if(result != null)
            {
                return result;
            }
            throw new NotFoundException("Drug");
        }
    }
}
