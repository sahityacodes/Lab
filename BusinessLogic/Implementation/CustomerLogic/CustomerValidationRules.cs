using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Implementation.CustomerLogic
{
    class CustomerValidationRules
    {
        internal void ValidateCustomerForm(Customer customer)
        {
            if (customer.Name.Length == 0)
            {
                throw new UserDefinedException("Please enter a valid name");
            }
            else if (customer.VAT.Length == 0)
            {
                throw new UserDefinedException("VAT is Mandatory");
            }
        }
    }
}
