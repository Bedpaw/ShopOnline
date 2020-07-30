using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> IsExists(int id)
        {
            var isExists = await _db.Customers.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> IsCustomerWithEqualName(string name)
        {
            var isExistName = await _db.Customers.AnyAsync(r => r.FirstName == name);
            return isExistName;
        }

        public async Task<bool> IsCustomerWithEqualSurname(string surname)
        {
            var isExistSurname = await _db.Customers.AnyAsync(r => r.LastName == surname);
            return isExistSurname;
        }

        public async Task<bool> Create(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            return await Save();
        }

        public async Task<bool> Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
            return await Save();
        }

        public async Task<IList<Customer>> FindAll()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> FindById(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            return customer;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Customer customer)
        {
            _db.Customers.Update(customer);
            return await Save();
        }
    }
}