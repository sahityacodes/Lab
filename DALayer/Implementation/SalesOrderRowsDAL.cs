/*using BusinessEntityLayer.Model;
using DALayer.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DALayer.Utils;
using System;

namespace DALayer.Implementation
{
    class SalesOrderRowsDAL : IDAL<SalesOrdersRows>
    {
        public List<SalesOrdersRows> GetAll()
        {
            SqlDB_DAL driver = new();
            DataTable orderRowTable = driver.GetRecords(Constants.QUERY_GETALL_ORDERS);
            List<SalesOrdersRows> rowList = orderRowTable.AsEnumerable()
                            .Select(dataRow => new SalesOrdersRows
                            {
                                OrderID = dataRow.Field<int>("OrderId"),
                                RowID = dataRow.Field<int>("CustomerId"),
                                ProductCode = dataRow.Field<string>("ProductCode"),
                                Description = dataRow.Field<string>("Description"),
                                Qty = dataRow.Field<decimal>("Qty"),
                                UnitPrice = dataRow.Field<decimal>("UnitPrice"),
                                TotalRowPrice = dataRow.Field<decimal>("UnitPrice"),
                            }).ToList();
            return rowList;
        }

        public List<SalesOrdersRows> GetAllByKeyWord(string searchKeyWord)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Word", SqlDbType.VarChar) { Value = "%"+searchKeyWord+"%"},
            };
            DataTable orderRowTable = driver.GetRecords(Constants.QUERY_GETBYNAME_ORDERS, parameters);
            List<SalesOrdersRows> rowList = orderRowTable.AsEnumerable()
                              .Select(dataRow => new SalesOrdersRows
                              {
                                  OrderID = dataRow.Field<int>("OrderId"),
                                  RowID = dataRow.Field<int>("RowID"),
                                  ProductCode = dataRow.Field<string>("ProductCode"),
                                  Description = dataRow.Field<string>("Description"),
                                  Qty = dataRow.Field<decimal>("Qty"),
                                  UnitPrice = dataRow.Field<decimal>("UnitPrice"),
                                  TotalRowPrice = dataRow.Field<decimal>("UnitPrice"),
                              }).ToList();
            return rowList;
        }

        public bool UpdateOne(SalesOrdersRows row)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = row.OrderID },
              new SqlParameter("@RowID", SqlDbType.Int) { Value = row.RowID },
              new SqlParameter("@ProductCode", SqlDbType.VarChar) { Value = row.ProductCode },
              new SqlParameter("@Description", SqlDbType.VarChar) { Value = row.Description},
              new SqlParameter("@Qty", SqlDbType.Decimal) { Value = row.Qty },
              new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = row.UnitPrice},
              new SqlParameter("@TotalRowPrice", SqlDbType.Decimal) { Value = row.TotalRowPrice},
            };
            return driver.WriteToTable(Constants.QUERY_UPDATE_ORDERS, parameters);
        }

        public bool InsertOne(SalesOrdersRows row)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
             new SqlParameter("@OrderID", SqlDbType.Int) { Value = row.OrderID },
              new SqlParameter("@RowID", SqlDbType.Int) { Value = row.RowID },
              new SqlParameter("@ProductCode", SqlDbType.VarChar) { Value = row.ProductCode },
              new SqlParameter("@Description", SqlDbType.VarChar) { Value = row.Description},
              new SqlParameter("@Qty", SqlDbType.Decimal) { Value = row.Qty },
              new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = row.UnitPrice},
              new SqlParameter("@TotalRowPrice", SqlDbType.Decimal) { Value = row.TotalRowPrice},
            };
            return driver.WriteToTable(Constants.QUERY_INSERT_ORDERS, parameters);
        }

        public bool DeleteOne(int OrderId)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId },
            };
            return driver.WriteToTable(Constants.QUERY_DELETEONE_ORDERS, parameters);
        }

        public bool DeleteRow(int OrderId, int RowId)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId },
              new SqlParameter("@RowId", SqlDbType.Int) { Value = RowId },
            };
            return driver.WriteToTable(Constants.QUERY_DELETEONE_ORDERS, parameters);
        }

        public List<SalesOrdersRows> SortByColumnAscending()
        {
            SqlDB_DAL driver = new();
            DataTable orderRowTable = driver.GetRecords(Constants.QUERY_SORTBYCOLUMNASC_ORDERS);
            List<SalesOrdersRows> rowList = orderRowTable.AsEnumerable()
                .Select(dataRow => new SalesOrdersRows
                {
                    OrderID = dataRow.Field<int>("OrderId"),
                    RowID = dataRow.Field<int>("CustomerId"),
                    ProductCode = dataRow.Field<string>("ProductCode"),
                    Description = dataRow.Field<string>("Description"),
                    Qty = dataRow.Field<decimal>("Qty"),
                    UnitPrice = dataRow.Field<decimal>("UnitPrice"),
                    TotalRowPrice = dataRow.Field<decimal>("UnitPrice"),
                }).ToList();
            return rowList;
        }


        public List<SalesOrdersRows> SortByColumnDescending()
        {
            SqlDB_DAL driver = new();
            DataTable orderRowTable = driver.GetRecords(Constants.QUERY_SORTBYCOLUMNASC_ORDERS);
            List<SalesOrdersRows> rowList = orderRowTable.AsEnumerable()
                .Select(dataRow => new SalesOrdersRows
                {
                    OrderID = dataRow.Field<int>("OrderId"),
                    RowID = dataRow.Field<int>("CustomerId"),
                    ProductCode = dataRow.Field<string>("ProductCode"),
                    Description = dataRow.Field<string>("Description"),
                    Qty = dataRow.Field<decimal>("Qty"),
                    UnitPrice = dataRow.Field<decimal>("UnitPrice"),
                    TotalRowPrice = dataRow.Field<decimal>("UnitPrice"),
                }).ToList();
            return rowList;
        }
    }
}

*/