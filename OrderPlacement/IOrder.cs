using System;
using System.Linq;

namespace OrderPlacement
{
    public interface IOrder
    {
        OrderConfirmation PlaceOrder(int productId, int quantity, string creditCardNumber);
    }
    public class Order: IOrder
    {
        private IService _service { get; set; }
        public Order(IService service)
        {
            _service = service;
        }

        public OrderConfirmation PlaceOrder(int productId, int quantity, string creditCardNumber)
        {
            var selectedProduct = TestData.GetProducts().SingleOrDefault(p => p.Id == productId);
            if (selectedProduct == null)
            {
                throw new Exception("Invalid Product.");
            }
            if(quantity <= 0)
            {
                throw new Exception("Quantity Not selected.");
            }

            if(!TestData.GetInventory().Single(i => i.ProductId == productId).IsAvailable(quantity))
            {
                throw new Exception("Insufficient quantity.");
            }

            var totalCost = selectedProduct.Cost * quantity;
            var isProcessed = _service.ChargePayment(creditCardNumber, totalCost);

            if (isProcessed)
            {
                _service.SendEmail();
            }
            else
            {
                throw new Exception("Payment processing failed.");
            }

            return new OrderConfirmation {
                Message = "Your order has been successfully processed"
            };
        }
    }

    public class OrderConfirmation
    {
        public string Message { get; set; }
    }
}
