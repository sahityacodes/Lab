namespace DALayer.Utils
{
    sealed class Constants
    {
        //xml file path
        public static string FilePath = @"C:\Users\sahit\source\repos\Lab\DALayer\dataset.xml";

        public static string ConnectionString = @"Data Source=(LocalDB)\LocalDb;Initial Catalog=CustomerDB;Integrated Security=True";

        public static string QUERY_GETALL = "SELECT * FROM Customer";

        public static string QUERY_GETBYNAME = "Select * from Customer where (Name  LIKE @Name)";

        public static string QUERY_UPDATE = "Update Customer set Name=@Name, Phone=@Phone, VAT=@VAT, Address=@Address, City=@City, AnnualRevenue=@AnnualRevenue where Id=@Id";

        public static string QUERY_INSERT = "Insert into Customer(Name,Phone,VAT,Address,City,AnnualRevenue) Values (Name=@Name, Phone=@Phone, VAT=@VAT, Address=@Address, City=@City, AnnualRevenue=@AnnualRevenue)";

        public static string QUERY_DELETEONE = "Delete from Customer where Id=@Id";

        public static string DBNull = "";
    }
}
