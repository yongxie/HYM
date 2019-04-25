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
    /// 问题反馈数据表类(QuestionOperateDB)
    /// </summary>
    public class QuestionOperateDB
    {
        public string ID;
        public string QAName;
        public string Question;
        public string Anwser;
        public string QuestionIsNew;
        public string AnwserIsNew;
        public string Qer;
        public string Aer;
        public DateTime QuestionTime;
        public DateTime AnwserTime;
    }

    /// <summary>
    /// 问题反馈数据表操作类(QuestionOperate)
    /// </summary>
    public class QuestionOperate
    {
        /// <summary>
        /// 用于显示商品类别名称(用于DataGrid绑定)
        /// </summary>
        public DataTable ShowQuestion()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable(" select UserId,UserName from Sys_User where GroupId>1");
                return dt;
            }
            catch
            {
                Common.ShowMsg("系统警告:查询用户信息失败!");
                return null;
            }
        }

        /// <summary>
        /// 获取问题反馈信息(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind(string GroupId,string UserId)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("Questions");
            try
            {
                if (GroupId == "2" || GroupId == "3")
                {
                    dt = db.GetDataTable(@"select ID, QAName, Substring(Question,0,30) as Question, Qer, QuestionTime from Sys_QA where Qer = '" +UserId + "'");
                }
                else
                {
                    dt = db.GetDataTable(@"select ID, QAName, Substring(Question,0,30) as Question, Qer, QuestionTime from Sys_QA");
                }
                return dt;
            }
            catch
            {
                Common.ShowMsg("系统警告:查询问题反馈信息失败!");
                return null;
            }
        }

        public bool DelQues(string Id)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("delete Sys_QA where Id = '" + Id + " '",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("删除问题反馈数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：删除问题反馈数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据问题ID查询该问题信息
        /// </summary>
        /// <param name="ID">问题ID</param>
        /// <returns>返回问题反馈数据表类</returns>
        public QuestionOperateDB FindQues(string ID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();
                dt = db.GetDataTable("select * from Sys_QA where ID='" + ID + "'");
                QuestionOperateDB quesDB = new QuestionOperateDB();
                if (dt.Rows.Count > 0)
                {
                    quesDB.ID = ID;
                    quesDB.Aer = dt.Rows[0]["Aer"].ToString().Trim();
                    quesDB.Anwser = dt.Rows[0]["Anwser"].ToString().Trim();
                    quesDB.AnwserIsNew = dt.Rows[0]["AnwserIsNew"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["AnwserTime"].ToString().Trim()))
                    {
                        quesDB.AnwserTime = Convert.ToDateTime(dt.Rows[0]["AnwserTime"].ToString().Trim());
                    }
                    quesDB.QAName = dt.Rows[0]["QAName"].ToString().Trim();
                    quesDB.Qer = dt.Rows[0]["Qer"].ToString().Trim();
                    quesDB.Question = dt.Rows[0]["Question"].ToString().Trim();
                    quesDB.QuestionIsNew = dt.Rows[0]["QuestionIsNew"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["QuestionTime"].ToString().Trim()))
                    {
                        quesDB.QuestionTime = Convert.ToDateTime(dt.Rows[0]["QuestionTime"].ToString().Trim());
                    }
                }
                return quesDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询问题反馈信息失败！");
                return new QuestionOperateDB();
            }
        }

        public bool AddQues(string QAName, string Question, string Qer)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("insert into Sys_QA(QAName,Question,Qer,QuestionTime) values('" + QAName + "','" + Question + "','" + Qer + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"')",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("新增问题反馈数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增问题反馈数据失败，可能此数据已经存在！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdateQues(string Id, string QAName, string Question)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("update Sys_QA set QAName='" + QAName + "',Question='" + Question + "',QuestionTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'where ID = '" + Id + " '",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("更新问题反馈数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：更新问题反馈数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool ReplyQues(string Id, string Aer, string Anwser)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("update Sys_QA set Aer='" + Aer + "',Anwser='" + Anwser + "',AnwserTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'where ID = '" + Id + " '",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("回复问题反馈数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：回复问题反馈数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }
    }
}
