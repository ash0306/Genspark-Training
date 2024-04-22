using PharmacyManagementBLLibrary.Exceptions;
using PharmacyManagementDALLibrary;
using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public class PrescriptionBL : IPrescriptionService
    {
        readonly IRepository<int, Prescription> _prescriptionRepository;
        public PrescriptionBL()
        {
            _prescriptionRepository = new PrescriptionRepository();
        }
        public int AddPrescription(Prescription Prescription)
        {
            var result = _prescriptionRepository.Add(Prescription);
            if (result != null)
            {
                return result.PrescriptionId;
            }
            throw new DuplicateFoundException("Prescription");
        }

        public List<Drug> CheckAvailability()
        {
            List<Drug> lowStock = new List<Drug>();
            var prescriptions = _prescriptionRepository.GetAll();
            foreach (var p in prescriptions)
            {
                foreach (var drug in p.PrescribedDrugs)
                {
                    if(drug.StockQuantity < 5)
                    {
                        lowStock.Add(drug);
                    }
                }
            }
            return lowStock;
        }

        public int DeletePrescription(int id)
        {
            var result = _prescriptionRepository.Delete(id);
            if (result != null)
            {
                return result.PrescriptionId;
            }
            throw new NotFoundException("Prescription");
        }

        public List<Prescription> GetAllPrescriptions()
        {
            var result = _prescriptionRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new NotFoundException("Prescription");
        }

        public Prescription GetPrescriptionByID(int id)
        {
            var result = _prescriptionRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Prescription");
        }
    }
}
