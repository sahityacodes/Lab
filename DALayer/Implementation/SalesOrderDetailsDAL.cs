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
    class SalesOrderDetails : IDAL<SalesOrdersTail>
    {
        public List<SalesOrdersTail> GetAll()
        {
            SqlDB_DAL driver = new();
            DataTable detailsTable = driver.GetRecords(Constants.QUERY_GETALL_ORDERS);
            List<SalesOrdersTail> detailsList = detailsTable.AsEnumerable()
                            .Select(dataRow => new SalesOrdersTail
                            {
                                OrderId = dataRow.Field<int>("OrderId"),
                                DeliveryDate = dataRow.Field<DateTime>("DeliveryDate"),
                                ShippingAddress = dataRow.Field<string>("ShippingAddress"),
                                DiscountAmount = dataRow.Field<decimal>("DiscountAmount"),
                                ShippingCost = dataRow.Field<decimal>("ShippingCost"),
                                TotalOrder = dataRow.Field<decimal>("TotalOrder"),
                            }).ToList();
            return detailsList;
        }

        public List<SalesOrdersTail> GetAllByKeyWord(string searchKeyWord)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Word", SqlDbType.VarChar) { Value = "%"+searchKeyWord+"%"},
            };
            DataTable detailsTable = driver.GetRecords(Constants.QUERY_GETALL_ORDERS);
            List<SalesOrdersTail> detailsList = detailsTable.AsEnumerable()
                            .Select(dataRow => new SalesOrdersTail
                            {
                                OrderId = dataRow.Field<int>("OrderId"),
                                DeliveryDate = dataRow.Field<DateTime>("DeliveryDate"),
                                ShippingAddress = dataRow.Field<string>("ShippingAddress"),
                                DiscountAmount = dataRow.Field<decimal>("DiscountAmount"),
                                ShippingCost = dataRow.Field<decimal>("ShippingCost"),
                                TotalOrder = dataRow.Field<decimal>("TotalOrder"),
                            }).ToList();
            return detailsList;
        }

        public bool UpdateOne(SalesOrdersTail orderDetails)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderDetails.OrderId },
              new SqlParameter("@DeliveryDate", SqlDbType.Int) { Value = orderDetails.DeliveryDate },
              new SqlParameter("@ShippingAddress", SqlDbType.DateTime) { Value = orderDetails.ShippingAddress },
              new SqlParameter("@DiscountAmount", SqlDbType.VarChar) { Value = orderDetails.DiscountAmount},
              new SqlParameter("@ShippingCost", SqlDbType.Int) { Value = orderDetails.ShippingCost },
              new SqlParameter("@TotalOrder", SqlDbType.Int) { Value = orderDetails.TotalOrder }
            };
            return driver.WriteToTable(Constants.QUERY_UPDATE_ORDERS, parameters);
        }

        public bool InsertOne(SalesOrdersTail orderDetails)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderDetails.OrderId },
              new SqlParameter("@DeliveryDate", SqlDbType.Int) { Value = orderDetails.DeliveryDate },
              new SqlParameter("@ShippingAddress", SqlDbType.DateTime) { Value = orderDetails.ShippingAddress },
              new SqlParameter("@DiscountAmount", SqlDbType.VarChar) { Value = orderDetails.DiscountAmount},
              new SqlParameter("@ShippingCost", SqlDbType.Int) { Value = orderDetails.ShippingCost },
              new SqlParameter("@TotalOrder", SqlDbType.Int) { Value = orderDetails.TotalOrder }
            };
            return driver.WriteToTable(Constants.QUERY_INSERT_ORDERS, parameters);
        }

        public bool DeleteOne(int OrderId)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId }
            };
            return driver.WriteToTable(Constants.QUERY_DELETEONE_ORDERS, parameters);
        }

        public List<SalesOrdersTail> SortByColumnAscending()
        {
            SqlDB_DAL driver = new();
            DataTable detailsTable = driver.GetRecords(Constants.QUERY_GETALL_ORDERS);
            List<SalesOrdersTail> detailsList = detailsTable.AsEnumerable()
                            .Select(dataRow => new SalesOrdersTail
                            {
                                OrderId = dataRow.Field<int>("OrderId"),
                                DeliveryDate = dataRow.Field<DateTime>("DeliveryDate"),
                                ShippingAddress = dataRow.Field<string>("ShippingAddress"),
                                DiscountAmount = dataRow.Field<decimal>("DiscountAmount"),
                                ShippingCost = dataRow.Field<decimal>("ShippingCost"),
                                TotalOrder = dataRow.Field<decimal>("TotalOrder"),
                            }).ToList();
            return detailsList;
        }


        public List<SalesOrdersTail> SortByColumnDescending()
        {
            SqlDB_DAL driver = new();
            DataTable detailsTable = driver.GetRecords(Constants.QUERY_GETALL_ORDERS);
            List<SalesOrdersTail> detailsList = detailsTable.AsEnumerable()
                            .Select(dataRow => new SalesOrdersTail
                            {
                                OrderId = dataRow.Field<int>("OrderId"),
                                DeliveryDate = dataRow.Field<DateTime>("DeliveryDate"),
                                ShippingAddress = dataRow.Field<string>("ShippingAddress"),
                                DiscountAmount = dataRow.Field<decimal>("DiscountAmount"),
                                ShippingCost = dataRow.Field<decimal>("ShippingCost"),
                                TotalOrder = dataRow.Field<decimal>("TotalOrder"),
                            }).ToList();
            return detailsList;
        }
    }
} */

