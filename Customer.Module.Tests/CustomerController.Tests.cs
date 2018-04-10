using System.Collections.Generic;
using Customer.Module.Common;
using Customer.Module.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Customer.Module.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {
        private CustomerController cut;
        private Mock<ICustomerService> customerService;
        private Mock<ILogger<CustomerController>> logger;

        [TestInitialize]
        public void Initialize()
        {
            this.customerService = new Mock<ICustomerService>();
            this.logger = new Mock<ILogger<CustomerController>>();
            this.cut = new CustomerController(this.customerService.Object, this.logger.Object);
        }

        [TestMethod]
        public void ShouldGetAllObjects()
        {
            //Arrange
            Mock<IList<Common.Models.Customer>> expectedObject = new Mock<IList<Common.Models.Customer>>();
            this.customerService.Setup(x => x.GetAll())
                .Returns(() => expectedObject.Object);

            //Action
            var result = this.cut.GetAll();

            //Asserts
            this.customerService.Verify(x => x.GetAll(), Times.Once);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.AreEqual((result as ObjectResult).Value, expectedObject.Object);
        }

        [TestMethod]
        public void ShouldDeleteCustomer()
        {
            //Arrange
            const int expectedId = 6;

            //Action
            var result = this.cut.DeleteCustomer(expectedId);

            //Asserts
            this.customerService.Verify(x => x.Remove(expectedId), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ShouldAddCustomer()
        {
            //Arrange
            var expectedObject = new Mock<Common.Models.Customer>();
            expectedObject.Object.Id = 5;

            //Action
            var result = this.cut.AddCustomer(expectedObject.Object);

            //Asserts
            this.customerService.Verify(x => x.Add(expectedObject.Object), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ShouldUpdateCustomer()
        {
            //Arrange
            var expectedObject = new Mock<Common.Models.Customer>();

            //Action
            var result = this.cut.AddCustomer(expectedObject.Object);

            //Asserts
            this.customerService.Verify(x => x.Add(expectedObject.Object), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
