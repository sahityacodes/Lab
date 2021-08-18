using BusinessEntityLayer.Model;
using System.Collections.Generic;
using DALayer.Interfaces;
using DALayer.Implementation;
using BusinessLogic.Interfaces;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Implementation.CustomerLogic
{
    public class CustomerBAL : ICustomerBLL<Customer>
    {
        readonly ICustomerDAL<Customer> CustomerDal = new CustomerDAL();
        CustomerValidationRules validateCust = new();
        public List<Customer> GetAll()
        {
            return CustomerDal.GetAll();
        }

        public List<Customer> GetOneByName(string name)
        {
            return CustomerDal.GetAllByKeyWord(name);
        }

        public bool InsertOne(Customer customer)
        {
            validateCust.ValidateCustomerForm(customer);
            return CustomerDal.InsertOne(customer);
        }

        public bool UpdateOne(Customer customer)
        {
            validateCust.ValidateCustomerForm(customer);
            return CustomerDal.UpdateOne(customer);
        }

        public bool DeleteOne(int Id)
        {
            return CustomerDal.DeleteOne(Id);
        }

        public List<Customer> SortByColumnAscending(string colName)
        {
            return CustomerDal.SortByColumnAscending(colName);
        }

        public List<Customer> SortByColumnDescending(string colName)
        {
            return CustomerDal.SortByColumnDescending(colName);
        }



        public Customer GetOne(int OrderID)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetCustomerOrdersCost()
        {
            return CustomerDal.GetCustomerOrdersCost();
        }
    }
}
