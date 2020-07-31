using ShopOnline.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Contracts.BusinessLogic
{
    public interface IOrderLogic : IBusinessLogicBase<Order>
    {
        public Task<IList<Order>> GetAllByCustomerName(int customerId);
    }
}