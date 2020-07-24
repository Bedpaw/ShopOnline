using System.Collections.Generic;
using System.Threading.Tasks;
using ShopOnline.Data;

namespace ShopOnline.Contracts
{
    public interface IBusinessLogicBase<T> where T : class
    {
        public Task<bool> Add(T entity);
        public Task<IList<T>> GetAll();
        public Task<bool> Update(int id, T entity);
        public Task<bool> Delete(int id);
    }
}