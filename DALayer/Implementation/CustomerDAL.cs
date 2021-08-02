using BusinessEntityLayer.Model;
using DALayer.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DALayer.Utils;

namespace DALayer.Implementation
{
    public class CustomerDAL : IDAL<Customer>
    {
        SqlConnection objSqlConnection = DriverConfirguration.OpenConnection();
        
        public List<Customer> GetAll()
        {
            List<Customer> customerList = new();
            DataTable customerDataTable = new();
            SqlCommand com = new SqlCommand(Constants.QUERY_GETALL, objSqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(com);
            sqlDataAdapter.Fill(customerDataTable);
            customerList = customerDataTable.AsEnumerable()
                            .Select(dataRow => new Customer
                            {
                                Id = dataRow.Field<int>("Id"),
                                Name = dataRow.Field<string>("Name"),
                                VAT = dataRow.Field<string>("VAT"),
                                Phone = dataRow.Field<string>("Phone"),
                                Address = dataRow.Field<string>("Address"),
                                City = dataRow.Field<string>("City"),
                                AnnualRevenue = dataRow.Field<decimal>("AnnualRevenue")
                            }).ToList();
            return customerList;
        }

        public List<Customer> GetOneByName(string name)
        {
            List<Customer> customerList = new();
            DataTable CustomerDataTable = new();
            SqlCommand com = new(Constants.QUERY_GETBYNAME, objSqlConnection);
            com.Parameters.AddWithValue("@Name","%"+name+"%");
            SqlDataAdapter adapter = new(com);
            adapter.Fill(CustomerDataTable);
            customerList = CustomerDataTable.AsEnumerable().Select(dataRow => new Customer
            {
                Id = dataRow.Field<int>("Id"),
                Name = dataRow.Field<string>("Name"),
                VAT = dataRow.Field<string>("VAT"),
                Phone = dataRow.Field<string>("Phone"),
                Address = dataRow.Field<string>("Address"),
                City = dataRow.Field<string>("City"),
                AnnualRevenue = dataRow.Field<decimal>("AnnualRevenue")
            }).ToList();
            return customerList;
        }

        public bool UpdateOne(Customer customer)
        {
            int rows;
            SqlCommand com = new(Constants.QUERY_UPDATE, objSqlConnection);
            com.Parameters.AddWithValue("@Id", customer.Id);
            com.Parameters.AddWithValue("@Name", customer.Name);
            com.Parameters.AddWithValue("@VAT", customer.VAT);
            com.Parameters.AddWithValue("@Phone", customer.Phone ?? Constants.DBNull);
            com.Parameters.AddWithValue("@Address", customer.Address ?? Constants.DBNull);
            com.Parameters.AddWithValue("@City", customer.City ?? Constants.DBNull);
            com.Parameters.AddWithValue("@AnnualRevenue", customer.AnnualRevenue);
            rows = com.ExecuteNonQuery();
            return (rows > 0);
        }

        public bool InsertOne(Customer customer)
        {
            int rows;
            SqlCommand com = new(Constants.QUERY_INSERT, objSqlConnection);
            com.Parameters.AddWithValue("@Id", customer.Id);
            com.Parameters.AddWithValue("@Name", customer.Name);
            com.Parameters.AddWithValue("@VAT", customer.VAT);
            com.Parameters.AddWithValue("@Phone", customer.Phone ?? Constants.DBNull);
            com.Parameters.AddWithValue("@Address", customer.Address ?? Constants.DBNull);
            com.Parameters.AddWithValue("@City", customer.City ?? Constants.DBNull);
            com.Parameters.AddWithValue("@AnnualRevenue", customer.AnnualRevenue);
            rows = com.ExecuteNonQuery();
            return (rows > 0);
        }

        public bool DeleteOne(Customer customer)
        {
            int rows;
            SqlCommand com = new(Constants.QUERY_DELETEONE, objSqlConnection);
            com.Parameters.AddWithValue("@Id", customer.Id);
            rows = com.ExecuteNonQuery();
            return (rows > 0);
        }
    }
}
