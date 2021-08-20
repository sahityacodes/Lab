using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementation.CustomerLogic;
using System;
using System.Collections.Generic;


namespace CustomerInfoApplication.Controllers
{
    class CustomerController
    {
        readonly ICustomerBLL<Customer> CustomerBal = new CustomerBAL();

        public List<Customer> GetAll()
        {
            return CustomerBal.GetAll();
        }

        public List<Customer> GetOneByName(string keyword)
        {
            return CustomerBal.GetOneByName(keyword);
        }

        public List<Customer> GetCustomerOrdersCost()
        {
            return CustomerBal.GetCustomerOrdersCost();
        }

        public List<Customer> SortByColumnAscending(string columnName)
        {
            return CustomerBal.SortByColumnAscending(columnName);
        }

        public List<Customer> SortByColumnDescending(string columnName)
        {
            return CustomerBal.SortByColumnDescending(columnName);
        }

        public bool InsertCustomer(Customer customer)
        {
            return  CustomerBal.InsertOne(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return CustomerBal.UpdateOne(customer);
        }

        internal bool DeleteCustomer(int customer)
        {
            return CustomerBal.DeleteAll(customer);
        }
    }
}
