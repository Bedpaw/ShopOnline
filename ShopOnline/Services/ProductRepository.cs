using Microsoft.EntityFrameworkCore;
using ShopOnline.Contracts;
using ShopOnline.Data;
using ShopOnline.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Services.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Product entity)
        {
            await _db.Products.AddAsync(entity);
            return await Save();

        }

        public async Task<bool> Delete(Product entity)
        {
            _db.Products.Remove(entity);
            return await Save();
        }

        public async Task<IList<Product>> FindAll()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }

        public async Task<Product> FindById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return product;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Product entity)
        {
            _db.Products.Update(entity);
            return await Save();
        }
    }

}
