using BusinessEntityLayer.Model;
using BusinessLogic.Implementation.OrderLogic;
using BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace CustomerInfoApplication.Controllers
{
    internal class OrderController
    {
        readonly IBLL<SalesOrders> OrderBAL = new OrderBAL();

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
            return OrderBAL.SortByColumnAscending(columnName);
        }

        public bool InsertCustomer(SalesOrders orders)
        {
            return OrderBAL.InsertOne(orders);
        }

        public bool UpdateCustomer(SalesOrders orders)
        {
            return OrderBAL.UpdateOne(orders);
        }

        public bool DeleteOne(int ID)
        {
            return OrderBAL.DeleteOne(ID);
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
    }
}
