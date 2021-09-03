using BusinessEntityLayer.Model;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using EntityManagementLayer.Interfaces;
using EntityManagementLayer.Implementation;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Implementation.CustomerLogic
{
    public class CustomerBAL : IBLL<Customer>
    {
        public List<Customer> GetAll()
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.GetAll();
        }

        public List<Customer> GetOneByName(string name)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.GetAllByKeyWord(name);
        }

        public bool InsertOne(Customer customer)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.InsertOne(customer);
        }

        public bool UpdateOne(Customer customer)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.UpdateOne(customer);
        }

        public bool DeleteAll(int Id)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.DeleteAll(Id);
        }

        public List<Customer> SortByColumnAscending(string colName)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.SortByColumnAscending(colName);
        }

        public List<Customer> SortByColumnDescending(string colName)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.SortByColumnDescending(colName);
        }

        public Customer GetOne(int customerID)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.GetOne(customerID);
        }

        public List<Customer> GetCustomerOrdersCost()
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.GetCustomerOrdersCost();
        }
        public bool CheckIfCustomerExists(int ID)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            return CustomerDal.CheckIfCustomerExists(ID);
        }

        public bool DeleteOne(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCustomer(Customer customer)
        {
            if (customer.Name.Length == 0)
            {
                throw new BusinessLogicException("Please enter a valid name");
            }
            else if (customer.VAT.Length == 0)
            {
                throw new BusinessLogicException("VAT is Mandatory");
            }
            return true;
        }

        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateTotalCost(List<decimal> rowCostList, decimal discountCost, decimal shippingCost)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateOrder(Customer obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
