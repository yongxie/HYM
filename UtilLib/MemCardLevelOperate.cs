using System;
using System.Collections.Generic;
using System.Text;
using DBUtil;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UtilLib
{
    /// <summary>
    /// 记录会员操作历史类
    ///</summary>
    public class MemCardLevelOperate
    {
        /// 记录会员消费动作
        /// <param name="strUserID">会员消费ID</param>
        /// <param name="strProgramID">程序模块ID</param>
        /// <param name="strUserOperate">会员消费动作</param>
        public static void SaveRecord(string strUserID, string CardId, string strOperateType, string strDesc, double Money,int dir)
        {
            DBManager db = DBManager.Instance();

            try
            {
                int ReturnValue = 0;
                db.Transact("insert into Mem_Card_ExpendRecord (operatetype,UserId,Cardid,OperateTime,Description,Money,Dir) values ('" + strOperateType + "','" + strUserID
                    + "','" + CardId + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + strDesc + "','" + Money + "','" + dir + "')", out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("保存会员消费数据出错！");
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：保存会员消费数据出错！");
                //Common.ErrLog(exc.ToString());
            }
        }

        /// <summary>
        /// 用于显示操作员名称(用于DataGrid绑定)
        /// </summary>
        public DataTable ShowName()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable("select UserId,UserName from Sys_User");
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询操作员信息失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 用于显示会员名称(用于DataGrid绑定)
        /// </summary>
        public DataTable ShowMemName()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable("select MemId,MemName from Mem");
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询会员信息失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取会员记录(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind(string strStartDate, string strEndDate,string userid)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("MemCarsLevelOperate");
            try
            {
                string strSql = "";
                if (userid == "")
                {
                    strSql = @"select a.OperateType,a.CardId,a.UserId,a.OperateTime,c.UserName, a.Description,a.Money,b.MemName,Dir=CASE Dir WHEN 0 THEN '消费' WHEN 1 THEN '充值' end 
                                                              from Mem_Card_ExpendRecord a,Mem b,Sys_User c where a.CardId = b.CardId and a.UserId = c.UserId and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' order by a.OperateTime desc";
                }
                else
                {
                    strSql = @"
          with subqry(UserId,UserName,Father) as (select UserId,UserName,Father from Sys_User where
                                        UserId='" + userid + @"' union all select Sys_User.UserId,Sys_User.UserName, Sys_User.Father from Sys_User,subqry
                                        where Sys_User.Father = subqry.UserId) 
                                        
select a.OperateType,a.CardId,a.UserId,a.OperateTime,c.UserName, a.Description,a.Money,b.MemName,Dir=CASE Dir WHEN 0 THEN '消费' WHEN 1 THEN '充值' end 
                                                              from Mem_Card_ExpendRecord a,Mem b,subqry c where a.CardId = b.CardId and a.UserId = c.UserId and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' order by a.OperateTime desc";
                }
                dt = db.GetDataTable(strSql);
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询会员消费日志失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取会员记录(用于DataGrid绑定)
        /// </summary>
        public DataTable BindAgent(string strStartDate, string strEndDate,string GroupID,string UserID)
        {
//            DBManager db = DBManager.Instance();
//            DataTable dt = new DataTable("LevelOperate");
            
//            try
//            {
//                if (UserId == "")
//                {
//                    dt = db.GetDataTable(@"select a.UserId,b.UserName,sum(Money) as Money,a.OperateTime,Dir=CASE a.Dir WHEN 0 THEN '消费总额：' WHEN 1 THEN '充值总额：' end
//                                            from Mem_Card_ExpendRecord a,Sys_User b where a.UserId = b.UserId and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' group by a.UserId,Dir,b.UserName");
//                }
//                else
//                {
//                    dt = db.GetDataTable(@"select a.UserId,b.UserName,sum(Money) as Money,a.OperateTime,Dir=CASE a.Dir WHEN 0 THEN '消费总额：' WHEN 1 THEN '充值总额：' end
//                                            from Mem_Card_ExpendRecord a,Sys_User b where a.UserId = b.UserId and a.UserId='" +UserId+"' and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' group by a.UserId,Dir,b.UserName");
//                }
//                return dt;
//            }
//            catch//(Exception exc)
//            {
//                Common.ShowMsg("系统警告:查询代理商消费统计失败!");
//                //Common.ErrLog(exc.ToString());
//                return null;
//            }

            string conStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            DataTable dt = new DataTable();


            try
            {
                SqlCommand cmd = new SqlCommand("HYM_Tongji_AgentXiaofei", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter p1 = new SqlParameter("@userid", SqlDbType.NVarChar, 20);
                //p1.SqlValue = UserID;
                //p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@StartDate", SqlDbType.DateTime);
                p2.SqlValue = strStartDate;
                p2.Direction = ParameterDirection.Input;
                SqlParameter p3 = new SqlParameter("@EndDate", SqlDbType.DateTime);
                p3.SqlValue = strEndDate;
                p3.Direction = ParameterDirection.Input;
                SqlParameter p4 = new SqlParameter("@OperaterGroupId", SqlDbType.NVarChar, 20);
                p4.SqlValue = GroupID;
                p4.Direction = ParameterDirection.Input;

                SqlParameter p5 = new SqlParameter("@OperaterUserId", SqlDbType.NVarChar, 20);
                p5.SqlValue = UserID;
                p5.Direction = ParameterDirection.Input;

                //SqlParameter p5 = new SqlParameter("@retResult", SqlDbType.NVarChar, 100);
                //p5.Direction = ParameterDirection.Output;

                //cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                return dt;
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告:查询代理商消费统计失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取会员记录(用于DataGrid绑定)
        /// </summary>
        public DataTable BindMem(string UserID,string strStartDate, string strEndDate,string operaterGroupID, string operaterUserId)
        {
//            DBManager db = DBManager.Instance();
//            DataTable dt = new DataTable("LevelOperate");
//            string sql = db.GetValue("select GroupId from Sys_User where UserId='" + UserId + "'").ToString();
//            int count = int.Parse(sql);
//            try
//            {
//                if (count == 1)
//                {
//                    dt = db.GetDataTable(@"select a.UserId,b.UserName,c.CardId,c.MemName, sum(Money) as Money,Dir=CASE a.Dir WHEN 0 THEN '消费总额：' WHEN 1 THEN '充值总额：' end
//                                              from Mem_Card_ExpendRecord a,Sys_User b,Mem c where a.UserId = b.UserId and c.CardId=a.CardId and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' group by a.UserId,Dir,b.UserName,c.CardId,c.MemName");
//                }
//                else
//                {
//                    dt = db.GetDataTable(@"select a.UserId,b.UserName,c.CardId,c.MemName, sum(Money) as Money,Dir=CASE a.Dir WHEN 0 THEN '消费总额：' WHEN 1 THEN '充值总额：' end
//                                              from Mem_Card_ExpendRecord a,Sys_User b,Mem c where a.UserId = b.UserId and a.UserId='"+UserId+"' and c.CardId=a.CardId and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' group by a.UserId,Dir,b.UserName,c.CardId,c.MemName");
//                }
            //                return dt;
            string conStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            DataTable dt = new DataTable();


            try
            {
                SqlCommand cmd = new SqlCommand("HYM_Tongji_MemXiaofei", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@userid", SqlDbType.NVarChar, 20);
                p1.SqlValue = UserID;
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@StartDate", SqlDbType.DateTime);
                p2.SqlValue = strStartDate;
                p2.Direction = ParameterDirection.Input;
                SqlParameter p3 = new SqlParameter("@EndDate", SqlDbType.DateTime);
                p3.SqlValue = strEndDate;
                p3.Direction = ParameterDirection.Input;
                SqlParameter p4 = new SqlParameter("@OperaterGroupId", SqlDbType.NVarChar, 20);
                p4.SqlValue = operaterGroupID;
                p4.Direction = ParameterDirection.Input;

                SqlParameter p5 = new SqlParameter("@OperaterUserId", SqlDbType.NVarChar, 20);
                p5.SqlValue = operaterUserId;
                p5.Direction = ParameterDirection.Input;

                //SqlParameter p5 = new SqlParameter("@retResult", SqlDbType.NVarChar, 100);
                //p5.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询会员消费统计失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }
    }
}
