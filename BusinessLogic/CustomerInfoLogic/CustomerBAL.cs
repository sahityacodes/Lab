using BusinessEntityLayer.Model;
using System.Collections.Generic;
using DALayer.Interfaces;
using DALayer.Implementation;
using System;

namespace BusinessLogic.CustomerInfoLogic
{
    public class CustomerBAL
    {
        readonly IDAL<Customer> CustomerDal = new CustomerDAL();
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
            if (customer.CustomerName.Length == 0)
            {
                throw new NullReferenceException("Please enter a valid name");
            }
            else { 
                return CustomerDal.InsertOne(customer);
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                throw new NullReferenceException("Please enter a valid name");
            }
            else
            {
                return CustomerDal.UpdateOne(customer);
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            return CustomerDal.DeleteOne(customer);
        }
    }
}
