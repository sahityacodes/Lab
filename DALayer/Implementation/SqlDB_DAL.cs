using DALayer.Utils;
using System.Data.SqlClient;
using System.Data;

namespace DALayer.Implementation
{
    class SqlDB_DAL
    {
        internal DataTable GetRecords(string queryStr, params IDataParameter[] sqlParams)
        {
            SqlConnection objSqlConnection = new(Constants.ConnectionString);
            objSqlConnection.Open();
            DataTable dt = new();
            SqlCommand com = new(queryStr, objSqlConnection);
            if (sqlParams != null)
            {
                foreach (IDataParameter para in sqlParams)
                {
                    com.Parameters.Add(para);
                }
            }
            SqlDataAdapter sqlDataAdapter = new(com);
            sqlDataAdapter.Fill(dt);
            objSqlConnection.Close();
            return dt;
        }

        internal bool WriteToTable(string queryStr, params IDataParameter[] sqlParams)
        {
            int rows;
            SqlConnection objSqlConnection = new SqlConnection(Constants.ConnectionString);
            objSqlConnection.Open();
            SqlCommand com = new(queryStr, objSqlConnection);
            if (sqlParams != null)
                {
                    foreach (IDataParameter para in sqlParams)
                    {
                    com.Parameters.Add(para);
                    }
                }
            rows = com.ExecuteNonQuery();
            objSqlConnection.Close();
            return (rows > 0);
        }

    }
}
