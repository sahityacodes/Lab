using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IBLL<T>
    {
        public List<T> GetAll();
        public List<T> GetOneByName(string name);
        public T GetOne(int OrderID);
        public bool InsertOne(T obj);
        public bool UpdateOne(T obj);
        public bool DeleteOne(int Id);
        public bool DeleteAll(int Id);
        public List<T> SortByColumnAscending(string colName);
        public List<T> SortByColumnDescending(string colName);
        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice);
        public decimal CalculateTotalCost(List<decimal> rowCostList, decimal discountCost, decimal shippingCost);
        public bool ValidateOrder(T obj);
        public List<T> GetCustomerOrdersCost();
        public bool CheckIfCustomerExists(int Id);
        public bool ValidateCustomer(T obj);

    }
}
