using ShopOnline.Data;
using ShopOnline.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{
    Task<bool> IRepositoryBase<Product>.Create(Product entity)
    {
        throw new NotImplementedException();
    }

    Task<bool> IRepositoryBase<Product>.Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    Task<IList<Product>> IRepositoryBase<Product>.FindAll()
    {
        throw new NotImplementedException();
    }

    Task<Product> IRepositoryBase<Product>.FindById()
    {
        throw new NotImplementedException();
    }

    Task<bool> IRepositoryBase<Product>.Save()
    {
        throw new NotImplementedException();
    }

    Task<bool> IRepositoryBase<Product>.Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
