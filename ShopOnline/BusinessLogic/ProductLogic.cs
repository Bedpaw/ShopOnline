using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Contracts;
using ShopOnline.Data;
using ShopOnline.DTOs;

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
        /// Add product to db if not duplicated
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        public async Task<bool> AddProduct(Product product)
        {
            var isDuplicated = await _productRepository.IsProductWithEqualName(product.name);
            if (isDuplicated) return false;
            
            var isSuccess = await _productRepository.Create(product);
            return isSuccess;
        }
    }
}