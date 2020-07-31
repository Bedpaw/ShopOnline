using System;
using Xunit;

namespace XShopOnlineTests
{
    public class CustomerLogicTests
    {
        [Fact]
        public async Task GetAllCustomers_ShouldReturnAllCustomers()
        {
            var customersTest = GetAllCustomers();

            var controller = new CustomerController();

            var result = controller.GetCustomers() as List<Customer>;

            Assert.AreEqual(customersTest.Count, result.Count);
        }
}
