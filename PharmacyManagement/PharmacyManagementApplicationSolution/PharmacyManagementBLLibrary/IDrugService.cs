using PharmacyManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementBLLibrary
{
    public interface IDrugService
    {
        int AddDrug(Drug drug);
        Drug UpdateDrug(Drug drug);
        int DeleteDrug(int id);
        int DeleteOutOfStockDrug();
        int DeleteExpiredDrug();
        Drug GetDrugByID(int id);
        Drug GetDrugByName(string name);
        List<Drug> GetAllDrugs();
    }
}
