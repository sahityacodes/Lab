﻿using System.Collections.Generic;
using BusinessEntityLayer;

namespace DALayer
{
    public interface IDAL
    {
        public List<Customer> GetCustomers();
        public List<Customer> GetCustomersByName(string name);
        public bool UpdateCustomer(Customer customer);
        public bool InsertCustomer(Customer customer);
        public bool DeleteCustomer(Customer customer);
    }
}