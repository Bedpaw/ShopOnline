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

        private async Task<Result> IsOrderValid(Order order)
        {
          //  var isCustomerExist = await _customerRepository.IsExists(order.CustomerId);
           // if (!isCustomerExist)
          //  {
           //     return Result.Fail(CustomErrors.CustomerByGivenIdNotExists);
           // }
            
            foreach (var orderItem in order.OrderItems)
            {
                var product = await _productRepository.FindById(orderItem.ProductId);

                if (product == null) return Result.Fail(CustomErrors.NotExistByGivenId);

                if (orderItem.Quantity >= product.AvailableQuantity)
                {
                    return Result.Fail(new Error(CustomErrors.NotEnoughProductsInStore(
                                product.Name,
                                orderItem.Quantity,
                                product.AvailableQuantity)));
                }
            }
            return Result.Ok();
        }

        private async Task<Result> RemoveProductsFromStore(Order order)
        {
            foreach (var orderItem in order.OrderItems)
            {
                await _productRepository.RemoveProductQuantityById(orderItem.ProductId, orderItem.Quantity);
                
            }

            return Result.Ok();
        }
        public async Task<Result> Add(Order order)
        {
            var result =  await IsOrderValid(order);
            
            /*if (!await _customerRepository.IsExists(order.CustomerId))
                return Result.Fail(new Error(CustomErrors.AddOrderUnable));*/


            // var orderCustomer = await _customerRepository.FindById(order.CustomerId);

            if (result.IsSuccess)
            {
                await RemoveProductsFromStore(order);
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