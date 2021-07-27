using BusinessEntityLayer.Model;
using System.Collections.Generic;
using DALayer.Interfaces;
using DALayer.Implementation;

namespace BusinessLogic.CustomerInfoLogic
{
    public class CustomerBAL
    {
        IDAL CustomerDal = new CustomerDAL();
        public List<Customer> GetCustomers()
        {
            return CustomerDal.GetAll();
        }

        public List<Customer> GetCustomersByName(string name)
        {
            return CustomerDal.GetOneByName(name);
        }

        public bool InsertCustomer(Customer customer)
        {
            return CustomerDal.InsertOne(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return CustomerDal.UpdateOne(customer);
        }

        public bool DeleteCustomer(Customer customer)
        {
            return CustomerDal.DeleteOne(customer);
        }
    }
}
