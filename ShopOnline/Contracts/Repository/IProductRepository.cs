﻿using ShopOnline.Data;
using System.Threading.Tasks;

namespace ShopOnline.Contracts.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public Task<bool> IsProductWithEqualName(string name);
        public Task<bool> RemoveProductQuantityById(int id, int valueToReduce);

    }
}