using DALayer.Utils;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace DALayer.Implementation
{
    static class DriverConfirguration
    {
       public static SqlConnection OpenConnection()
        {
            SqlConnection objSqlConnection = new(Constants.ConnectionString);
            objSqlConnection.Open();
            return objSqlConnection;
        }


        public static void SaveChanges(DataTable dataTable)
        {
                dataTable.WriteXml(Constants.FilePath);
        }
    }
}
