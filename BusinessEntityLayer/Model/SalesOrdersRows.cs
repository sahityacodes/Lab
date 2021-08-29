namespace BusinessEntityLayer.Model
{
    public class SalesOrdersRows
    {
        public int OrderID
        { get; set; }

        public int RowID
        { get; set; }

        public string ProductCode
        { get; set; }

        public string Description
        { get; set; }

        public decimal Qty
        { get; set; }

        public decimal UnitPrice
        { get; set; }

        private decimal _TotalRowPrice;

        public decimal TotalRowPrice
        {
            get { return Qty * UnitPrice; }
            set { _TotalRowPrice = value; }
        }
        public SalesOrdersRows()
        {

        }
        public SalesOrdersRows(string productCode, string description, decimal qty, decimal unitPrice)
        {
            ProductCode = productCode;
            Description = description;
            Qty = qty;
            UnitPrice = unitPrice;
        }
    }
}
