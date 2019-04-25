using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBUtil
{
    /// <summary>
    /// 数据库访问的实现类(SQLSERVER)
    /// </summary>
    public class SqlDBProvider : DBManager
    {
        #region Private Members
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private SqlConnection conn;
        /// <summary>
        /// 事务处理类对象
        /// </summary>
        private SqlTransaction trans;
        /// <summary>
        /// 指示当前是否正处于事务中
        /// </summary>
        //private bool inTransaction = false;
        #endregion

        #region Public Methods
        /// <summary>
        /// 构造函数(创建连接对象)
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public SqlDBProvider(string strConn)
        {
            this.conn = new SqlConnection(strConn);
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        public override void BeginTransaction()
        {
            if (trans != null) trans.Dispose();
            conn.Open();
            trans = conn.BeginTransaction();

            //inTransaction = true;
        }

        /// <summary>
        /// 执行一个事务
        /// </summary>
        public override void ExecTransaction(string strSql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.EndTransaction(false);
                throw ex;
            }
        }
        /// <summary>
        /// 执行一个事务
        /// </summary>
        /// <param name="cmd"></param>
        public override void ExecTransaction(IDbCommand cmd)
        {
            try
            {
                SqlCommand myCmd = cmd as SqlCommand;
                myCmd.Transaction = trans;
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.EndTransaction(false);
                throw ex;
            }
        }

        /// <summary>
        /// 结束事务
        /// </summary>
        /// <param name="commit"></param>
        public override void EndTransaction(bool commit)
        {
            try
            {
                if (trans == null)
                {
                    if (!commit) throw new Exception("没有在事务中执行，无法回滚");
                    return;

                }
                if (commit)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL命令返回 DataSet
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override DataSet GetDataSet(string strSql)
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行SQL命令返回 DataSet
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override DataSet GetDataSet(string strSql, string tableName)
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, tableName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行SQL命令返回 DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override DataTable GetDataTable(string strSql)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL命令返回第一行第一列的值
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override object GetValue(string strSql)
        {
            object obj;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return obj;
        }
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="strSql"></param>
        public override void Transact(string strSql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL命令并返回受影响的行数
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="rowsAffected"></param>
        public override void Transact(string strSql, out int rowsAffected)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="cmd"></param>
        public override void Transact(IDbCommand cmd)
        {
            try
            {
                SqlCommand myCmd = cmd as SqlCommand;
                myCmd.Connection = conn;
                conn.Open();
                myCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL命令并返回受影响的行数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="rowsAffected"></param>
        public override void Transact(IDbCommand cmd, out int rowsAffected)
        {
            try
            {
                SqlCommand myCmd = cmd as SqlCommand;
                myCmd.Connection = conn;
                conn.Open();
                rowsAffected = myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        #endregion
    }
}
