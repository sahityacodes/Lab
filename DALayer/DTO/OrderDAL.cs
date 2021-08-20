using BusinessEntityLayer.Model;
using DALayer.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DALayer.Utils;
using System;
using DALayer.Implementation;

namespace DALayer.DTO
{
    public class OrderDAL : IOrderDAL<SalesOrders>
    {
        public List<SalesOrders> GetAll()
        {
            SqlDB_DAL driver = new();
            return ConvertToObject(driver.GetRecords(Constants.QUERY_SELECTALLORDERS));
        }

        public List<SalesOrders> GetAllByKeyWord(string searchKeyWord)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@Word", SqlDbType.VarChar) { Value = "%"+searchKeyWord+"%"},
            };
            return ConvertToObject(driver.GetRecords(Constants.QUERY_FINDORDER, parameters));
        }

        public bool UpdateOne(SalesOrders salesOrder)
        {
            SqlDB_DAL driver = new();
            List<SqlParameter[]> salesOrders = new List<SqlParameter[]>();
            List<SqlParameter[]> rowParams = new List<SqlParameter[]>();
            List<SqlParameter[]> salesDetails = new List<SqlParameter[]>();
            SqlParameter[] salesOrderParams =
            {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
              new SqlParameter("@CustomerID", SqlDbType.Int) { Value = salesOrder.CustomerID },
              new SqlParameter("@DateOrder", SqlDbType.DateTime) { Value = salesOrder.DateOrder },
              new SqlParameter("@Payment", SqlDbType.VarChar) { Value = salesOrder.Payment},
            };
            salesOrders.Add(salesOrderParams);
            foreach (SalesOrdersRows rows in salesOrder.OrderRows)
            {
                SqlParameter[] rowParam =
                 {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
              new SqlParameter("@RowID", SqlDbType.Int) { Value = rows.RowID},
              new SqlParameter("@ProductCode", SqlDbType.VarChar) { Value = rows.ProductCode },
              new SqlParameter("@Description", SqlDbType.VarChar) { Value = rows.Description},
              new SqlParameter("@Qty", SqlDbType.Decimal) { Value = rows.Qty},
              new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = rows.UnitPrice},
              new SqlParameter("@TotalRowPrice", SqlDbType.Decimal) { Value = rows.TotalRowPrice},
                };
                rowParams.Add(rowParam);
            }
            SqlParameter[] orderSummaryParam =
            {
             new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
              new SqlParameter("@ShippingAddress", SqlDbType.VarChar) { Value = salesOrder.OrderSummary.ShippingAddress },
              new SqlParameter("@ShippingCost", SqlDbType.Decimal) { Value = salesOrder.OrderSummary.ShippingCost },
              new SqlParameter("@DeliveryDate", SqlDbType.DateTime) { Value = salesOrder.OrderSummary.DeliveryDate},
              new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = salesOrder.OrderSummary.DiscountAmount },
              new SqlParameter("@TotalCost", SqlDbType.Decimal) { Value = salesOrder.OrderSummary.TotalOrder},
            };
            salesDetails.Add(orderSummaryParam);
            Dictionary<string, List<SqlParameter[]>> param = new();
            param.Add(Constants.QUERY_UPDATE_ORDERS, salesOrders);
            param.Add(Constants.QUERY_UPDATE_ORDERS_ROWS, rowParams);
            param.Add(Constants.QUERY_UPDATE_ORDERS_TAILS, salesDetails);
            return driver.WriteToTable(param);
        }

        public bool InsertOne(SalesOrders salesOrder)
        {
            SqlDB_DAL driver = new();
            List<SqlParameter[]> salesOrders = new List<SqlParameter[]>();
            SqlParameter[] salesOrderParams =
            {
              new SqlParameter("@CustomerID", SqlDbType.Int) { Value = salesOrder.CustomerID },
              new SqlParameter("@DateOrder", SqlDbType.DateTime) { Value = salesOrder.DateOrder },
              new SqlParameter("@Payment", SqlDbType.VarChar) { Value = salesOrder.Payment},
            };
            salesOrders.Add(salesOrderParams);
            Dictionary<string, List<SqlParameter[]>> param = new();
            param.Add(Constants.QUERY_INSERT_ORDERS, salesOrders);
            if (driver.WriteToTable(param))
            {
                return InsertSalesOrdersRowTails(salesOrder);
            }
            return false;
        }

        private bool InsertSalesOrdersRowTails(SalesOrders salesOrder)
        {
            int rowID = 1;
            SqlDB_DAL driver = new();
            List<SqlParameter[]> rowParams = new List<SqlParameter[]>();
            List<SqlParameter[]> salesDetails = new List<SqlParameter[]>();
            salesOrder.OrderID = GetCurrentOrderID();
            foreach (SalesOrdersRows rows in salesOrder.OrderRows)
            {
                SqlParameter[] rowParam =
                 {
              new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
              new SqlParameter("@RowID", SqlDbType.Int) { Value = rowID },
              new SqlParameter("@ProductCode", SqlDbType.VarChar) { Value = rows.ProductCode },
              new SqlParameter("@Description", SqlDbType.VarChar) { Value = rows.Description},
              new SqlParameter("@Qty", SqlDbType.Decimal) { Value = rows.Qty},
              new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = rows.UnitPrice},
              new SqlParameter("@TotalRowPrice", SqlDbType.Decimal) { Value = rows.TotalRowPrice},
            };
                rowID++;
                rowParams.Add(rowParam);
            }
            SqlParameter[] orderSummaryParam =
            {
             new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
              new SqlParameter("@ShippingAddress", SqlDbType.VarChar) { Value = salesOrder.OrderSummary.ShippingAddress },
              new SqlParameter("@ShippingCost", SqlDbType.Decimal) { Value = salesOrder.OrderSummary.ShippingCost },
              new SqlParameter("@DeliveryDate", SqlDbType.DateTime) { Value = salesOrder.OrderSummary.DeliveryDate},
              new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = salesOrder.OrderSummary.DiscountAmount },
              new SqlParameter("@TotalCost", SqlDbType.Decimal) { Value = salesOrder.OrderSummary.TotalOrder},
            };
            salesDetails.Add(orderSummaryParam);
            Dictionary<string, List<SqlParameter[]>> param = new();
            param.Add(Constants.QUERY_INSERT_ORDERROWS, rowParams);
            param.Add(Constants.QUERY_INSERT_ORDERDETAILS, salesDetails);
            return driver.WriteToTable(param);
        }

        public bool DeleteAll(int OrderId)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId }
              };
            List<SqlParameter[]> rowParams = new List<SqlParameter[]>();
            rowParams.Add(parameters);
            Dictionary<string, List<SqlParameter[]>> param = new();
            param.Add(Constants.QUERY_DELETEONE_ORDERS, rowParams);
            return driver.WriteToTable(param);
        }

        public List<SalesOrders> SortByColumnAscending(string colName)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@orderby", SqlDbType.VarChar) { Value = colName},
            };
            return ConvertToObject(driver.GetRecords(Constants.QUERY_SORTBYCOLUMNASC_ORDERS, parameters));
        }


        public List<SalesOrders> SortByColumnDescending(string colName)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@orderby", SqlDbType.VarChar) { Value = colName},
            };
            return ConvertToObject(driver.GetRecords(Constants.QUERY_SORTBYCOLUMNDESC_ORDERS, parameters));
        }

        private int GetCurrentOrderID()
        {
            SqlDB_DAL driver = new();
            DataTable orderDataTable = driver.GetRecords(Constants.IDEN_QUERY_ORDERS);
            return Convert.ToInt32(orderDataTable.Rows[0].ItemArray[0]);
        }

        public SalesOrders GetOne(int OrderID)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.VarChar) { Value = OrderID},
            };
            SqlDB_DAL driver = new();
            return ConvertToObject(driver.GetRecords(Constants.QUERY_SELECTALLORDERS_ONE, parameters))[0];

        }

        private List<SalesOrders> ConvertToObject(DataTable orderDataTable)
        {
            List<SalesOrders> orderList = new();
            if(orderDataTable.Rows.Count > 0) { 
                foreach (DataRow dataRow in orderDataTable.Rows)
                {
                    SalesOrders order = orderList.FirstOrDefault(o => o.OrderID == dataRow.Field<int>("OrderID"));
                    if (order != null)
                    {
                        order.OrderRows.Add(new SalesOrdersRows
                        {
                            RowID = dataRow.Field<int>("RowID"),
                            ProductCode = dataRow.Field<string>("ProductCode"),
                            Description = dataRow.Field<string>("Description"),
                            Qty = dataRow.Field<decimal>("Qty"),
                            UnitPrice = dataRow.Field<decimal>("UnitPrice"),
                            TotalRowPrice = dataRow.Field<decimal>("TotalRowPrice"),
                        });
                    }
                    else
                    {
                        orderList.Add(new SalesOrders
                        {
                            OrderID = dataRow.Field<int>("OrderID"),
                            CustomerID = dataRow.Field<int>("CustomerID"),
                            DateOrder = dataRow.Field<DateTime>("DateOrder"),
                            Payment = dataRow.Field<string>("Payment"),
                            OrderRows = new List<SalesOrdersRows>()
                            {
                                new SalesOrdersRows
                        {
                            RowID = dataRow.Field<int>("RowID"),
                            ProductCode = dataRow.Field<string>("ProductCode"),
                            Description = dataRow.Field<string>("Description"),
                            Qty = dataRow.Field<decimal>("Qty"),
                            UnitPrice = dataRow.Field<decimal>("UnitPrice"),
                            TotalRowPrice = dataRow.Field<decimal>("TotalRowPrice"),
                        }
                            },
                            OrderSummary = new SalesOrdersTail
                            {
                                DiscountAmount = dataRow.Field<decimal>("DiscountAmount"),
                                ShippingCost = dataRow.Field<decimal>("ShippingCost"),
                                TotalOrder = dataRow.Field<decimal>("TotalCost"),
                                DeliveryDate = dataRow.Field<DateTime>("DeliveryDate"),
                                ShippingAddress = dataRow.Field<string>("ShippingAddress")
                            }
                        });
                    }
                }
            }
            return orderList;
        }

        public bool DeleteOne(int OrderId, int RowId)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId },
                new SqlParameter("@RowId", SqlDbType.Int) { Value = RowId }
              };
            List<SqlParameter[]> rowParams = new();
            rowParams.Add(parameters);
            Dictionary<string, List<SqlParameter[]>> param = new();
            param.Add(Constants.QUERY_DELETEONE_ROW, rowParams);
            return driver.WriteToTable(param);
        }

    }
}
