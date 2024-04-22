using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public interface ISalesService
    {
        int AddSale(Sales Sales);
        int DeleteSale(int id);
        Sales GetSaleByID(int id);
        List<Sales> GetAllSales();
        double GetTotalSalePrice();
    }
}
