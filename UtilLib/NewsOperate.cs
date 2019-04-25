using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DBUtil;
using System.Data.SqlClient;
using System.Configuration;

namespace UtilLib
{
    /// <summary>
    /// 新闻数据表类(User)
    /// </summary>
    public class NewsOperateDB
    {
        public string NewsId;
        public string NewsName;
        public string NewsContent;
        public DateTime SendTime;
        public string NewsType;
        public string ShowOnSys;
        public string Sender;
    }

    /// <summary>
    /// 新闻数据表操作类(Member)
    /// </summary>
    public class NewsOperate
    {
        /// <summary>
        /// 获取新闻信息(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("News");
            try
            {
                dt = db.GetDataTable(@"select a.NewsId, a.NewsName, Substring(a.NewsContent,0,30) as NewsContent, a.SendTime, a.NewsType, ShowOnSys=CASE ShowOnSys WHEN 0 THEN '是' WHEN 1 THEN '否' end, b.UserName,b.UserID  from Sys_News a,Sys_User b where a.Sender = b.UserId order by SendTime DESC");
                return dt;
            }
            catch
            {
                Common.ShowMsg("系统警告:查询新闻信息失败!");
                return null;
            }
        }

        public bool DelNews(string NewsID)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("delete Sys_News where newsid = '" + NewsID + " '",
                    out ReturnValue);

                if (ReturnValue <= 0)
                {
                    throw new Exception("删除新闻数据出错!");
                }
                return true;
            }
            catch
            {
                Common.ShowMsg("系统警告：删除新闻数据信息失败！");
                return false;
            }
        }

        /// <summary>
        /// 根据新闻ID查询该新闻信息
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public NewsOperateDB FindNews(string NewsID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();

                dt = db.GetDataTable(@"select NewsName, NewsContent, NewsType, ShowOnSys from Sys_News where NewsId='" + NewsID + "';");

                NewsOperateDB clsNews = new NewsOperateDB();
                if (dt.Rows.Count > 0)
                {
                    clsNews.NewsId = NewsID;
                    clsNews.NewsContent = Common.CNullToStr(dt.Rows[0]["NewsContent"]);
                    clsNews.NewsName = Common.CNullToStr(dt.Rows[0]["NewsName"]);
                    clsNews.NewsType = Common.CNullToStr(dt.Rows[0]["NewsType"]);
                    clsNews.ShowOnSys = Common.CNullToStr(dt.Rows[0]["ShowOnSys"]);
                }
                return clsNews;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询新闻信息失败！");
                //Common.ErrLog(exc.ToString());
                return new NewsOperateDB();
            }
        }

        public bool AddNews(string NewsName, string NewsCount, string NewsType, string ShowOnSys, string UserId)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact(@"insert into Sys_News(NewsName, NewsContent, SendTime, NewsType, ShowOnSys, Sender) 
                values('" + NewsName + "','" + NewsCount + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + NewsType + "','" + ShowOnSys + "','" + UserId + "')",
                        out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("新增新闻信息数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增新闻信息数据失败，可能此新闻信息数据已经存在！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdateNews(string NewsId,string NewsName, string NewsCount, string NewsType, string ShowOnSys,string UserId)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类

            try
            {
                int ReturnValue = 0;
                db.Transact(@"update Sys_News set NewsName = '" + NewsName + "' , NewsContent = '"
                    + NewsCount + "' , SendTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', NewsType = '" + NewsType + "', ShowOnSys = '"
                    + ShowOnSys + "', Sender = '" + UserId + "' where NewsId = '" + NewsId + " '", out ReturnValue);
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
    }
}
