using System.Collections.Generic;
using System.Threading.Tasks;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.BusinessLogic
{
    public class OrderItemLogic : IOrderItemLogic
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemLogic(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<bool> Add(OrderItem orderItem)
        {
            var isSuccess = await _orderItemRepository.Create(orderItem);
            return isSuccess;
        }

        public Task<IList<OrderItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(int id, OrderItem orderItem)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}