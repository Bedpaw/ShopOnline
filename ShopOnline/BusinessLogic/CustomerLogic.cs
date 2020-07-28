using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
            var  isExistName = await _customerRepository.IsCustomerWithEqualName(customer.FirstName);
            var  isExistSurname = await _customerRepository.IsCustomerWithEqualSurname(customer.LastName);

            if (isExistName && isExistSurname) return false;
            
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
            var isExist = await _customerRepository.IsExists(id);
            if (!isExist) return false;
            
            var isSuccess = await _customerRepository.Update(entity);
            return isSuccess;


        }
       

        public Task<Result> Delete(int id)
        {
            var isExist = await _customerRepository.IsExists(id);
            if (!isExist) return false;

            var customer = await _customerRepository.FindById(id);
            var isSuccess = await _customerRepository.Delete(customer);
            return isSuccess;
        }
    }
}