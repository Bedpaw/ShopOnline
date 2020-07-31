using System.Threading.Tasks;
using ShopOnline.Data;

namespace ShopOnline.Contracts.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Task<bool> IsCustomerWithEqualName(string name);
        public Task<bool> IsCustomerWithEqualSurname(string surname);
    }
}