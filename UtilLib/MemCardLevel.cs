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
    /// 会员级别数据表类(MemCarsLevel)
    /// </summary>
    public class MemCardLevelDB
    {
        public string LevelID;
        public string LevelName;
        public int Enbled;
    }

    /// <summary>
    /// 会员级别数据表操作类(MemCarsLevel)
    /// </summary>
    public class MemCardLevel
    {
        /// <summary>
        /// 获取会员级别信息(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("MemCarsLevel");
            try
            {
                dt = db.GetDataTable(@" select * from Mem_Card_Level");
                return dt;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告:查询会员级别信息失败!");
                return null;
            }
        }

        /// <summary>
        /// 删除会员级别信息
        /// </summary>
        /// <param name="LevelId">会员级别ID</param>
        /// <returns></returns>
        public bool DelLevel(string LevelId)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {

                string sql = db.GetValue("select COUNT(*) from Mem_Card where CardLevel='" + LevelId + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact("delete Mem_Card_Level where LevelId = '" + LevelId + " '",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("删除会员级别数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：删除会员级别数据失败，此会员级别下面有会员存在！");
                    return false;
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：删除会员级别数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdateLevel(int LevelId, string LevelName, int Enbled)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("update Mem_Card_Level set LevelName='" + LevelName + "',Enbled='" + Enbled + "' where LevelId='" + LevelId + "'",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("更新会员级别数据出错!");
                else
                    return true;
            }
            catch
            {
                Common.ShowMsg("系统警告：更新会员级别数据信息失败！");
                return false;
            }
        }

        public bool AddLevel(string LevelName, int Enbled)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from Mem_Card_Level where LevelName='" + LevelName + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact(@"insert into Mem_Card_Level(LevelName,Enbled) 
                values('" + LevelName + "','" + Enbled + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增会员级别数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：新增会员级别数据失败，此会员级别数据已经存在！");
                    return false;
                }
            }
            catch
            {
                Common.ShowMsg("系统警告：新增会员级别数据失败，可能此会员级别数据已经存在！");
                return false;
            }
        }

        /// <summary>
        /// 根据会员级别查询该级别信息
        /// </summary>
        /// <param name="CardID">会员级别ID</param>
        /// <returns>返回会员级别数据表类</returns>
        public MemCardLevelDB FindLevel(string LevelId)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();
                dt = db.GetDataTable("select * from Mem_Card_Level where LevelId='" + LevelId + "'");
                MemCardLevelDB levelDB = new MemCardLevelDB();
                if (dt.Rows.Count > 0)
                {
                    levelDB.LevelID = LevelId;
                    levelDB.LevelName = Common.CNullToStr(dt.Rows[0]["LevelName"]);
                    levelDB.Enbled = Convert.ToInt32(Common.CNullToStr(dt.Rows[0]["Enbled"]));
                }
                return levelDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询会员级别信息失败！");
                Common.ErrLog(exc.ToString());
                return new MemCardLevelDB();
            }
        }
    }
}
