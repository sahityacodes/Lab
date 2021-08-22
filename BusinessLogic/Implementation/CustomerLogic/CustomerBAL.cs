using BusinessEntityLayer.Model;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using EntityManagementLayer.Interfaces;
using EntityManagementLayer.Implementation;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Implementation.CustomerLogic
{
    public class CustomerBAL : ICustomerBLL<Customer>
    {
        readonly ICustomerEntityManager<Customer> CustomerDal = new CustomerMapper();
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
            return CustomerDal.InsertOne(customer);
        }

        public bool UpdateOne(Customer customer)
        {
            return CustomerDal.UpdateOne(customer);
        }

        public bool DeleteAll(int Id)
        {
            return CustomerDal.DeleteAll(Id);
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
        public bool CheckIfCustomerExists(int ID)
        {
            return CustomerDal.CheckIfCustomerExists(ID);
        }

        public bool DeleteOne(int Id, int rowID)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCustomer(Customer obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
