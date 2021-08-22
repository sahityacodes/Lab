namespace EntityManagementLayer.Utils
{
    sealed class Constants
    {
        //Customer Queries
        public static string QUERY_GETALL = "SELECT * FROM [Customer]";
        public static string QUERY_GETBYNAME = "Select * from Customer where (Name + VAT + Address + City)  LIKE @Word";
        public static string QUERY_UPDATE = "Update Customer set Name=@Name, Phone=@Phone, VAT=@VAT, Address=@Address, City=@City, AnnualRevenue=@AnnualRevenue where Id=@Id";
        public static string QUERY_INSERT = "Insert into Customer(Name,Phone,VAT,Address,City,AnnualRevenue) Values (@Name, @Phone, @VAT, @Address, @City, @AnnualRevenue)";
        public static string QUERY_DELETEONE = "Delete from Customer where Id=@Id";
        public static string QUERY_SORTBYCOLUMNASC = "Select * from Customer Order By case WHEN @orderby = '0' Then Id ELSE null END ASC,case WHEN @orderby = '6' Then AnnualRevenue ELSE null END ASC";
        public static string QUERY_SORTBYCOLUMNDESC = "Select * from Customer Order By case WHEN @orderby = '0' Then Id ELSE null END DESC,case WHEN @orderby = '6' Then AnnualRevenue ELSE null END DESC";
        public static string QUERY_CHECKIFCUSTOMER_EXISTS = "SELECT * FROM Customer where Id=@Id";
        //Order Queries
        public static string QUERY_SELECTALLORDERS = "SELECT * FROM SalesOrders s INNER JOIN SalesOrdersTails tail on s.OrderID = tail.OrderID  INNER JOIN SalesOrdersRows r on s.OrderID=r.OrderID";
        public static string QUERY_SELECTALLORDERS_ONE = "SELECT * FROM SalesOrders s INNER JOIN SalesOrdersTails tail on s.OrderID = tail.OrderID  INNER JOIN SalesOrdersRows r on s.OrderID=r.OrderID and s.OrderID = @OrderID";
        public static string QUERY_FINDORDER = "SELECT * FROM SalesOrders s INNER JOIN SalesOrdersTails tail on s.OrderID = tail.OrderID INNER JOIN SalesOrdersRows r on s.OrderID=r.OrderID where (CAST(s.OrderID as CHAR)+ tail.ShippingAddress + CAST(s.CustomerID as CHAR) + CAST(r.ProductCode as CHAR))  LIKE @Word";
        public static string TOTAL_ORDER_COST = "SELECT   Customer.Id , count(SalesOrders.OrderID) TotalOrders, sum(SalesOrdersTails.TotalCost) TotalAmount FROM Customer JOIN SalesOrders ON Customer.Id = SalesOrders.CustomerID JOIN SalesOrdersTails ON SalesOrdersTails.OrderID = SalesOrders.OrderID group by Customer.Id";
        public static string QUERY_UPDATE_ORDERS = "Update SalesOrders set CustomerID=@CustomerID, DateOrder=@DateOrder, Payment=@Payment where OrderID=@OrderID";
        public static string QUERY_UPDATE_ORDERS_ROWS = "Update SalesOrdersRows set ProductCode=@ProductCode, Description=@Description, Qty=@Qty, UnitPrice = @UnitPrice,TotalRowPrice = @TotalRowPrice where RowID=@RowID AND OrderID=@OrderID";
        public static string QUERY_UPDATE_ORDERS_TAILS = "Update SalesOrdersTails set ShippingAddress=@ShippingAddress, DiscountAmount=@DiscountAmount, ShippingCost=@ShippingCost,TotalCost=@TotalCost,DeliveryDate=@DeliveryDate where OrderID=@OrderID";
        public static string QUERY_INSERT_ORDERS = "Insert into SalesOrders(CustomerID,DateOrder,Payment) Values (@CustomerID, @DateOrder, @Payment);";
        // public static string QUERY_INSERT_ORDERS = "CREATE PROCEDURE Insert_Orders (@CustomerID INT, @DateOrder DATETIME, @Payment VARCHAR(255)) AS INSERT INTO SalesOrders(CustomerID,DateOrder,Payment) VALUES(@CustomerID,@DateOrder,@Payment)";
        public static string GET_SCOPE_ID = "select SCOPE_IDENTITY() as OrderID;";
        public static string IDEN_QUERY_ORDERS = "SELECT IDENT_CURRENT('SalesOrders')";
        public static string QUERY_INSERT_ORDERROWS = "Insert into SalesOrdersRows(OrderID, RowID, ProductCode,Description,Qty,UnitPrice,TotalRowPrice) Values (@OrderID, @RowID, @ProductCode, @Description, @Qty, @UnitPrice, @TotalRowPrice);";
        public static string QUERY_INSERT_ORDERDETAILS = "Insert into SalesOrdersTails(OrderID,ShippingAddress,ShippingCost,DeliveryDate,DiscountAmount,TotalCost) Values (@OrderID, @ShippingAddress, @ShippingCost, @DeliveryDate, @DiscountAmount, @TotalCost);";
        public static string QUERY_DELETEONE_ORDERS = "Delete from SalesOrders where OrderID=@OrderID";
        public static string QUERY_DELETEONE_ROW = "Delete from SalesOrdersRows where OrderID=@OrderID and RowID=@RowID";
        public static string QUERY_SORTBYCOLUMNASC_ORDERS = "SELECT * FROM SalesOrders s INNER JOIN SalesOrdersTails tail on s.OrderID = tail.OrderID  INNER JOIN SalesOrdersRows r on s.OrderID=r.OrderID  Order By case WHEN @orderby = '0' Then s.OrderID ELSE null END ASC,case WHEN @orderby = '1' Then s.CustomerID ELSE null END ASC,case WHEN @orderby = '2' Then s.DateOrder ELSE null END ASC,case WHEN @orderby = '11' Then tail.TotalCost ELSE null END ASC, case WHEN @orderby = '12' Then tail.DeliveryDate ELSE null END ASC";
        public static string QUERY_SORTBYCOLUMNDESC_ORDERS = "SELECT * FROM SalesOrders s INNER JOIN SalesOrdersTails tail on s.OrderID = tail.OrderID  INNER JOIN SalesOrdersRows r on s.OrderID=r.OrderID  Order By case WHEN @orderby = '0' Then s.OrderID ELSE null END DESC,case WHEN @orderby = '1' Then s.CustomerID ELSE null END DESC,case WHEN @orderby = '2' Then s.DateOrder ELSE null END DESC,case WHEN @orderby = '11' Then tail.TotalCost ELSE null END DESC, case WHEN @orderby = '12' Then tail.DeliveryDate ELSE null END DESC";
    
        public static string DBNull = ""; 


    }
}
