using System;
using System.Collections.Generic;
using System.Text;
using DBUtil;
using System.Data;

namespace UtilLib
{
    /// <summary>
    /// 记录操作员操作历史类
    ///</summary>
    public class RecordOperate
    {
        /// 记录操作员动作
        /// <param name="strUserID">操作员ID</param>
        /// <param name="strProgramID">程序模块ID</param>
        /// <param name="strUserOperate">操作员动作</param>
        public static void SaveRecord(String strUserID, String strOperateType, String strDesc)
        {
            DBManager db = DBManager.Instance();

            try
            {
                int ReturnValue =0;
                db.Transact("insert into sys_log (operatetype,UserId,OperateTime,Description) values ('" + strOperateType + "','" + strUserID 
                    +"','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + strDesc +"')", out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("保存操作员记录数据出错！");
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：保存操作员记录数据出错！");
                //Common.ErrLog(exc.ToString());
            }
        }
        /// <summary>
        /// 用于显示操作员名称(用于DataGrid绑定)
        /// </summary>
        public DataTable ShowName(string groupid,string userid)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                string strSql = "";
                if (groupid != "2" && groupid != "3")
                {
                    strSql = "select userid,username from Sys_User";
                }
                else
                {
                    strSql = @"with subqry(UserId,UserName,Father) as (select UserId,UserName,Father from Sys_User where
                                        UserId='" + userid + @"' union all select Sys_User.UserId,Sys_User.UserName, Sys_User.Father from Sys_User,subqry
                                        where Sys_User.Father = subqry.UserId) select * from subqry";
                }
                dt = db.GetDataTable(strSql);

                //dt = db.GetDataTable("  select b.UserName, a.OperateTime,a.OperateType,a.Description from Tb_ExpendRecord a , Acc_User b where a.UserId = b.UserId ");
                //dt = db.GetDataTable("select UserId from Sys_User where groupid <= 2");
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询系统操作日志失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取操作员记录(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind(string strStartDate,string strEndDate)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("RecordOperate");
            try
            {
                //dt = db.GetDataTable("select a.Id, b.UserName,a.OperateType,a.Description, a.OperateTime from Tb_ExpendRecord a , Acc_User b where a.UserId = b.UserId  ");
                dt = db.GetDataTable("select a.OperateType,a.UserId,a.OperateTime,a.Description,b.UserName from Sys_Log a,Sys_User b where a.UserId = b.UserId and a.OperateTime >= '" + strStartDate + "' and a.OperateTime < '" + strEndDate + "' order by OperateTime desc");
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询系统操作日志失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }
    }
}
