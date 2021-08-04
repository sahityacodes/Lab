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
            return CustomerDal.GetAllByKeyWord(name);
        }

        public bool InsertOne(Customer customer)
        {
            if (customer.Name.Length == 0)
            {
                throw new UserDefinedException("Please enter a valid name");
            }
            else if (customer.VAT.Length == 0)
            {
                throw new UserDefinedException("VAT is Mandatory");
            }
            else { 
                return CustomerDal.InsertOne(customer);
            }
        }

        public bool UpdateOne(Customer customer)
        {
            if (customer.Name.Length == 0)
            {
                throw new UserDefinedException("Please enter a valid name");
            }else if(customer.VAT.Length == 0)
            {
                throw new UserDefinedException("VAT is Mandatory");
            }
            else
            {
                return CustomerDal.UpdateOne(customer);
            }
        }

        public bool DeleteOne(int Id)
        {
            return CustomerDal.DeleteOne(Id);
        }

        public List<Customer> SortByColumnAscending()
        {
            return CustomerDal.SortByColumnAscending();
        }

        public List<Customer> SortByColumnDescending()
        {
            return CustomerDal.SortByColumnDescending();
        }
    }
}
