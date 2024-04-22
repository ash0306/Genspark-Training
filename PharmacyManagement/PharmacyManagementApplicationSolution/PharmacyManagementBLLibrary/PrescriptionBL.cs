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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrescriptionBL()
        {
            _prescriptionRepository = new PrescriptionRepository();
        }
        /// <summary>
        /// Adds a prescription
        /// </summary>
        /// <param name="Prescription"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateFoundException"></exception>
        public int AddPrescription(Prescription Prescription)
        {
            var result = _prescriptionRepository.Add(Prescription);
            if (result != null)
            {
                return result.PrescriptionId;
            }
            throw new DuplicateFoundException("Prescription");
        }

        /// <summary>
        /// Checks the availability
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a prescription
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public int DeletePrescription(int id)
        {
            var result = _prescriptionRepository.Delete(id);
            if (result != null)
            {
                return result.PrescriptionId;
            }
            throw new NotFoundException("Prescription");
        }

        /// <summary>
        /// Get a list of all the prescription
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public List<Prescription> GetAllPrescriptions()
        {
            var result = _prescriptionRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new NotFoundException("Prescription");
        }

        /// <summary>
        /// Get a prescription by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
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
