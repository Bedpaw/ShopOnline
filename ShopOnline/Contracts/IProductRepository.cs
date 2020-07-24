using System.Threading.Tasks;
using ShopOnline.Data;

namespace ShopOnline.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public Task<bool> IsProductWithEqualName(string name);
        
    }
}


