using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementModelLibrary
{
    public class Sales
    {
        public int TransactionId { get; set; }
        public string SalesType {  get; set; }
        public double TotalSaleAmount {  get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Sales()
        {
            TransactionId = 0;
            SalesType = string.Empty;
            TotalSaleAmount = 0.0;
        }

        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="salesType">Type of sale as string</param>
        /// <param name="totalSaleAmount">Total sale amount</param>
        public Sales(int transactionId, string salesType, double totalSaleAmount)
        {
            TransactionId = transactionId;
            SalesType = salesType;
            TotalSaleAmount = totalSaleAmount;
        }

        public override string ToString()
        {
            return "Transaction ID: " + TransactionId
                + "Sales Type: " + SalesType
                + "Total Amount of Sale: " + TotalSaleAmount;
        }
    }
}
