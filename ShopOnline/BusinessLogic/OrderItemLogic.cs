using FluentResults;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Task<Result> Update(int id, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}