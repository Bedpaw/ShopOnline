using System.Collections.Generic;
using System.Threading.Tasks;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.BusinessLogic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Add(Customer customer)
        {
            var isSuccess = await _customerRepository.Create(customer);
            return isSuccess;
        }

        public async Task<IList<Customer>> GetAll()
        {
            var customers = await _customerRepository.FindAll();
            return customers;
        }

        public Task<bool> Update(int id, Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}