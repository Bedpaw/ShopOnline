using System.Collections.Generic;
using System.Threading.Tasks;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<IList<Customer>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Create(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }
    }
}