using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
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
        public async Task<Result> Add(OrderItem orderItem)
        {
            
            await _orderItemRepository.Create(orderItem);
            return Result.Ok();
        }

        public Task<IList<OrderItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Update(int id, OrderItem orderItem)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}