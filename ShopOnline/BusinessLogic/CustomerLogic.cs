using FluentResults;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;
using ShopOnline.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var isExistName = await _customerRepository.IsCustomerWithEqualName(customer.FirstName);
            var isExistSurname = await _customerRepository.IsCustomerWithEqualSurname(customer.LastName);

            if (isExistName && isExistSurname) return Result.Fail(CustomErrors.BusinessLogicError);

            var isSuccess = await _customerRepository.Create(customer);
            return isSuccess ? Result.Ok() : Result.Fail(CustomErrors.AddCustomerError);
        }

        public async Task<IList<Customer>> GetAll()
        {
            var customers = await _customerRepository.FindAll();
            return customers;
        }


        public async Task<Result> Update(int id, Customer entity)
        {
            var isExist = await _customerRepository.IsExists(id);
            if (!isExist) return Result.Fail(CustomErrors.BusinessLogicError);

            var isSuccess = await _customerRepository.Update(entity);
            return isSuccess ? Result.Ok() : Result.Fail(CustomErrors.BusinessLogicError);
        }


        public async Task<Result> Delete(int id)
        {
            var isExist = await _customerRepository.IsExists(id);
            if (!isExist) return Result.Fail(CustomErrors.BusinessLogicError);

            var customer = await _customerRepository.FindById(id);
            var isSuccess = await _customerRepository.Delete(customer);
            return isSuccess ? Result.Ok() : Result.Fail(CustomErrors.BusinessLogicError);
        }
    }
}