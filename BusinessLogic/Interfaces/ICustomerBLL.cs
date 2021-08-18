using BusinessEntityLayer.Model;
using System.Collections.Generic;


namespace BusinessLogic.Interfaces
{
    public interface ICustomerBLL<T> : IBLL<T>
    {
        public List<Customer> GetCustomerOrdersCost();


    }
}
