using ShopOnline.BusinessLogic;
using ShopOnline.Contracts.Repository;
using ShopOnline.Controllers;
using ShopOnline.Data;
using ShopOnline.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XShopOnlineTests
{
    public class CustomerLogicTests
    {
        private ICustomerRepository customerRepository;

        [Fact]
        public async Task GetAllCustomers_ShouldReturnAllCustomers() // nie dzia³a
        {
            var customersTest = GetAllTestCustomers();

            var controller = new CustomerLogic(customerRepository);

            var result = await controller.GetAll() as List<Customer>;

            Assert.Equal(customersTest.Count, result.Count);
        }
        private List<Customer> GetAllTestCustomers()
        {
            var customersTest = new List<Customer>();
            customersTest.Add(new Customer
            { Id = 1, FirstName = "Romek",
                LastName = "Ziomek", 
                Phone = "666666666", 
                Email = "romekziomek@cool.pl",
                Street = "Wojskowa 1",
                City = "Pcim Maly",
                ZipCode = "77666"
            });
            

            return customersTest;
        }
       
    }
}
