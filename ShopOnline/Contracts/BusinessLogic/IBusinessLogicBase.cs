using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Contracts.BusinessLogic
{
    public interface IBusinessLogicBase<T> where T : class
    {
        public Task<Result> Add(T entity);
        public Task<IList<T>> GetAll();
        public Task<Result> Update(int id, T entity);
        public Task<Result> Delete(int id);
    }
}