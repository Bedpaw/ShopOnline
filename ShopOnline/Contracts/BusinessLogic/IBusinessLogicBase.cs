using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Contracts.BusinessLogic
{
    public interface IBusinessLogicBase<T> where T : class
    {
        public Task<bool> Add(T entity);
        public Task<IList<T>> GetAll();
        public Task<bool> Update(int id, T entity);
        public Task<bool> Delete(int id);
    }
}