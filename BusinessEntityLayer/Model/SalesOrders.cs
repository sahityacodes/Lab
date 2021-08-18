using System;
using System.Collections.Generic;

namespace BusinessEntityLayer.Model
{
    public class SalesOrders
    {
        public int OrderID
        { get; set; }

        public int CustomerID
        { get; set; }

        public DateTime DateOrder = DateTime.Today;

        public string Payment
        { get; set; }

        public List<SalesOrdersRows> OrderRows = new List<SalesOrdersRows>();

        public SalesOrdersTail OrderSummary = new();
    }
}
