using BusinessEntityLayer.Model;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using EntityManagementLayer.Interfaces;
using EntityManagementLayer.Implementation;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Implementation.OrderLogic
{
    public class OrderBAL : IOrderBLL<SalesOrders>
    {
        readonly IOrderEntityManager<SalesOrders> OrderDal = new OrderMapper();
        readonly ICustomerEntityManager<Customer> CustomerDal = new CustomerMapper();

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
            return OrderDal.InsertOne(order);
        }

        public bool UpdateOne(SalesOrders order)
        {
            CalculateCosts(order);
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

            return totalCost < 0 ? 0 : totalCost;
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

        public bool ValidateOrder(SalesOrders order)
        {
            if (!CustomerDal.CheckIfCustomerExists(order.CustomerID))
            {
                throw new BusinessLogicException("The entered CustomerID doesnt exist.");
            }
            if (order.DateOrder > order.OrderSummary.DeliveryDate)
            {
                throw new BusinessLogicException("The Delivery Date is sooner than the Date of Order. Please change it");
            }
            return true;
        }
    }
}
