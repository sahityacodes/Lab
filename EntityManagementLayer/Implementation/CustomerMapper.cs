using BusinessEntityLayer.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EntityManagementLayer.Utils;
using EntityManagementLayer.Interfaces;
using DALayer.Implementation;
using System.Data.SqlClient;

namespace EntityManagementLayer.Implementation
{
    public class CustomerMapper : ICustomerEntityManager<Customer>
    {
        public List<Customer> GetAll()
        {
            SqlDB_DAL driver = new();
            return ConvertDataTableToCustomer(driver.GetRecords(Constants.QUERY_GETALL));
        }

        public List<Customer> GetAllByKeyWord(string searchKeyWord)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Word", SqlDbType.VarChar) { Value = "%"+searchKeyWord+"%"},
            };
            return ConvertDataTableToCustomer(driver.GetRecords(Constants.QUERY_GETBYNAME, parameters));
        }

        public bool UpdateOne(Customer customer)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Id", SqlDbType.Int) { Value = customer.Id },
              new SqlParameter("@Name", SqlDbType.Char) { Value = customer.Name },
              new SqlParameter("@VAT", SqlDbType.Char) { Value = customer.VAT },
              new SqlParameter("@Address", SqlDbType.VarChar) { Value = customer.Address ?? Constants.DBNull},
              new SqlParameter("@City", SqlDbType.Char) { Value = customer.City?? Constants.DBNull },
              new SqlParameter("@Phone", SqlDbType.Char) { Value = customer.Phone ?? Constants.DBNull},
              new SqlParameter("@AnnualRevenue", SqlDbType.Decimal) { Value = customer.AnnualRevenue }
            };
            Dictionary<string, List<SqlParameter[]>> queries = new();
            List<SqlParameter[]> paramList = new();
            paramList.Add(parameters);
            queries.Add(Constants.QUERY_UPDATE, paramList);
            return driver.WriteToTable(queries);
        }

        public bool InsertOne(Customer customer)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Name", SqlDbType.Char) { Value = customer.Name },
              new SqlParameter("@VAT", SqlDbType.Char) { Value = customer.VAT },
              new SqlParameter("@Address", SqlDbType.VarChar) { Value = customer.Address ?? Constants.DBNull},
              new SqlParameter("@City", SqlDbType.Char) { Value = customer.City?? Constants.DBNull },
              new SqlParameter("@Phone", SqlDbType.Char) { Value = customer.Phone ?? Constants.DBNull},
              new SqlParameter("@AnnualRevenue", SqlDbType.Decimal) { Value = customer.AnnualRevenue }
            };
            Dictionary<string, List<SqlParameter[]>> queries = new();
            List<SqlParameter[]> paramList = new();
            paramList.Add(parameters);
            queries.Add(Constants.QUERY_INSERT, paramList);
            return driver.WriteToTable(queries);
        }

        public bool DeleteAll(int Id)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Id", SqlDbType.Int) { Value = Id }
            };
            Dictionary<string, List<SqlParameter[]>> queries = new();
            List<SqlParameter[]> paramList = new();
            paramList.Add(parameters);
            queries.Add(Constants.QUERY_DELETEONE, paramList);
            return driver.WriteToTable(queries);
        }

        public List<Customer> SortByColumnAscending(string colName)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@orderby", SqlDbType.VarChar) { Value = colName},
            };
            return ConvertDataTableToCustomer(driver.GetRecords(Constants.QUERY_SORTBYCOLUMNASC, parameters));
        }


        public List<Customer> SortByColumnDescending(string colName)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@orderby", SqlDbType.VarChar) { Value = colName},
            };
            return ConvertDataTableToCustomer(driver.GetRecords(Constants.QUERY_SORTBYCOLUMNDESC, parameters));
        }

        public Customer GetOne(int OrderID)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetCustomerOrdersCost()
        {
            SqlDB_DAL driver = new();
            DataTable customerDataTable = driver.GetRecords(Constants.TOTAL_ORDER_COST);
            List<Customer> customerList = new();
            if (customerDataTable.Rows.Count > 0)
            {
                customerList = customerDataTable.AsEnumerable()
                                .Select(dataRow => new Customer
                                {
                                    Id = dataRow.Field<int>("Id"),
                                    OrderCount = dataRow.Field<int>("TotalOrders"),
                                    TotalAmount = dataRow.Field<decimal>("TotalAmount"),
                                }).ToList();
                customerDataTable.Dispose();
            }
            return customerList;
        }

        private List<Customer> ConvertDataTableToCustomer(DataTable customerDataTable)
        {
           return  customerDataTable.AsEnumerable()
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
        }

        public bool CheckIfCustomerExists(int ID)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Id", SqlDbType.Int) { Value = ID},
            };
            return (driver.GetRecords(Constants.QUERY_CHECKIFCUSTOMER_EXISTS, parameters).Rows.Count > 0 )? true :false ;
        }

        public bool DeleteOne(int Id, int rowID)
        {
            throw new System.NotImplementedException();
        }
    }
}
