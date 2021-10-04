﻿using BusinessEntityLayer.Model;
using DALayer.Implementation;
using EntityManagementLayer.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EntityManagementLayer.Implementation
{
    public class OrderTailsMapper
    {
        private List<SalesOrdersTail> ConvertToObject(DataTable orderDataTable)
        {
            List<SalesOrdersTail> tailList = new();
            List<FileEntity> filesList = new();
            if (orderDataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in orderDataTable.Rows)
                {
                    if (dataRow["ID"] != DBNull.Value)
                    {
                        filesList.Add(
                            new FileEntity
                            {
                                Id = dataRow.Field<int>("ID"),
                                Name = dataRow.Field<string>("FileName"),
                                Ext = dataRow.Field<string>("FileExt"),
                                file = dataRow.Field<byte[]>("FileBinary").Length > 0 ? dataRow.Field<byte[]>("FileBinary") : new byte[0],
                                OrderId = dataRow.Field<int>("OrderID")
                            });
                    }
                    tailList.Add(new SalesOrdersTail
                    {
                        DiscountAmount = dataRow.Field<decimal>("DiscountAmount"),
                        ShippingCost = dataRow.Field<decimal>("ShippingCost"),
                        TotalOrder = dataRow.Field<decimal>("TotalCost"),
                        DeliveryDate = dataRow.Field<DateTime>("DeliveryDate"),
                        ShippingAddress = dataRow.Field<string>("ShippingAddress"),
                        files = filesList
                    });
                }
            }
            return tailList;
        }

        public SalesOrdersTail GetOne(SqlDB_DAL driver, int OrderID)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OrderID", SqlDbType.VarChar) { Value = OrderID},
            };
            return driver.GetRecords(Constants.QUERY_SELECTORDERTAILS, parameters).Rows.Count > 0 ?
                ConvertToObject(driver.GetRecords(Constants.QUERY_SELECTORDERTAILS, parameters))[0] : new SalesOrdersTail();
        }

        public bool InsertOne(SqlDB_DAL driver,SalesOrdersTail obj)
        {
            OrderMapper mapper = new();
            bool status = false;
            try
            {
                driver.OpenDB();
                driver.OpenTransaction();
                obj.OrderId = mapper.GetCurrentOrderID(driver);
                SqlParameter[] orderSummaryParam =
                {
                  new SqlParameter("@OrderID", SqlDbType.Int) { Value = obj.OrderId},
                  new SqlParameter("@ShippingAddress", SqlDbType.VarChar) { Value = obj.ShippingAddress },
                  new SqlParameter("@ShippingCost", SqlDbType.Decimal) { Value = obj.ShippingCost },
                  new SqlParameter("@DeliveryDate", SqlDbType.DateTime) { Value = obj.DeliveryDate},
                  new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = obj.DiscountAmount },
                  new SqlParameter("@TotalCost", SqlDbType.Decimal) { Value = obj.TotalOrder},
            };
                if (driver.WriteToTable(Constants.QUERY_INSERT_ORDERDETAILS, orderSummaryParam) && InsertFiles(driver, obj))
                {
                    driver.CommitTransaction();
                    status = true;
                }
            }
            catch (Exception)
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

        private bool InsertFiles(SqlDB_DAL driver, SalesOrdersTail orders)
        {
            bool status = true;
            foreach (FileEntity file in orders.files)
            {
                SqlParameter[] rowParam =
                 {
                  new SqlParameter("@OrderID", SqlDbType.Int) { Value = orders.OrderId},
                  new SqlParameter("@FileName", SqlDbType.VarChar) { Value = file.Name},
                  new SqlParameter("@FileExt", SqlDbType.VarChar) { Value = file.Ext },
                  new SqlParameter("@FileBinary", SqlDbType.VarBinary){ Value = file.file}
                };
                status = driver.WriteToTable(Constants.QUERY_INSERT_FILES, rowParam);
            }
            return status;
        }
        public bool DeleteFiles(SqlDB_DAL driver, int OrderID)
        {
            SqlParameter[] rowParam =
                 {
                  new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderID },
                };
            return driver.WriteToTable(Constants.QUERY_DEL_FILES, rowParam);
        }

        public bool UpdateOne(SqlDB_DAL driver, SalesOrdersTail obj)
        {
            bool status = false;
            try
            {
                driver.OpenDB();
                driver.OpenTransaction();
                SqlParameter[] orderSummaryParam =
                {
             new SqlParameter("@OrderID", SqlDbType.Int) { Value = obj.OrderId},
              new SqlParameter("@ShippingAddress", SqlDbType.VarChar) { Value = obj.ShippingAddress },
              new SqlParameter("@ShippingCost", SqlDbType.Decimal) { Value = obj.ShippingCost },
              new SqlParameter("@DeliveryDate", SqlDbType.DateTime) { Value = obj.DeliveryDate},
              new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = obj.DiscountAmount },
              new SqlParameter("@TotalCost", SqlDbType.Decimal) { Value = obj.TotalOrder},
            };
                if (driver.WriteToTable(Constants.QUERY_UPDATE_ORDERS_TAILS, orderSummaryParam) &&
                    DeleteFiles(driver, obj.OrderId)
                    && InsertFiles(driver, obj))
                {
                    driver.CommitTransaction();
                    status = true;
                }
            }
            catch (Exception)
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
    }
}
