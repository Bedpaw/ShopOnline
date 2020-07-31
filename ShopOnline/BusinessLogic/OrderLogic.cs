using System;
using System.Collections.Generic;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;


        public OrderLogic(IOrderRepository orderRepository,
            IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Result> Add(Order order)
        {
            order.Customer = await _customerRepository.FindById(order.CustomerId);

            if (!await _customerRepository.IsExists(order.CustomerId))
                return Result.Fail(CustomErrors.CustomerByGivenIdNotExists);

            foreach (var orderItem in order.OrderItems)
            {
                var product = await _productRepository.FindById(orderItem.ProductId);

                if (product == null) return Result.Fail(CustomErrors.NotExistByGivenId);

                if (orderItem.Quantity <= product.AvailableQuantity)
                    return Result.Ok();
                //product.
                return Result.Fail(new Error(CustomErrors.AddOrderUnable));
            }

            var isSuccess = await _orderRepository.Create(order);

            return isSuccess ? Result.Ok() : Result.Fail(CustomErrors.AddOrderUnable);
        }


        public async Task<IList<Order>> GetAll()
        {
            var orders = await _orderRepository.FindAll();
            return orders;
        }

        public Task<Result> Update(int id, Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> GetAllByCustomerName(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddEmptyOrder(Order entity, int customerId)
        {
            throw new NotImplementedException();
        }
    }
}