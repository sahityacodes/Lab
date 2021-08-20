using BusinessEntityLayer.Model;
using BusinessLogic.Implementation.OrderLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomerInfoApplication.Controllers
{
    internal class OrderController
    {
        readonly IOrderBLL<SalesOrders> OrderBAL = new OrderBAL();

        public List<SalesOrders> GetAll()
        {
            return OrderBAL.GetAll();
        }

        public List<SalesOrders> GetOneByName(string keyword)
        {
            return OrderBAL.GetOneByName(keyword);
        }

        public List<SalesOrders> SortByColumnAscending(string columnName)
        {
            return OrderBAL.SortByColumnAscending(columnName);
        }

        public List<SalesOrders> SortByColumnDescending(string columnName)
        {
            return OrderBAL.SortByColumnDescending(columnName);
        }

        public bool InsertCustomer(SalesOrders orders)
        {
            return OrderBAL.InsertOne(orders);
        }

        public bool UpdateCustomer(SalesOrders orders)
        {
            return OrderBAL.UpdateOne(orders);
        }

        public bool DeleteAll(int ID)
        {
            return OrderBAL.DeleteAll(ID);
        }

        public bool DeleteOne(int ID,int rowID)
        {
            return OrderBAL.DeleteOne(ID, rowID);
        }

        internal SalesOrders GetOne(int orderID)
        {
            return OrderBAL.GetOne(orderID);
        }

        internal bool InsertOne(SalesOrders order)
        {
            return OrderBAL.InsertOne(order);
        }

        internal bool UpdateOne(SalesOrders order)
        {
            return OrderBAL.UpdateOne(order);
        }

        internal decimal CalculateTotalUnitCost(decimal v1, decimal v2)
        {
            return OrderBAL.CalculateTotalUnitCost(v1,v2);
        }

        internal decimal CalculateTotalCost(decimal costs, decimal v1, decimal v2)
        {
            return OrderBAL.CalculateTotalCost(costs, v1, v2);
        }

    }
}
