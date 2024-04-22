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
        public DrugBL()
        {
            _drugRepository = new DrugRepository();
        }
        public int AddDrug(Drug drug)
        {
            var result = _drugRepository.Add(drug);
            if (result != null)
            {
                return result.DrugId;
            }
            throw new DuplicateFoundException("Drug");
        }

        public int DeleteDrug(int id)
        {
            var result = _drugRepository.Delete(id);
            if (result != null)
            {
                return result.DrugId;
            }
            throw new NotFoundException("Drug");
        }

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

        public List<Drug> GetAllDrugs()
        {
            List<Drug> drugs = _drugRepository.GetAll();
            if(drugs.Count == 0)
            {
                throw new NotFoundException("Drug");
            }
            return drugs;
        }

        public Drug GetDrugByID(int id)
        {
            var drug = _drugRepository.GetByID(id);
            if(drug != null)
            {
                return drug;
            }
            throw new NotFoundException("Drug");
        }

        public Drug GetDrugByName(string name)
        {
            var drug = _drugRepository.GetAll().Find(d => d.DrugName == name);
            if (drug == null)
            {
                throw new NotFoundException("Drug");
            }
            return drug;
        }

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
