using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;
using ShopOnline.Utils;

namespace ShopOnline.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {       
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderLogic(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;

        }
        public async Task<Result> Add(Order order)
        {    
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.Product = await _productRepository.FindById(orderItem.ProductId);
            }

            var isSuccess = await _orderRepository.Create(order);

            return isSuccess? Result.Ok() : Result.Fail(CustomErrors.AddOrderUnable);
        }
        

        public async Task<IList<Order>> GetAll()
        {
            var orders = await _orderRepository.FindAll();
            return orders;
        }

        public Task<Result> Update(int id, Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Delete(int id)
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