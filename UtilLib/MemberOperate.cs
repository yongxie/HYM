using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DBUtil;

namespace UtilLib
{
    public class MemberOperate
    {
        /// <summary>
        /// 用于显示代理商名称(用于DataGrid绑定)
        /// </summary>
        public DataTable GetMemName()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable(" select MemId,MemName from mem ");
                return dt;
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告:查询代理商名称失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }
        public DataTable GetLevelIDByMemId(string MemId)
        {
            DataTable dt = new DataTable();
            DBManager db = DBManager.Instance();
            try
            {
                dt = db.GetDataTable("select c.LevelId,c.LevelName from mem a,Mem_Card b,Mem_Card_Level c where a.CardId = b.CardId and b.CardLevel = c.LevelId and a.memid ='" + MemId + "'");
                return dt;
            }
            catch (Exception ex)
            {
                Common.ShowMsg("系统警告:获取级别ID失败!");
                return null;
            }
        }
        /// <summary>
        /// 获取会员信息(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind(string UserId)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("MemOperate");
            try
            {
//                dt = db.GetDataTable(@" select child.UserId,child.CardId,child.username,child.Age,child.Sex,child.Account,child.CreateDate, child.father,parent.UserName as FatherName 
//                                        FROM Acc_User child left join Acc_User parent  on parent.UserId=child.father  where  child.GroupId > 2");
                string strSql = "";
                if (UserId != "")
                {
//                    strSql = @" select a.MemId,a.MemName,a.Addr,a.Age,a.Birthday,b.Account,
//                                                            a.CardId,a.District,a.Father,a.Identitycard,a.Job,a.Mobile,a.Sex,a.Status,a.Tel,
//                                                            a.OpeningBank,a.AccountName,a.AccountNumber,a.Province,a.City,a.District,
//                                                            d.ProvinceName,e.CityName,f.DistrictName,c.LevelId,c.LevelName,
//                                                             g.UserName FatherName,a.CreateDate
//                                                            from mem a,Mem_Card b,Mem_Card_Level c,
//                                                            Sys_Area_Province d,Sys_Area_City e,Sys_Area_District f,Sys_User g
// 
//                                                            where a.CardId = b.CardId and b.CardLevel = c.LevelId and e.ProvinceID = d.ProvinceID and f.CityID = e.CityID
//                                                            and a.District = f.DistrictID and g.UserId = a.Father and userid = '" + UserId + "'";
                    strSql = @"with subqry(UserId,UserName,Father) as (select UserId,UserName,Father from Sys_User where
UserId='" + UserId + @"' union all select Sys_User.UserId,Sys_User.UserName, Sys_User.Father from Sys_User,subqry where Sys_User.Father = subqry.UserId) 


 select a.MemId,a.MemName,a.Addr,a.Age,a.Birthday,b.Account,
                                                            a.CardId,a.District,a.Father,a.Identitycard,a.Job,a.Mobile,a.Sex,Status=CASE a.Status WHEN 0 THEN '禁用' WHEN 1 THEN '激活' end,a.Tel,
                                                            a.OpeningBank,a.AccountName,a.AccountNumber,a.Province,a.City,a.District,
                                                            d.ProvinceName,e.CityName,f.DistrictName,c.LevelId,c.LevelName,
                                                             g.UserName FatherName,a.CreateDate
                                                            
from mem a,Mem_Card b,Mem_Card_Level c,
                                                            Sys_Area_Province d,Sys_Area_City e,Sys_Area_District f,subqry g
 
                                                            where a.CardId = b.CardId and b.CardLevel = c.LevelId and e.ProvinceID = d.ProvinceID and f.CityID = e.CityID
                                                            and a.District = f.DistrictID and g.UserId = a.Father order by a.CreateDate";
                }
                else
                {
                    strSql = @" select a.MemId,a.MemName,a.Addr,a.Age,a.Birthday,b.Account,
                                                            a.CardId,a.District,a.Father,a.Identitycard,a.Job,a.Mobile,a.Sex,Status=CASE a.Status WHEN 0 THEN '禁用' WHEN 1 THEN '激活' end,
                                                            a.Tel,
                                                            a.OpeningBank,a.AccountName,a.AccountNumber,a.Province,a.City,a.District,
                                                            d.ProvinceName,e.CityName,f.DistrictName,c.LevelId,c.LevelName,
                                                             g.UserName FatherName,a.CreateDate
                                                            from mem a,Mem_Card b,Mem_Card_Level c,
                                                            Sys_Area_Province d,Sys_Area_City e,Sys_Area_District f,Sys_User g
 
                                                            where a.CardId = b.CardId and b.CardLevel = c.LevelId and e.ProvinceID = d.ProvinceID and f.CityID = e.CityID
                                                            and a.District = f.DistrictID and g.UserId = a.Father order by a.CreateDate";
                }
                dt = db.GetDataTable(strSql);
                return dt;
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告:查询会员信息失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }
    }
}
