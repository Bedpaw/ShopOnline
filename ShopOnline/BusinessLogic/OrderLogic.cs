﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Contracts.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Data;

namespace ShopOnline.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {       
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;


        public OrderLogic(IOrderRepository orderRepository, IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;

        }
        public async Task<bool> Add(Order order)
        {    
            
            order.Customer = await _customerRepository.FindById(order.CustomerId);
            
            var isSuccess = await _orderRepository.Create(order);
            return isSuccess;
        }
        

        public async Task<IList<Order>> GetAll()
        {
            var orders = await _orderRepository.FindAll();
            return orders;
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