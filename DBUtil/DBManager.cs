using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

namespace DBUtil
{
    public abstract class DBManager
    {
        #region Public Enum
        /// <summary>
        /// 数据库连接类型
        /// </summary>
        public enum DBConnectionType
        {
            /// <summary>
            /// MS SQL Server
            /// </summary>
            SqlServer,
            /// <summary>
            /// MS Access
            /// </summary>
            Access
        }
        #endregion

        #region Public Methods

        //public abstract 
        /// <summary>
        /// 开始事务
        /// </summary>
        public abstract void BeginTransaction();

        /// <summary>
        /// 执行事务
        /// </summary>
        public abstract void ExecTransaction(string strSql);

        public abstract void ExecTransaction(IDbCommand cmd);
        /// <summary>
        /// 结束事务
        /// </summary>
        public abstract void EndTransaction(bool commit);

        /// <summary>
        /// 执行SQL命令并返回 DataSet
        /// </summary>
        /// <param name="commandString">SQL命令</param>
        /// <param name="tableName">要填充的表名</param>
        /// <returns>返回 DataSet</returns>
        public abstract DataSet GetDataSet(string strSql, string tableName);

        /// <summary>
        /// 执行SQL命令并返回 DataSet
        /// </summary>
        /// <param name="strSql">SQL命令</param>
        /// <returns>返回 DataSet</returns>
        public abstract DataSet GetDataSet(string strSql);
        /// <summary>
        /// 执行SQL命令并返回 DataTale
        /// </summary>
        /// <param name="commandString">SQL语句</param>
        /// <returns>返回 DataTable</returns>
        public abstract DataTable GetDataTable(string strSql);

        /// <summary>
        /// 执行SQL命令并返回受影响的行数
        /// </summary>
        /// <param name="commandString">SQL命令</param>
        /// <param name="rowsAffected">返回影响的行数</param>
        public abstract void Transact(string strSql, out int rowsAffected);
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="strSql">SQL命令</param>
        public abstract void Transact(string strSql);

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="cmd"></param>
        public abstract void Transact(IDbCommand cmd);
        /// <summary>
        /// 执行SQL命令并返回受影响的行数
        /// </summary>
        /// <param name="cmd">IDbCommand</param>
        public abstract void Transact(IDbCommand cmd, out int rowsAffected);
        /// <summary>
        /// 执行SQL命令并返回一个值
        /// </summary>
        /// <param name="commandString">SQL命令</param>
        /// <returns>执行SQL命令以返回一个 Object 值</returns>
        public abstract object GetValue(string strSql);

        /// <summary>
        /// 通过运行目录下的 config 配置文件实例化一个数据库操作类
        /// </summary>
        /// <returns>返回数据库操作类的实例</returns>
        public static DBManager Instance()
        {
            string conStr;
            string connectionKey;

            connectionKey = ConfigurationManager.AppSettings["ConnectionType"].ToString();
            if (connectionKey.ToUpper().Trim() == "SQLSERVER")
            {
                conStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
                return new SqlDBProvider(conStr);
            }
            else
            {
                conStr = ConfigurationManager.ConnectionStrings["ACCESS"].ConnectionString;
                return new OleDBProvider(conStr);
            }
        }

        /// <summary>
        /// 实例化一个数据库操作类
        /// </summary>
        /// <param name="connectionType">连接类型</param>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>返回数据库操作类的实例</returns>
        public static DBManager Instance(DBConnectionType connectionType, string conStr)
        {
            if (connectionType == DBConnectionType.SqlServer)
                return new SqlDBProvider(conStr);
            else
                return new OleDBProvider(conStr);
        }
        #endregion
    }
}
