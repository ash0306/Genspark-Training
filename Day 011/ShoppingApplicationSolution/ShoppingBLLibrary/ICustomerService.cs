using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
