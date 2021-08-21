using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;
namespace BusinessLogic.Implementation.CustomerLogic
{
    class CustomerValidationRules
    {
        public void ValidateCustomerForm(Customer customer)
        {
            if (customer.Name.Length == 0)
            {
                throw new BusinessLogicException("Please enter a valid name");
            }
            else if (customer.VAT.Length == 0)
            {
                throw new BusinessLogicException("VAT is Mandatory");
            }
        }
    }
}
