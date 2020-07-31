using System.Threading.Tasks;
using ShopOnline.Data;

namespace ShopOnline.Contracts.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public Task<bool> IsProductWithEqualName(string name);
    }
}