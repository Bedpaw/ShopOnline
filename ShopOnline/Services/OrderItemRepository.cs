using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.Services
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderItemRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task<bool> IsExists(int id)
        {
            var isExists = await _db.OrderItems.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Create(OrderItem entity)
        {
            await _db.OrderItems.AddAsync(entity);
            return await Save();

        }
        public async Task<bool> Delete(OrderItem entity)
        {
            _db.OrderItems.Remove(entity);
            return await Save();
        }

        public async Task<IList<OrderItem>> FindAll()
        {
            var orderItems = await _db.OrderItems.ToListAsync();
            return orderItems;
        }

        public async Task<OrderItem> FindById(int id)
        {
            var orderItem = await _db.OrderItems.FindAsync(id);
            return orderItem;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
        

        public async Task<bool> Update(OrderItem entity)
        {
            _db.OrderItems.Update(entity);
            return await Save();
        }
    }
}