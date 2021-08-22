namespace BusinessLogic.Interfaces
{
    public interface IOrderBLL<T> : IBLL<T>
    {
        public decimal CalculateTotalUnitCost(decimal Qty, decimal unitPrice);
        public decimal CalculateTotalCost(decimal totalRowscost, decimal discountCost, decimal shippingCost);
        public bool ValidateOrder(T obj);
    }
}
