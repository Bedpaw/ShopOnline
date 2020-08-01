using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopOnlineTests
{
    [TestClass]
    public class CustomerLogicTest
    {
        [TestMethod]
        public async Task GetAllCustomers_ShouldReturnAllCustomers()
        {
            var customersTest = GetAllCustomers();

            var controller = new CustomerController();

            var result = controller.GetCustomers() as List<Customer>;

            Assert.AreEqual(customersTest.Count, result.Count);

        }
    }
}
