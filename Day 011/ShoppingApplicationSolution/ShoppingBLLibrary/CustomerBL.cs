using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _customerRepository;

        [ExcludeFromCodeCoverage]
        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }
        [ExcludeFromCodeCoverage]
        public CustomerBL(IRepository<int, Customer> repository)
        {
            
            _customerRepository = repository;
        }
        public async Task<int> AddCustomer(Customer customer)
        {
            var result = await _customerRepository.Add(customer);
            if(result != null)
            {
                return result.Id;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var result = await _customerRepository.Delete(id);
            if(result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var result = await _customerRepository.GetAll();
            if(result != null)
            {
                return result.ToList();
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var result = await _customerRepository.GetByKey(id);
            if( result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await _customerRepository.Update(customer);
            if (result != null)
            {
                return result;
            }
            throw new NoCustomerWithGiveIdException();
        }
        [ExcludeFromCodeCoverage]
        public async Task<Customer> GetCustomerByName(string name)
        {
            var customer = await _customerRepository.GetAll();
            var returnCustomer = customer.ToList().Find(e => e.Name == name);
            if (returnCustomer == null)
            {
                throw new NoCustomerWithGiveIdException();
            }
            return returnCustomer;
        }
    }
}
