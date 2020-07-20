using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.IRepositoryBase
{
    public interface IRepositoryBase<T> where T : class
    {
        public Task<IList<T>> FindAll();
        public Task<T> FindById(int id);
        public Task<bool> Create(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(T entity);
        public Task<bool> Save();
    }
}
