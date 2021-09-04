using BusinessEntityLayer.Model;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using EntityManagementLayer.Interfaces;
using EntityManagementLayer.Implementation;
using BusinessLogic.Exceptions;
using System.Linq;

namespace BusinessLogic.Implementation.OrderLogic
{
    public class OrderBAL : IBLL<SalesOrders>
    {
        public List<SalesOrders> GetAll()
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.GetAll();
        }

        public List<SalesOrders> GetOneByName(string name)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.GetAllByKeyWord(name);
        }

        public bool InsertOne(SalesOrders order)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            CalculateCosts(order);
            return OrderDal.InsertOne(order);
        }

        public bool UpdateOne(SalesOrders order)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            CalculateCosts(order);
            return OrderDal.UpdateOne(order);
        }

        public bool DeleteAll(int Id)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.DeleteAll(Id);
        }

        public List<SalesOrders> SortByColumnAscending(string ColName)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.SortByColumnAscending(ColName);
        }

        public List<SalesOrders> SortByColumnDescending(string ColName)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.SortByColumnDescending(ColName);
        }

        public decimal CalculateTotalCost(List<decimal> rowCostList, decimal discountCost, decimal shippingCost)
        {
            decimal totalCost = rowCostList.ToArray().Sum() - discountCost + shippingCost;
            return totalCost < 0 ? 0 : totalCost;
        }

        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice)
        {
            return Qty * unitPrice;
        }

        public SalesOrders GetOne(int OrderID)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.GetOne(OrderID);
        }

        private SalesOrders CalculateCosts(SalesOrders order)
        {
            order.OrderSummary.TotalOrder = CalculateTotalCost(order.OrderRows.Select(o => o.TotalRowPrice).ToList(), order.OrderSummary.DiscountAmount, order.OrderSummary.ShippingCost);
            return order;
        }

        public bool DeleteOne(int Id)
        {
            IEntityManager<SalesOrders> OrderDal = new OrderMapper();
            return OrderDal.DeleteOne(Id);
        }

        public bool ValidateOrder(SalesOrders order)
        {
            IEntityManager<Customer> CustomerDal = new CustomerMapper();
            if (!CustomerDal.CheckIfCustomerExists(order.CustomerID))
            {
                throw new BusinessLogicException("The entered CustomerID doesnt exist.");
            }
            if (order.DateOrder > order.OrderSummary.DeliveryDate)
            {
                throw new BusinessLogicException("The Delivery Date is sooner than the Date of Order. Please change it");
            }
            if (order.OrderSummary.ShippingAddress.Length <= 0)
            {
                throw new BusinessLogicException("Please enter a valid shipping address");
            }
            if (order.OrderRows.Count == 0)
            {
                throw new BusinessLogicException("Order has no Sales Rows. Please add rows or delete the order instead.");
            }
            foreach (FileEntity file in order.OrderSummary.files)
            {
                if (file.Ext.Equals(".exe"))
                {
                    throw new BusinessLogicException(".exe files are not allowed.");
                }
            }
            return true;
        }

        public List<SalesOrders> GetCustomerOrdersCost()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfCustomerExists(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCustomer(SalesOrders obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
