using System;

namespace BusinessEntityLayer.Model
{
    public class SalesOrdersTail
    {
        public int OrderId
        { get; set; }
        public string ShippingAddress
        { get; set; }
        public decimal ShippingCost
        { get; set; }
        public DateTime DeliveryDate = DateTime.Today;
        public decimal DiscountAmount 
        { get; set; }
        public decimal TotalOrder 
        { get; set; }
    }
}
