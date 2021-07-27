using System.Collections.Generic;
using BusinessEntityLayer.Model;

namespace DALayer.Interfaces
{
    public interface IDAL
    {
        List<Customer> GetAll();
        List<Customer> GetOneByName(string name);
        bool UpdateOne(Customer customer);
        bool InsertOne(Customer customer);
        bool DeleteOne(Customer customer);
    }
}