using DALayer.Utils;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace DALayer.Implementation
{
    class SqlDB_DAL
    {
        private SqlConnection OpenDB()
        {
            SqlConnection objSqlConnection = new(Constants.ConnectionString);
            objSqlConnection.Open();
            return objSqlConnection;
        }

        private void CloseDB(SqlConnection objSqlConnection)
        {
            objSqlConnection.Close();
        }

        internal DataTable GetRecords(string queryStr, params IDataParameter[] sqlParams)
        {
            DataTable dt = new();
            SqlConnection objSqlConnection = new SqlConnection(Constants.ConnectionString);
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

        internal bool WriteToTable(Dictionary<string, List<SqlParameter[]>> queries)
        {
            bool rows = false;
            SqlConnection objSqlConnection = OpenDB();
            SqlTransaction sqlTran = objSqlConnection.BeginTransaction();
            try
            {
                foreach (KeyValuePair<string, List<SqlParameter[]>> query in queries)
                {
                    SqlCommand com = new(query.Key, objSqlConnection, sqlTran);
                    if (query.Value != null)
                    {
                        foreach (IDataParameter[] para in query.Value)
                        {
                            foreach (IDataParameter par in para)
                            {
                                com.Parameters.Add(par);
                            } 
                            Debug.WriteLine(com.ExecuteNonQuery());
                            com.Parameters.Clear();
                        }
                    }

                }
                sqlTran.Commit();
                rows = true;
            }
            catch (SqlException)
            {
                sqlTran.Rollback();
                throw;
            }
            finally
            {
                CloseDB(objSqlConnection);
            }
            return rows;
        }
    }
}
