using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;//注意添加引用
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;//注意添加引用


namespace Web.main_paymanager.program
{
    /// <summary>
    /// Tishi 的摘要说明
    /// </summary>
    public class Tishi : IHttpHandler
    {

        //设置几个全局变量
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string keyword = context.Request.QueryString["keyword"];
            if (keyword != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer(); // 通过JavaScriptSerializer对象的Serialize序列化为["value1","value2",...]的字符串 
                string jsonString = serializer.Serialize(GetFilteredList(keyword));
                context.Response.Write(jsonString); // 返回客户端json格式数据
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 根据关键字过滤数据
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>过滤数据</returns>
        private string[] GetFilteredList(string keyword)
        {
            sdr = GetData(keyword);
            List<string> nameList = new List<string>();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                while (sdr.Read())
                {
                    string name = sdr["Code"].ToString();
                    nameList.Add(name);
                }
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return nameList.ToArray();
        }


        /// <summary>
        ///  构造测试数据
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetData(string key)
        {
            conn = new SqlConnection(connStr);
            string sql = "select Code from Goods where Code like '" + key + "%' ";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                cmd = new SqlCommand(sql, conn);
                sdr = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ToString());
            }
            return sdr;
        }
    }
}