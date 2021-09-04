using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using BusinessEntityLayer.Model;
using EntityManagementLayer.Utils;
using System.Data.SqlClient;
using DALayer.Implementation;
using EntityManagementLayer.Interfaces;

namespace EntityManagementLayer.Implementation
{
    public class OrderMapper : IEntityManager<SalesOrders>
    {
        public List<SalesOrders> GetAll()
        {
            SqlDB_DAL driver = new();
            return ConvertToSalesOrdersObject(driver.GetRecords(Constants.QUERY_SELECTALLORDERS));
        }

        public List<SalesOrders> GetAllByKeyWord(string searchKeyWord)
        {
            SqlDB_DAL driver = new();

            SqlParameter[] parameters =
            {
              new SqlParameter("@Word", SqlDbType.VarChar) { Value = "%"+searchKeyWord+"%"},
            };
            return ConvertToSalesOrdersObject(driver.GetRecords(Constants.QUERY_FINDORDER, parameters));
        }
        public bool InsertOne(SalesOrders salesOrder)
        {
            SqlDB_DAL driver = new();
            bool status = false;
            try
            {
                driver.OpenDB();
                driver.OpenTransaction();
                SqlParameter[] salesOrderParams =
                {
                  new SqlParameter("@CustomerID", SqlDbType.Int) { Value = salesOrder.CustomerID },
                  new SqlParameter("@DateOrder", SqlDbType.DateTime) { Value = salesOrder.DateOrder },
                  new SqlParameter("@Payment", SqlDbType.VarChar) { Value = salesOrder.Payment},
                };

                if (driver.WriteToTable(Constants.QUERY_INSERT_ORDERS, salesOrderParams))
                {
                    salesOrder.OrderID = GetCurrentOrderID(driver);
                    if (InsertRows(driver, salesOrder))
                    {
                        driver.CommitTransaction();
                        status = true;
                    }
                }
            }
            catch (SqlException)
            {
                driver.RollbackTransaction();
                throw;
            }
            finally
            {
                driver.CloseDB();
            }
            return status;
        }

        public bool UpdateOne(SalesOrders salesOrder)
        {
            SqlDB_DAL driver = new();
            bool status = false;
            try
            {
                driver.OpenDB();
                driver.OpenTransaction();
                SqlParameter[] salesOrderParams =
                {
                  new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
                  new SqlParameter("@CustomerID", SqlDbType.Int) { Value = salesOrder.CustomerID },
                  new SqlParameter("@DateOrder", SqlDbType.DateTime) { Value = salesOrder.DateOrder },
                  new SqlParameter("@Payment", SqlDbType.VarChar) { Value = salesOrder.Payment},
                  };
                if (driver.WriteToTable(Constants.QUERY_UPDATE_ORDERS, salesOrderParams) &&
                    DeleteAllRows(driver, salesOrder.OrderID) && InsertRows(driver, salesOrder))
                    {
                        driver.CommitTransaction();
                    status = true;
                    }
            }
            catch (SqlException)
            {
                driver.RollbackTransaction();
                throw;
            }
            finally
            {
                driver.CloseDB();
            }
            return status;
        }


        public bool DeleteAll(int OrderId)
        {
            SqlDB_DAL driver = new();
            bool status = false;
            try
            {
                driver.OpenDB();
                driver.OpenTransaction();
                SqlParameter[] parameters =
                {
                new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId }
                };
                if(driver.WriteToTable(Constants.QUERY_DELETE_ORDERS, parameters))
                {
                     driver.CommitTransaction();
                    status = true;
                }
            }  
            catch (SqlException)
            {
                driver.RollbackTransaction();
                throw;
            }
            finally
            {
                driver.CloseDB();
            }
            return status;
        }

        public List<SalesOrders> SortByColumnAscending(string colName)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@orderby", SqlDbType.VarChar) { Value = colName},
            };
            return ConvertToSalesOrdersObject(driver.GetRecords(Constants.QUERY_SORTBYCOLUMNASC_ORDERS, parameters));
        }


        public List<SalesOrders> SortByColumnDescending(string colName)
        {
            SqlDB_DAL driver = new();
            SqlParameter[] parameters =
            {
              new SqlParameter("@orderby", SqlDbType.VarChar) { Value = colName},
            };
            return ConvertToSalesOrdersObject(driver.GetRecords(Constants.QUERY_SORTBYCOLUMNDESC_ORDERS, parameters));
        }

        internal int GetCurrentOrderID(SqlDB_DAL driver)
        {
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
            if (orderDataTable.Rows.Count > 0)
            {
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
                            }
                        });
                    }
                }
            }
            return orderList;
        }
      
        private List<SalesOrders> ConvertToSalesOrdersObject(DataTable orderDataTable)
        {
            List<SalesOrders> orderList = new();
            if (orderDataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in orderDataTable.Rows)
                {
                    orderList.Add(new SalesOrders
                    {
                        OrderID = dataRow.Field<int>("OrderID"),
                        CustomerID = dataRow.Field<int>("CustomerID"),
                        CustomerName = dataRow.Field<string>("Name"),
                        DateOrder = dataRow.Field<DateTime>("DateOrder"),
                        Payment = dataRow.Field<string>("Payment"),
                        OrderSummary = new SalesOrdersTail
                        {
                            DiscountAmount = dataRow.IsNull("DiscountAmount")? 0 :dataRow.Field<decimal>("DiscountAmount"),
                            ShippingCost = dataRow.IsNull("ShippingCost") ? 0 : dataRow.Field<decimal>("ShippingCost"),
                            TotalOrder = dataRow.IsNull("TotalCost") ? 0 : dataRow.Field<decimal>("TotalCost"),
                            DeliveryDate = dataRow.IsNull("DeliveryDate") ? new DateTime() :dataRow.Field<DateTime>("DeliveryDate"),
                            ShippingAddress = dataRow.Field<string>("ShippingAddress")
                        }
                    });
                }
            }
            return orderList;
        }

        private bool InsertRows(SqlDB_DAL driver,SalesOrders salesOrder)
        {
            bool status = true;
            foreach (SalesOrdersRows rows in salesOrder.OrderRows)
            {
                SqlParameter[] rowParam =
                 {
                  new SqlParameter("@OrderID", SqlDbType.Int) { Value = salesOrder.OrderID},
                  new SqlParameter("@ProductCode", SqlDbType.VarChar) { Value = rows.ProductCode },
                  new SqlParameter("@Description", SqlDbType.VarChar) { Value = rows.Description},
                  new SqlParameter("@Qty", SqlDbType.Decimal) { Value = rows.Qty},
                  new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = rows.UnitPrice},
                  new SqlParameter("@TotalRowPrice", SqlDbType.Decimal) { Value = rows.TotalRowPrice},
                };
                status = status && driver.WriteToTable(Constants.QUERY_INSERT_ORDERROWS, rowParam);
            }
            return status;
        }

        public bool DeleteAllRows(SqlDB_DAL driver, int OrderId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId }
              };
            return driver.WriteToTable(Constants.QUERY_DELETEONE_ROW, parameters);
        }


        public bool DeleteOne(int Id)
        {
            throw new NotImplementedException();
        }

        public List<SalesOrders> GetCustomerOrdersCost()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfCustomerExists(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
