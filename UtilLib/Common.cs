using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Diagnostics;

namespace UtilLib
{
    public class Common
    {
        const String EVENT_LOG_SOURCE = "会员管理系统";
        /// <summary>
        /// 弹出提示方法
        /// </summary>
        /// <param name="strMessage">弹出提示信息内容</param>
        public static void ShowMsg(String strMessage)
        {
            HttpContext curHttp = HttpContext.Current;
            curHttp.Response.Write("<script language=javascript>alert('" + strMessage.Replace("'", "''") + "');</script>");
        }

        /// <summary>
        /// 弹出详细信息
        /// </summary>
        /// <param name="strMessage">弹出信息内容</param>
        public static void ShowMsgs(String DirNum, string Msg, string SendTime)
        {
            HttpContext curHttp = HttpContext.Current;
            curHttp.Response.Write("<script language=javascript>alert('手机号码：" + DirNum + "\\n\\n短信内容：\\n\\n" + Msg + "\\n\\n发送时间：" + SendTime + "');</script>");
        }

        /// <summary>
        /// 保留错误信息到操作系统事件信息里
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void ErrLog(String message)
        {
            EventLog m_eventLog = null;

            // 确定已经存在一个自己的事件源
            if (!(EventLog.SourceExists(EVENT_LOG_SOURCE)))
            {
                EventLog.CreateEventSource(EVENT_LOG_SOURCE, "Application");
            }

            if (m_eventLog == null)
            {
                m_eventLog = new EventLog("Application");
                m_eventLog.Source = EVENT_LOG_SOURCE;
            }

            m_eventLog.WriteEntry(message, System.Diagnostics.EventLogEntryType.Error);
        }

        /// <summary>
        /// 从数据库数据表获取字段值时，转换为字符型数据
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static String CNullToStr(object objValue)
        {
            if (objValue != null && !Convert.IsDBNull(objValue)) return Convert.ToString(objValue);
            return "";
        }

        /// <summary>
        /// 从数据类获取字符串值，截取后读取
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static String CCToEmpty(string objValue)
        {
            if (objValue == null) return "";
            return objValue.Replace("&nbsp;", " ").Replace("<br>", "\n");
        }

        /// <summary>
        /// 从WebForm表单传入数据值时，转换为日期型数据
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static DateTime CStrToDate(String strValue)
        {
            if (strValue.Trim() == "") return DateTime.MaxValue;
            return DateTime.Parse(strValue);
        }
    }
}
