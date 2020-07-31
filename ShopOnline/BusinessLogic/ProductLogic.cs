using FluentResults;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;
using ShopOnline.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        ///     Add product to db if not duplicated
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Result> Add(Product product)
        {
            var isDuplicated = await _productRepository.IsProductWithEqualName(product.Name);
            if (isDuplicated) return Result.Fail(CustomErrors.ProductDuplicated);

            await _productRepository.Create(product);
            return Result.Ok();
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _productRepository.FindAll();
        }


        public async Task<Result> Update(int id, Product product)
        {
            var isExists = await _productRepository.IsExists(id);
            if (!isExists) return Result.Fail(CustomErrors.NotExistByGivenId);
            await _productRepository.Update(product);
            return Result.Ok();
        }

        public async Task<Result> Delete(int id)
        {
            var isExists = await _productRepository.IsExists(id);
            if (!isExists) return Result.Fail(CustomErrors.NotExistByGivenId);

            var product = await _productRepository.FindById(id);
            await _productRepository.Delete(product);
            return Result.Ok();
        }
    }
}