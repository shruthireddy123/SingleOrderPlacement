using Moq;
using NUnit.Framework;
using OrderPlacement;
using System;
using System.Linq;

namespace OrderTesting
{
    public class OrderTest
    {
        private Order _orderSerive { get; set; }
        private Mock<IService> _mockService { get; set; }
        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IService>();
            _mockService.Setup(s => s.ChargePayment(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);
            _orderSerive = new Order(_mockService.Object);
        }

        [Test]
        public void Should_raise_an_error_with_invalid_productId()
        {
            var ex = Assert.Throws<Exception>(() => _orderSerive.PlaceOrder(50, 10, "123456"));
            Assert.AreEqual("Invalid Product.", ex.Message);
        }

        [Test]
        public void Should_raise_an_error_with_no_quantity()
        {
            var ex = Assert.Throws<Exception>(() => _orderSerive.PlaceOrder(1, 0, "123456"));
            Assert.AreEqual("Quantity Not selected.", ex.Message);
        }

        [Test]
        public void Should_raise_an_error_with_insufficient_quantity()
        {
            var ex = Assert.Throws<Exception>(() => _orderSerive.PlaceOrder(1, 1000, "123456"));
            Assert.AreEqual("Insufficient quantity.", ex.Message);
        }

        [Test]
        public void Should_process_order_successfully()
        {
            var result = _orderSerive.PlaceOrder(1, 1, "123456");
            var product = TestData.GetProducts().Single(p => p.Id == 1);
            var payment = 1 * product.Cost;
            _mockService.Verify(mock => mock.ChargePayment("123456", payment), Times.Once);
            Assert.AreEqual("Your order has been successfully processed", result.Message);
        }
    }
}