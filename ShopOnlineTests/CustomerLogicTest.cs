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

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);

        }
    }
}
