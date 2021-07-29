using BusinessEntityLayer.Model;
using System.Collections.Generic;
using DALayer.Interfaces;
using DALayer.Implementation;
using System;
using BusinessLogic.Interfaces;
using BusinessLogic.Exceptions;

namespace BusinessLogic.CustomerInfoLogic
{
    public class CustomerBAL : IBLL<Customer>
    {
        readonly IDAL<Customer> CustomerDal = new CustomerDAL();
        public List<Customer> GetAll()
        {
            return CustomerDal.GetAll();
        }

        public List<Customer> GetOneByName(string name)
        {
            return CustomerDal.GetOneByName(name);
        }

        public bool InsertOne(Customer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                throw new UserDefinedException("Please enter a valid name");
            }
            else { 
                return CustomerDal.InsertOne(customer);
            }
        }

        public bool UpdateOne(Customer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                throw new UserDefinedException("Please enter a valid name");
            }
            else
            {
                return CustomerDal.UpdateOne(customer);
            }
        }

        public bool DeleteOne(Customer customer)
        {
            return CustomerDal.DeleteOne(customer);
        }
    }
}
