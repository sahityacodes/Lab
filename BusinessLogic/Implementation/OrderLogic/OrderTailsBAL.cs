using BusinessEntityLayer.Model;
using BusinessLogic.Implementation.FileOperationsLogic;
using BusinessLogic.Interfaces;
using EntityManagementLayer.Implementation;
using EntityManagementLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementation.OrderLogic
{
    public class OrderTailsBAL : IBLL<SalesOrdersTail>
    {

        public bool DeleteAll(int Id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOne(int Id)
        {
            throw new NotImplementedException();
        }

        public List<SalesOrdersTail> GetAll()
        {
            throw new NotImplementedException();
        }

        public SalesOrdersTail GetOne(int OrderID)
        {
            IEntityManager<SalesOrdersTail> OrderTailsDal = new OrderTailsMapper();
            return OrderTailsDal.GetOne(OrderID);
        }

        public bool UpdateOne(SalesOrdersTail obj)
        {
            IEntityManager<SalesOrdersTail> OrderTailsDal = new OrderTailsMapper();
            return OrderTailsDal.UpdateOne(obj);
        }
        public bool InsertOne(SalesOrdersTail obj)
        {
            IEntityManager<SalesOrdersTail> OrderTailsDal = new OrderTailsMapper();
            return OrderTailsDal.InsertOne(obj);
        }
        public List<SalesOrdersTail> GetOneByName(string name)
        {
            throw new NotImplementedException();
        }
        public List<SalesOrdersTail> SortByColumnAscending(string colName)
        {
            throw new NotImplementedException();
        }

        public List<SalesOrdersTail> SortByColumnDescending(string colName)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalCost(List<decimal> rowCostList, decimal discountCost, decimal shippingCost)
        {
            throw new NotImplementedException();
        }

        public bool ValidateOrder(SalesOrdersTail obj)
        {
            throw new NotImplementedException();
        }

        public List<SalesOrdersTail> GetCustomerOrdersCost()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfCustomerExists(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ValidateCustomer(SalesOrdersTail obj)
        {
            throw new NotImplementedException();
        }
    }
}
