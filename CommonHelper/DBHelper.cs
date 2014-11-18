using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace Helper
{
    /// <summary>
    /// 数据库访问帮助类
    /// </summary>
    public class DBHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["migangConStr"].ConnectionString.ToString();

        #region GetConnection 用于获取连接数据库的connection对象
        /// <summary>
        ///  GetConnection 用于获取连接数据库的connection对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            SqlConnection connection= new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
        #endregion
        
        #region 事务
        /// <summary>
        /// 事务
        /// </summary>
        /// <returns></returns>
        public static SqlTransaction BeginTransaction()
        {
            using (SqlConnection connection = GetConnection())
            {
                return connection.BeginTransaction();
            }

        }
        
        #endregion

        #region GetCommand获取命令参数 command对象

        /// <summary>
        /// GetCommand获取命令参数 command对象
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static SqlCommand GetCommand(string commandText, CommandType commandType, SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            return command;
        }
        #endregion

        #region GetCommand 方法重载，CommandText 为sql语句
        /// <summary>
        /// GetCommand 方法重载
        /// </summary>
        /// <param name="commandText">sql语句</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static SqlCommand GetCommand(string commandText, SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            return command;
        }
        #endregion

        #region ExeNonQuery 执行无返回值的sql语句
        /// <summary>
        /// 执行无返回值的sql语句
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlCommand)
        {
            int result = 0;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }
        #endregion

        #region ExecuteScalar 执行有返回值的sql语句
        /// <summary>
        /// 执行有返回值的sql语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText)
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = GetCommand(cmdText, CommandType.Text, connection);
                    connection.Open();
                    object val = command.ExecuteScalar();
                    command.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region GetDataTable 返回DataTable对象
        /// <summary>
        ///  GetDataTable 返回DataTable对象
        /// </summary>
        /// <param name="safesql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string safeSql)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = GetCommand(safeSql, CommandType.Text, connection);
                connection.Open();
                DataTable datatable = new DataTable();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(datatable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return datatable;
            }
        }
        #endregion

        #region GetDataSet 返回DataSet对象
        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="safeSql">传入的SQL语句</param>
        /// <returns>DataSet对象</returns>
        public static DataSet GetDataSet(string safeSql)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = GetCommand(safeSql, CommandType.Text, connection);
                connection.Open();
                DataSet ds = new DataSet();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = command;

                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region GetParameter用于为命令设置参数
        /// <summary>
        /// GetParameter 用于为命令设置参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private static SqlParameter GetParameter(string paramName, object paramValue, SqlCommand command)
        {
            SqlParameter parameter = command.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            return parameter;
        }
        #endregion

        #region ExecuteNonQueryProc 执行无参的存储过程
        /// <summary>
        /// 执行无参的存储过程
        /// </summary>
        /// <param name="sqlCommand">存储过程名</param>
        /// <returns></returns>
        public static int ExecuteNonQueryProc(string sqlCommand)
        {
            int result = 0;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return result;
        }
        #endregion

        #region ExecuteNonQueryProc 方法重载 执行无返回值有参数的存储过程
        /// <summary>
        /// 执行有参数的存储过程
        /// </summary>
        /// <param name="sqlCommand">存储过程名</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQueryProc(string sqlCommand, Dictionary<string, object> parameters)
        {
            int result = 0;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                foreach (KeyValuePair<string, object> p in parameters)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return result;
        }
        #endregion

        #region ExecuteQuery 执行有参数的sql语句
        /// <summary>
        /// 执行有参数的sql语句
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlCommand, Dictionary<string, object> para)
        {
            int result = 0;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                foreach (KeyValuePair<string, object> p in para)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
                return result;
            }
        }
        #endregion

        #region ExecuteScalarProc 执行有返回值无参数的存储过程
        /// <summary>
        /// ExecuteScalarProc 执行有返回值无参数的存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static object ExecuteScalarProc(string cmdText)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(cmdText, CommandType.StoredProcedure, connection);
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region ExecuteScalarProc 执行有返回值的有参数的存储过程
        /// <summary>
        /// 执行有返回值的有参数的存储过程
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public static object ExecuteScalarProc(string cmdText, Dictionary<string, object> para)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(cmdText, CommandType.StoredProcedure, connection);
                foreach (KeyValuePair<string, object> p in para)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region ExecuteScalar 执行有返回值有参数的sql语句
        /// <summary>
        /// 执行有返回值有参数的sql语句
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText,Dictionary<string,object> para)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = GetCommand(cmdText, CommandType.Text, connection);
                foreach(KeyValuePair<string,object> p in para)
                {
                    command.Parameters.Add(GetParameter(p.Key,p.Value,command));
                }
                object val=command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region GetReaderProc 执行无参数的存储过程，返回DbDataReader对象
        /// <summary>
        /// GetReaderProc 执行无参数的存储过程，返回DbDataReader对象
        /// </summary>
        /// <param name="sqlCommand">存储过程名</param>
        /// <returns></returns>
        public static DbDataReader GetReaderProc(string sqlCommand)
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                DbCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                DbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region GetReaderProc 执行有参数的存储过程，返回DbDataReader对象

        public static SqlDataReader GetReaderProc(string sqlCommand, Dictionary<string, object> parameters)
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                foreach (KeyValuePair<string, object> p in parameters)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region GetReader 执行无参数的sql语句，返回DaDataReader对象
        /// <summary>
        /// 执行无参数的sql语句，返回DaDataReader对象
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sqlCommand)
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region GetReader 执行有参数的sql语句，返回DbDataReader对象
        /// <summary>
        /// 执行有参数的sql语句，返回DbDataReader对象
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sqlCommand, Dictionary<string, object> Parameters)
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                foreach (KeyValuePair<string, object> p in Parameters)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region 执行有参数的Sql语句，返回DataSet对象
        /// <summary>
        /// 执行有参数的Sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">传入的参数</param>
        /// <returns>DataSet对象</returns>
        public static DataSet GetDataSet(string sql, Dictionary<string, object> param)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand command = GetCommand(sql, CommandType.Text, conn);
                foreach (KeyValuePair<string, object> p in param)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        public static int ExecuteNonQuery(string sql, Trans t)
        {
            int result = 0;
            SqlConnection connection = t.DbConnection;
            try
            {
                SqlCommand command = GetCommand(sql, CommandType.Text, connection);
                command.Transaction = t.DbTrans;
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
            
        }
    }

    public class Trans : IDisposable
    {
        private SqlConnection conn;
        private SqlTransaction dbTrans;
        public SqlConnection DbConnection
        {
            get { return this.conn; }
        }
        public SqlTransaction DbTrans
        {
            get { return this.dbTrans; }
        }

        public Trans()
        {
            conn = DBHelper.GetConnection();
            conn.Open();
            dbTrans = conn.BeginTransaction();
        }
        public void Commit()
        {
            dbTrans.Commit();
            this.Colse();
        }

        public void RollBack()
        {
            dbTrans.Rollback();
            this.Colse();
        }

        public void Dispose()
        {
            this.Colse();
        }

        public void Colse()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
