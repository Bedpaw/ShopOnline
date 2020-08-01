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
        private readonly ICustomerRepository _customerRepository;


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
            var result = true;

            /*if (!await _customerRepository.IsExists(order.CustomerId))
                return Result.Fail(new Error(CustomErrors.AddOrderUnable));*/


            // var orderCustomer = await _customerRepository.FindById(order.CustomerId);

            if (result)
            {
                await _orderRepository.Create(order);
                return Result.Ok();
            }
            return Result.Fail(new Error(CustomErrors.AddOrderUnable));
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