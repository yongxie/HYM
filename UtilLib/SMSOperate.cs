using System;
using System.Collections.Generic;
using System.Text;
using DBUtil;
using System.Data;

namespace UtilLib
{
    public class SMSOperateDB
    {
        public string MsgId;
        public string DirNum;
        public string Msg;
        public DateTime SendTime;
    }

    /// <summary>
    /// 记录短信发送操作历史类
    ///</summary>
    public class SMSOperate
    {
        /// 记录短信发送日志
        public static void SaveRecord(String DirNum, String Msg)
        {
            DBManager db = DBManager.Instance();

            try
            {
                int ReturnValue = 0;
                db.Transact("insert into SMS_Log (DirNum,Msg,SendTime) values ('" + DirNum + "','" + Msg
                    + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("保存短信发送记录数据出错！");
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：保存短信发送记录数据出错！");
                //Common.ErrLog(exc.ToString());
            }
        }
        /// <summary>
        /// 用于显示详细信息(用于DataGrid绑定)
        /// </summary>
        public SMSOperateDB ShowMsg(string MsgId)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable("select DirNum,Msg,SendTime from SMS_Log where MsgId=" + MsgId);
                SMSOperateDB smsDB = new SMSOperateDB();
                if (dt.Rows.Count > 0)
                {
                    smsDB.MsgId = MsgId;
                    smsDB.DirNum = Common.CNullToStr(dt.Rows[0]["DirNum"]);
                    smsDB.Msg = Common.CNullToStr(dt.Rows[0]["Msg"]);
                    smsDB.SendTime = Convert.ToDateTime(Common.CNullToStr(dt.Rows[0]["SendTime"]));

                }
                return smsDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询短信发送详细信息失败！");
                return new SMSOperateDB();
            }
        }

        /// <summary>
        /// 获取短信发送记录(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind(string strStartDate, string strEndDate)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("SMSOperate");
            try
            {
                dt = db.GetDataTable("select MsgId,DirNum,SendTime,Substring(Msg,0,40) as Msg from SMS_Log where SendTime >= '" + strStartDate + "' and SendTime < '" + strEndDate + "' order by SendTime desc");
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询短信发送日志失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }
    }
}
