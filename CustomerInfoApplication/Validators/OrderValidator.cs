using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;

namespace CustomerInfoApplication.Validators
{
    class OrderValidator
    {
        public bool ValidateOrder(SalesOrders order)
        {
            if (order.DateOrder > order.OrderSummary.DeliveryDate)
            {
                throw new BusinessLogicException("The Delivery Date is sooner than the Date of Order. Please change it");
            }
            if (order.OrderSummary.ShippingAddress.Length <= 0)
            {
                throw new BusinessLogicException("Please enter a valid shipping address");
            }
            return true;
        }
    }
}
