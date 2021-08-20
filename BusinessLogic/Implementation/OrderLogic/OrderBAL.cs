using BusinessEntityLayer.Model;
using System.Collections.Generic;
using DALayer.Interfaces;
using BusinessLogic.Interfaces;
using DALayer.DTO;

namespace BusinessLogic.Implementation.OrderLogic
{
    public class OrderBAL : IOrderBLL<SalesOrders>
    {
        readonly IDAL<SalesOrders> OrderDal = new OrderDAL();
        OrderValidationRules orderValid = new();
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
            orderValid.ValidateCustomerForm(order);
            CalculateCosts(order);
            return OrderDal.InsertOne(order);
        }

        public bool UpdateOne(SalesOrders order)
        {
            CalculateCosts(order);
            orderValid.ValidateCustomerForm(order);
            return OrderDal.UpdateOne(order);
        }

        public bool DeleteAll(int Id)
        {
            return OrderDal.DeleteAll(Id);
        }

        public List<SalesOrders> SortByColumnAscending(string ColName)
        {
            return OrderDal.SortByColumnAscending(ColName);
        }

        public List<SalesOrders> SortByColumnDescending(string ColName)
        {
            return OrderDal.SortByColumnDescending(ColName);
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

        public bool DeleteOne(int Id, int rowID)
        {
            return OrderDal.DeleteOne(Id, rowID);
        }
    }
}
