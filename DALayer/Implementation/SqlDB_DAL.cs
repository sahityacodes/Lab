using DALayer.Utils;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DALayer.Implementation
{
    public class SqlDB_DAL
    {
        private SqlTransaction tran;
        private SqlConnection objSqlConnection;
        public void OpenDB()
        {
            objSqlConnection = new(Constants.ConnectionString);
            objSqlConnection.Open();
        }

        public void CloseDB()
        {
            objSqlConnection.Close();
        }
        public void OpenTransaction()
        {
            tran = objSqlConnection.BeginTransaction();
        }
        public void CommitTransaction()
        {
            tran.Commit();
        }

        public void RollbackTransaction()
        {
            tran.Rollback();
        }
        public DataTable GetRecords(string queryStr, params IDataParameter[] sqlParams)
        {
            Debug.WriteLine(queryStr);
            DataTable dt = new();
            SqlConnection objSqlConnection = new(Constants.ConnectionString);
            SqlCommand com = new(queryStr, objSqlConnection);
            if (sqlParams != null)
            {
                foreach (IDataParameter para in sqlParams)
                {
                    com.Parameters.Add(para);
                }
            }
            SqlDataAdapter sqlDataAdapter = new(com);
            dt.Clear();
            sqlDataAdapter.Fill(dt);
            com.Parameters.Clear();
            return dt;
        }


        public bool WriteToTable(string query, params IDataParameter[] parameters)
        {
            Debug.WriteLine(query);
            SqlCommand com = new(query, objSqlConnection, tran);
            if (parameters != null)
            {
                    foreach (IDataParameter par in parameters)
                    {
                        com.Parameters.Add(par);
                    }
            }
            return com.ExecuteNonQuery() > -1 ? true : false;
        }
    }
}
