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
    public class SalesBl : ISalesService
    {
        readonly IRepository<int, Sales> _salesRepository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesBl()
        {
            _salesRepository = new SalesRepository();
        }

        /// <summary>
        /// Adds a sale
        /// </summary>
        /// <param name="Sales"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateFoundException"></exception>
        public int AddSale(Sales Sales)
        {
            var result = _salesRepository.Add(Sales);
            if (result != null)
            {
                return result.TransactionId;
            }
            throw new DuplicateFoundException("Sale");
        }

        /// <summary>
        /// Get a list of all the sales
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public List<Sales> GetAllSales()
        {
            var result = _salesRepository.GetAll();
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Sale");
        }

        /// <summary>
        /// Get a sale by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public Sales GetSaleByID(int id)
        {
            var result = _salesRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Sale");
        }

        /// <summary>
        /// Get the total price of all sales
        /// </summary>
        /// <returns></returns>
        public double GetTotalSalePrice()
        {
            double totalPrice = 0;
            var result = _salesRepository.GetAll();
            foreach (var item in result)
            {
                totalPrice += item.TotalSaleAmount;
            }
            return totalPrice;
        }
    }
}
