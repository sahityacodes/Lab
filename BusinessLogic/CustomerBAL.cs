using DALayer;
using BusinessEntityLayer;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CustomerBAL
    {
        IDAL CustomerDal = new CustomerDAL();
        public List<Customer> GetCustomers()
        {
            return CustomerDal.GetCustomers();
        }

        public List<Customer> GetCustomersByName(string name)
        {
            return CustomerDal.GetCustomersByName(name);
        }

        public bool InsertCustomer(Customer customer)
        {
            return CustomerDal.InsertCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return CustomerDal.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(Customer customer)
        {
            return CustomerDal.DeleteCustomer(customer);
        }
    }
}
