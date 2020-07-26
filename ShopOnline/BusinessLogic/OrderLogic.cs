using System.Collections.Generic;
using System.Threading.Tasks;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {       
        private readonly IOrderRepository _orderRepository;

        public OrderLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Add(Order order)
        {    
            order.OrderStatus = 0;
            var isSuccess = await _orderRepository.Create(order);
            return isSuccess;
        }

        public Task<IList<Order>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(int id, Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Order>> GetAllByCustomerName(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddEmptyOrder(Order entity, int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}