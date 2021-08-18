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

        public decimal TotalRowPrice
        { get; set; }
    }
}
