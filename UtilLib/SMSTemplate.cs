using System;
using System.Collections.Generic;
using System.Text;
using DBUtil;
using System.Data;

namespace UtilLib
{
    public class SMSTemplateDB
    {
        public string Id;
        public string TemplateName;
        public string TemplateContent;
    }

    /// <summary>
    /// 记录短信模版操作历史类
    ///</summary>
    public class SMSTemplate
    {
        /// <summary>
        /// 用于显示详细信息(用于DataGrid绑定)
        /// </summary>
        public SMSTemplateDB ShowTemp(string Id)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable("select TemplateName,TemplateContent from SMS_Template where Id=" + Id);
                SMSTemplateDB smsDB = new SMSTemplateDB();
                if (dt.Rows.Count > 0)
                {
                    smsDB.Id = Id;
                    smsDB.TemplateName = Common.CNullToStr(dt.Rows[0]["TemplateName"]);
                    smsDB.TemplateContent = Common.CNullToStr(dt.Rows[0]["TemplateContent"]);

                }
                return smsDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询短信模版信息失败！");
                return new SMSTemplateDB();
            }
        }

        /// <summary>
        /// 获取短信发送记录(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("SMSTemplate");
            try
            {
                dt = db.GetDataTable("select Id, TemplateName,TemplateContent from SMS_Template order by Id desc");
                return dt;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告:查询短信模版失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        public bool DelSMSTemp(string ID)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("delete SMS_Template where id = '" + ID + " '",
                    out ReturnValue);

                if (ReturnValue <= 0)
                {
                    throw new Exception("删除短信模版出错!");
                }
                return true;
            }
            catch
            {
                Common.ShowMsg("系统警告：删除短信模版信息失败！");
                return false;
            }
        }

        public SMSTemplateDB FindTemp(string ID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();

                dt = db.GetDataTable(@"select TemplateName,TemplateContent from SMS_Template where Id='" + ID + "';");

                SMSTemplateDB clsSMS = new SMSTemplateDB();
                if (dt.Rows.Count > 0)
                {
                    clsSMS.Id = ID;
                    clsSMS.TemplateContent = Common.CNullToStr(dt.Rows[0]["TemplateContent"]);
                    clsSMS.TemplateName = Common.CNullToStr(dt.Rows[0]["TemplateName"]);
                }
                return clsSMS;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询短信模版信息失败！");
                return new SMSTemplateDB();
            }
        }

        public bool UpdateTEmp(string TemplateName, string TemplateContent, string Id)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类

            try
            {
                int ReturnValue = 0;
                db.Transact(@"update SMS_Template set TemplateName = '" + TemplateName + "' , TemplateContent = '"
                    + TemplateContent + "' where Id = '" + Id + " '", out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("修改新闻信息出错!");
                else
                    return true;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：修改新闻信息失败!");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool AddTemp(string TemplateName, string TemplateContent)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact(@"insert into SMS_Template(TemplateName, TemplateContent) 
                values('" + TemplateName + "','" + TemplateContent + "')",
                        out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("新增短信模版数据出错!");
                else
                    return true;
            }
            catch
            {
                Common.ShowMsg("系统警告：新增短信模版数据失败，可能此短信模版数据已经存在！");
                return false;
            }
        }
    }
}
