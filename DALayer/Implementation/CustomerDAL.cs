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
        public List<Customer> GetAll()
        {
            SqlDB_DAL driver = new();
            DataTable customerDataTable = driver.GetRecords(Constants.QUERY_GETALL);
            List<Customer> customerList = customerDataTable.AsEnumerable()
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

        public List<Customer> GetAllByKeyWord(string searchKeyWord)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Word", SqlDbType.VarChar) { Value = "%"+searchKeyWord+"%"},
            };
            DataTable customerDataTable = driver.GetRecords(Constants.QUERY_GETBYNAME, parameters);
            List<Customer> customerList = customerDataTable.AsEnumerable().Select(dataRow => new Customer
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
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Id", SqlDbType.Int) { Value = customer.Id },
              new SqlParameter("@Name", SqlDbType.VarChar) { Value = customer.Name },
              new SqlParameter("@VAT", SqlDbType.VarChar) { Value = customer.VAT },
              new SqlParameter("@Address", SqlDbType.VarChar) { Value = customer.Address ?? Constants.DBNull},
              new SqlParameter("@City", SqlDbType.VarChar) { Value = customer.City?? Constants.DBNull },
              new SqlParameter("@Phone", SqlDbType.VarChar) { Value = customer.Phone ?? Constants.DBNull},
              new SqlParameter("@AnnualRevenue", SqlDbType.Decimal) { Value = customer.AnnualRevenue }
            };
            return driver.WriteToTable(Constants.QUERY_UPDATE, parameters);
        }

        public bool InsertOne(Customer customer)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Name", SqlDbType.VarChar) { Value = customer.Name },
              new SqlParameter("@VAT", SqlDbType.VarChar) { Value = customer.VAT },
              new SqlParameter("@Address", SqlDbType.VarChar) { Value = customer.Address ?? Constants.DBNull},
              new SqlParameter("@City", SqlDbType.VarChar) { Value = customer.City?? Constants.DBNull },
              new SqlParameter("@Phone", SqlDbType.VarChar) { Value = customer.Phone ?? Constants.DBNull},
              new SqlParameter("@AnnualRevenue", SqlDbType.Decimal) { Value = customer.AnnualRevenue }
            };
            return driver.WriteToTable(Constants.QUERY_INSERT, parameters);
        }

        public bool DeleteOne(int Id)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Id", SqlDbType.Int) { Value = Id }
            };
            return driver.WriteToTable(Constants.QUERY_DELETEONE, parameters);
        }

        public List<Customer> SortByColumnAscending()
        {
            SqlDB_DAL driver = new();
            DataTable customerDataTable = driver.GetRecords(Constants.QUERY_SORTBYCOLUMNASC);
            List<Customer> customerList = customerDataTable.AsEnumerable()
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


        public List<Customer> SortByColumnDescending()
        {
                SqlDB_DAL driver = new();
                DataTable customerDataTable = driver.GetRecords(Constants.QUERY_SORTBYCOLUMNDESC);
                List<Customer> customerList = customerDataTable.AsEnumerable()
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
        }
}
