using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementation.CustomerLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

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
            try
            {
                return CustomerBal.InsertOne(customer);
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Number == 2627)
                {
                    MessageBox.Show("VAT already present in the system.");
                }
                else throw;
            }
            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return CustomerBal.UpdateOne(customer);
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Number == 2627)
                {
                    MessageBox.Show("VAT already present in the system.");
                }
                else throw;
            }
            return false;
        }

        internal bool DeleteCustomer(int customer)
        {
            try
            {
                return CustomerBal.DeleteAll(customer);
            }
            catch (SqlException sqlExc)
            {
                Debug.WriteLine(sqlExc.Message);
                if (sqlExc.Number == 547)
                {
                    MessageBox.Show("Customer has orders, please delete the orders first to proceed.");
                }
                else
                {
                    MessageBox.Show("Error in the System");
                }
            }
            return false;
        }

        public bool ValidateCustomer(Customer customer)
        {
            return CustomerBal.ValidateCustomer(customer);
        }
    }
}
