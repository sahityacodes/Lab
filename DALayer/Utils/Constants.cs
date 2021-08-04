namespace DALayer.Utils
{
    sealed class Constants
    {
        //xml file path
        public static string FilePath = @"C:\Users\sahit\source\repos\Lab\DALayer\dataset.xml";

        public static string ConnectionString = @"Data Source=np:\\.\pipe\LOCALDB#2A396B76\tsql\query;Initial Catalog=CustomerDB;Integrated Security=True";

        public static string QUERY_GETALL = "SELECT * FROM Customer";

        public static string QUERY_GETBYNAME = "Select * from Customer where (Name + VAT + Address + City)  LIKE @Word";

        public static string QUERY_UPDATE = "Update Customer set Name=@Name, Phone=@Phone, VAT=@VAT, Address=@Address, City=@City, AnnualRevenue=@AnnualRevenue where Id=@Id";

        public static string QUERY_INSERT = "Insert into Customer(Name,Phone,VAT,Address,City,AnnualRevenue) Values (@Name, @Phone, @VAT, @Address, @City, @AnnualRevenue)";

        public static string QUERY_DELETEONE = "Delete from Customer where Id=@Id";

        public static string QUERY_SORTBYCOLUMNASC = "Select * from Customer Order By Id ASC";

        public static string QUERY_SORTBYCOLUMNDESC = "Select * from Customer Order By Id DESC";

        public static string DBNull = "";
    }
}
