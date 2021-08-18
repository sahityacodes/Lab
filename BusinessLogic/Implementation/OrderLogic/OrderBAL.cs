using BusinessEntityLayer.Model;
using System.Collections.Generic;
using DALayer.Interfaces;
using DALayer.Implementation;
using BusinessLogic.Interfaces;
using BusinessLogic.Exceptions;
using System;

namespace BusinessLogic.Implementation.OrderLogic
{
    public class OrderBAL : IOrderBLL<SalesOrders>
    {
        readonly IDAL<SalesOrders> OrderDal = new OrderDAL();
        public List<SalesOrders> GetAll()
        {
            return OrderDal.GetAll();
        }

        public List<SalesOrders> GetOneByName(string name)
        {
            return OrderDal.GetAllByKeyWord(name);
        }

        public bool InsertOne(SalesOrders order)
        {
            CalculateCosts(order);
            ValidateCustomerForm(order);
            return OrderDal.InsertOne(order);
        }

        public bool UpdateOne(SalesOrders order)
        {
            CalculateCosts(order);
            ValidateCustomerForm(order);
            return OrderDal.UpdateOne(order);
        }

        public bool DeleteOne(int Id)
        {
            return OrderDal.DeleteOne(Id);
        }

        public List<SalesOrders> SortByColumnAscending(string ColName)
        {
            return OrderDal.SortByColumnAscending(ColName);
        }

        public List<SalesOrders> SortByColumnDescending(string ColName)
        {
            return OrderDal.SortByColumnDescending(ColName);
        }

        private void ValidateCustomerForm(SalesOrders order)
        {
            if (order.DateOrder > order.OrderSummary.DeliveryDate )
            {
                throw new UserDefinedException("The Delivery Date is sooner than the Date of Order. Please change it");
            }
        }

        public decimal CalculateTotalCost(decimal totalRowscost, decimal discountCost, decimal shippingCost)
        {
            decimal totalCost = totalRowscost - discountCost + shippingCost;
         
            return totalCost < 0? 0: totalCost;
        }

        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice)
        {
            return Qty * unitPrice;
        }

        public SalesOrders GetOne(int OrderID)
        {
            return OrderDal.GetOne(OrderID);
        }

        private SalesOrders CalculateCosts(SalesOrders order)
        {
            decimal TotalRowCost = 0;
            foreach (SalesOrdersRows row in order.OrderRows)
            {
                row.TotalRowPrice = CalculateTotalUnitCost(row.Qty, row.UnitPrice);
                TotalRowCost += +row.TotalRowPrice;
            }
            order.OrderSummary.TotalOrder = CalculateTotalCost(TotalRowCost, order.OrderSummary.DiscountAmount, order.OrderSummary.ShippingCost);
            return order;
        }
    }
}
