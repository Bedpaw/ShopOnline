using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShopOnline.Contracts;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
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
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> Add(Product product)
        {
            var isDuplicated = await _productRepository.IsProductWithEqualName(product.Name);
            if (isDuplicated) return false;
            
            var isSuccess = await _productRepository.Create(product);
            return isSuccess;
        }

        public async  Task<IList<Product>> GetAll()
        {
            return await _productRepository.FindAll();
        }


        public async Task<bool> Update(int id, Product product)
        {
            var isExists = await _productRepository.IsExists(id);
            if (!isExists) return false;
            
            var isSuccess = await _productRepository.Update(product);
            return isSuccess;
        }

        public async Task<bool> Delete(int id)
        {
            var isExists = await _productRepository.IsExists(id);
            if (!isExists) return false;
            
            var product = await _productRepository.FindById(id);
            var isSuccess = await _productRepository.Delete(product);
            return isSuccess;
        }
    }
}