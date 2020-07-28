using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;
using ShopOnline.Utils;

namespace ShopOnline.BusinessLogic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Result> Add(Customer customer)
        {
            var isSuccess = await _customerRepository.Create(customer);
            return isSuccess ? Result.Ok() : Result.Fail(CustomErrors.AddCustomerError);
        }

        public async Task<IList<Customer>> GetAll()
        {
            var customers = await _customerRepository.FindAll();
            return customers;
        }

        public Task<Result> Update(int id, Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}