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

        public SalesBl()
        {
            _salesRepository = new SalesRepository();
        }

        public int AddSale(Sales Sales)
        {
            var result = _salesRepository.Add(Sales);
            if (result != null)
            {
                return result.TransactionId;
            }
            throw new DuplicateFoundException("Sale");
        }

        public List<Sales> GetAllSales()
        {
            var result = _salesRepository.GetAll();
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Sale");
        }

        public Sales GetSaleByID(int id)
        {
            var result = _salesRepository.GetByID(id);
            if (result != null)
            {
                return result;
            }
            throw new NotFoundException("Sale");
        }

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
