using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;
using BusinessLogic.Implementation.CustomerLogic;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Implementation.OrderLogic
{
    class OrderValidationRules
    {
        readonly ICustomerBLL<Customer> CustomerBal = new CustomerBAL();
        internal void ValidateCustomerForm(SalesOrders order)
        {
            if (!CustomerBal.CheckIfCustomerExists(order.CustomerID))
            {
                throw new UserDefinedException("The entered CustomerID doesnt exist.");
            }
            if (order.DateOrder > order.OrderSummary.DeliveryDate)
            {
                throw new UserDefinedException("The Delivery Date is sooner than the Date of Order. Please change it");
            }
        }
    }
}
