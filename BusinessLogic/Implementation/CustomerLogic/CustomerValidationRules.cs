using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;
using DALayer.DTO;
using DALayer.Interfaces;

namespace BusinessLogic.Implementation.CustomerLogic
{
    class CustomerValidationRules
    {
        readonly ICustomerDAL<Customer> CustomerDal = new CustomerDAL();
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
