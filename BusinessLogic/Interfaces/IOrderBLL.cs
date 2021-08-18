using BusinessEntityLayer.Model;

namespace BusinessLogic.Interfaces
{
    public interface IOrderBLL<T> : IBLL<T>
    {
        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice);
        public decimal CalculateTotalCost(decimal totalRowscost, decimal discountCost, decimal shippingCost);
    }
}
