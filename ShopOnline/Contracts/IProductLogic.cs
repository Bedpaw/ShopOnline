using System.Threading.Tasks;
using ShopOnline.Data;

namespace ShopOnline.Contracts
{
    public interface IProductLogic
    {
        public Task<bool> AddProduct(Product product);

    }
}