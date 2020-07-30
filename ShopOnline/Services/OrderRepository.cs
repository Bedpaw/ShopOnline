using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> IsExists(int id)
        {
            var isExists = await _db.Products.AnyAsync(q => q.Id == id);
            return isExists;
        }


        public async Task<bool> Create(Order entity)
        {
            await _db.Orders.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            return await Save();
        }

        public async Task<IList<Order>> FindAll()
        {
            var orders = await _db.Orders
                .Include(c => c.OrderItems)
                .ThenInclude(c => c.Product)
                .ToListAsync();
            return orders;
        }

        public async Task<Order> FindById(int id)
        {
            var product = await _db.Orders.FindAsync(id);
            return product;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Order entity)
        {
            _db.Orders.Update(entity);
            return await Save();
        }
    }
}