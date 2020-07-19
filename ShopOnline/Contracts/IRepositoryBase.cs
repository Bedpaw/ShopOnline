using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.IRepositoryBase
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> FindAll();
        Task<T> FindById();
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}
