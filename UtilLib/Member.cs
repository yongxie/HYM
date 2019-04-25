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
    /// 用户组数据表类(User)
    /// </summary>
    public class MemberDB
    {
        public string MemID;
        public string MemName;
        public string CardPwd;
        public string LevelID;
        public string CardId;
        public string Sex;
        public string Tel;
        public string Age;
        public string Job;
        public string Mobile;
        public double CardAccount;
        public int JiFen;
        public string Birthday;
        public string Addr;
        public string CreateDate;
        public int Status;
        public string Father;
        public string Identitycard;
        public string OpeningBank;
        public string AccountName;
        public string AccountNumber;
        public string District;
        public string Province;
        public string City;
    }

    /// <summary>
    /// 会员数据表操作类(Member)
    /// </summary>
    public class Member
    {
        public bool AddMember(string MemId ,string MemName, string CardId, string Sex, string age, string Job, string Tel, string Mobile,
            DateTime CreateDate, string Birthday, int Status, string Addr, string Identitycard, string OpeningBank,
            string AccountNumber, string AccountName, string ProvinceId, string CityId, string DistrictId, string Father)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from mem where CardId='"+CardId+"'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact(@"insert into mem(memid,memname,cardid,sex,age,job,tel,mobile,birthday,addr,createdate,status,father,Identitycard,OpeningBank,
                AccountNumber,AccountName,Province,City,District) 
                values('" +  MemId + "','" + MemName + "','" + CardId + "','" +  Sex + "','" + age + "','" + Job + "','" + Tel + "','"
                          + Mobile + "','" + Birthday + "','" + Addr + "','" + CreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Status + "','" + Father + "','" 
                          + Identitycard + "','" + OpeningBank + "','" + AccountNumber + "','" + AccountName + "','" + ProvinceId + "','" + CityId + "','" + DistrictId + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增用户数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：新增用户数据失败，此用户数据已经存在！");
                    return false;
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增用户数据失败，可能此用户数据已经存在！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool AddMemCard(string CardId, string Pwd, string CardLevel, int Status)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from mem_card where CardId='" + CardId + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact(@"insert into mem_card(cardid,pwd,account,cardlevel,jifen,status) 
                values('" + CardId + "','" + Pwd + "','0','" + CardLevel + "','0','" + Status + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增会员卡数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：新增会员卡数据失败，此会员卡数据已经存在！");
                    return false;
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增用户数据失败，可能此用户数据已经存在！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdateMember(string MemId,string MemName, string CardID, string Sex, string Age, string Job, string Tel, string Mobile, string Birthday, 
            string Addr,string Identitycard,string OpeningBank,
            string AccountNumber, string AccountName,string ProvinceId,string CityId,string DistrictId, int Status)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("update mem set memId = '" + MemId + "', memname='" + MemName + "',cardid='" + CardID + "',sex='" + Sex + "',age='" + Age + "',job='" + Job + "',tel='" + Tel + "',mobile='"
                    + Mobile + "',birthday='" + Birthday + "',addr='" + Addr + "',Identitycard='" + Identitycard + "',OpeningBank='" + OpeningBank
                    +  "',AccountNumber='" + AccountNumber + "',AccountName='" + AccountName + "',Province='" + ProvinceId
                    + "',City='" + CityId + "',District ='" + DistrictId

                    + "' ,status='" + Status + "' where cardid = '" + CardID + " '",// ,status='" + Status + 
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("更新用户数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：更新用户数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }
        public bool UpdateMemCard(string CardId, string Pwd, string CardLevel,  int Status)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("update mem_card set pwd='" + Pwd + "',cardlevel='" + CardLevel + "',status='" + Status  // CardId = '" + CardId + "'

                    + "' where cardid = '" + CardId + " '",// 
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("更新会员卡数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：更新会员卡数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }
        public bool DelMember(string CardID)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("delete mem where cardid = '" + CardID + " '",
                    out ReturnValue);

                if (ReturnValue <= 0)
                { 
                    throw new Exception("删除会员数据出错!");
                }  

                db.Transact("delete mem_card where cardid = '" + CardID + " '",
                    out ReturnValue);
                if (ReturnValue <= 0)
                {
                    throw new Exception("删除卡数据出错!");
                    
                }
                return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：删除会员数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据用户ID查询该用户信息
        /// </summary>
        /// <param name="MemID">用户ID</param>
        /// <returns>返回用名数据表类</returns>
        public MemberDB FindMemByMemId(string MemID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();
                //dt = db.GetDataTable("select * from mem where cardid='" + CardID + "'");
                dt = db.GetDataTable(@" select a.MemId,a.MemName,a.Addr,a.Age,a.Birthday,b.Account,b.pwd,
                                                            a.CardId,a.District,a.Father,a.Identitycard,a.Job,a.Mobile,a.Sex,a.Status,a.Tel,
                                                            a.OpeningBank,a.AccountName,a.AccountNumber,a.Province,a.City,a.District,
                                                            d.ProvinceName,e.CityName,f.DistrictName,c.LevelId,c.LevelName,g.UserName FatherName,a.CreateDate
                                                            from mem a,Mem_Card b,Mem_Card_Level c,
                                                            Sys_Area_Province d,Sys_Area_City e,Sys_Area_District f,Sys_User g
 
                                                            where a.CardId = b.CardId and b.CardLevel = c.LevelId and e.ProvinceID = d.ProvinceID and f.CityID = e.CityID
                                                            and a.District = f.DistrictID  and a.Father = g.UserId and  a.memid='" + MemID + "'");
                MemberDB memDB = new MemberDB();
                if (dt.Rows.Count > 0)
                {
                    memDB.CardId = Common.CNullToStr(dt.Rows[0]["CardID"]);
                    memDB.CardPwd = Common.CNullToStr(dt.Rows[0]["Pwd"]);
                    memDB.MemName = Common.CNullToStr(dt.Rows[0]["MemName"]);
                    memDB.LevelID = Common.CNullToStr(dt.Rows[0]["LevelID"]);
                    memDB.Status = Convert.ToInt32(Common.CNullToStr(dt.Rows[0]["Status"]));
                    memDB.Addr = Common.CNullToStr(dt.Rows[0]["Addr"]);
                    memDB.Birthday = Common.CNullToStr(dt.Rows[0]["Birthday"]);
                    memDB.MemID = Common.CNullToStr(dt.Rows[0]["MemID"]);
                    memDB.Mobile = Common.CNullToStr(dt.Rows[0]["Mobile"]);
                    memDB.Sex = Common.CNullToStr(dt.Rows[0]["Sex"]);
                    memDB.Tel = Common.CNullToStr(dt.Rows[0]["Tel"]);
                    memDB.Age = Common.CNullToStr(dt.Rows[0]["Age"]);
                    memDB.Job = Common.CNullToStr(dt.Rows[0]["Job"]);
                    memDB.AccountName = Common.CNullToStr(dt.Rows[0]["AccountName"]);
                    memDB.AccountNumber = Common.CNullToStr(dt.Rows[0]["AccountNumber"]);
                    memDB.City = Common.CNullToStr(dt.Rows[0]["City"]);
                    memDB.District = Common.CNullToStr(dt.Rows[0]["District"]);
                    memDB.Province = Common.CNullToStr(dt.Rows[0]["Province"]);
                    memDB.Father = Common.CNullToStr(dt.Rows[0]["FatherName"]);
                    memDB.Identitycard = Common.CNullToStr(dt.Rows[0]["Identitycard"]);
                    memDB.OpeningBank = Common.CNullToStr(dt.Rows[0]["OpeningBank"]);
                   // memDB.CardAccount = Common.CNullToStr(dt.Rows[0]["Account"]);

                }
                return memDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询用户信息失败！");
                //Common.ErrLog(exc.ToString());
                return new MemberDB();
            }
        }

        /// <summary>
        /// 根据会员卡号查询该用户信息
        /// </summary>
        /// <param name="CardID">会员卡号</param>
        /// <returns>返回用名数据表类</returns>
        public MemberDB FindMemByCardId(string CardID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();
                //dt = db.GetDataTable("select * from mem where cardid='" + CardID + "'");
                dt = db.GetDataTable(@" select a.MemId,a.MemName,a.Addr,a.Age,a.Birthday,b.Account,b.pwd,
                                                            a.CardId,a.District,a.Father,a.Identitycard,a.Job,a.Mobile,a.Sex,a.Status,a.Tel,
                                                            a.OpeningBank,a.AccountName,a.AccountNumber,a.Province,a.City,a.District,
                                                            d.ProvinceName,e.CityName,f.DistrictName,c.LevelId,c.LevelName,g.UserName FatherName,a.CreateDate
                                                            from mem a,Mem_Card b,Mem_Card_Level c,
                                                            Sys_Area_Province d,Sys_Area_City e,Sys_Area_District f,Sys_User g
 
                                                            where a.CardId = b.CardId and b.CardLevel = c.LevelId and e.ProvinceID = d.ProvinceID and f.CityID = e.CityID
                                                            and a.District = f.DistrictID  and a.Father = g.UserId and  a.cardid='" + CardID + "'");
                MemberDB memDB = new MemberDB();
                if (dt.Rows.Count > 0)
                {
                    memDB.CardId = Common.CNullToStr(dt.Rows[0]["CardID"]);
                    memDB.CardPwd = Common.CNullToStr(dt.Rows[0]["Pwd"]);
                    memDB.MemName = Common.CNullToStr(dt.Rows[0]["MemName"]);
                    memDB.LevelID = Common.CNullToStr(dt.Rows[0]["LevelID"]);
                    memDB.Status = Convert.ToInt32(Common.CNullToStr(dt.Rows[0]["Status"]));
                    memDB.Addr = Common.CNullToStr(dt.Rows[0]["Addr"]);
                    memDB.Birthday = Common.CNullToStr(dt.Rows[0]["Birthday"]);
                    memDB.MemID = Common.CNullToStr(dt.Rows[0]["MemID"]);
                    memDB.Mobile = Common.CNullToStr(dt.Rows[0]["Mobile"]);
                    memDB.Sex = Common.CNullToStr(dt.Rows[0]["Sex"]);
                    memDB.Tel = Common.CNullToStr(dt.Rows[0]["Tel"]);
                    memDB.Age = Common.CNullToStr(dt.Rows[0]["Age"]);
                    memDB.Job = Common.CNullToStr(dt.Rows[0]["Job"]);
                    memDB.AccountName = Common.CNullToStr(dt.Rows[0]["AccountName"]);
                    memDB.AccountNumber = Common.CNullToStr(dt.Rows[0]["AccountNumber"]);
                    memDB.City = Common.CNullToStr(dt.Rows[0]["City"]);
                    memDB.District = Common.CNullToStr(dt.Rows[0]["District"]);
                    memDB.Province = Common.CNullToStr(dt.Rows[0]["Province"]);
                    memDB.Father = Common.CNullToStr(dt.Rows[0]["FatherName"]);
                    memDB.Identitycard = Common.CNullToStr(dt.Rows[0]["Identitycard"]);
                    memDB.OpeningBank = Common.CNullToStr(dt.Rows[0]["OpeningBank"]);
                    // memDB.CardAccount = Common.CNullToStr(dt.Rows[0]["Account"]);

                }
                return memDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询用户信息失败！");
                //Common.ErrLog(exc.ToString());
                return new MemberDB();
            }
        }

        /// <summary>
        /// 更新账户余额
        /// </summary>
        /// <param name="CardID">卡号</param>
        /// <param name="Money">金额（正数）</param>
        /// <param name="DoWhat">充值/消费</param>
        /// <param name="Msg">返回消息</param>
        /// <returns></returns>
        public bool UpdateMoney(string CardID, double Money, string DoWhat, out string Msg)
        {
            Msg = "执行成功！";
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                DataTable dt = new DataTable();
                dt = db.GetDataTable("select * from mem_card where cardid='" + CardID + "'");
                if (dt.Rows.Count <= 0)
                {
                    Msg = "卡号不存在";
                    return false;
                }
                double m = 0.00;
                if (!Double.TryParse(dt.Rows[0]["Account"].ToString().Trim(), out m))
                {
                    Msg = "账户数据错误";
                    return false;
                }
                if (DoWhat == "充值")
                {
                    m += Money;
                    Msg = "操作成功！当前账户余额：" + m.ToString("0.00");
                }
                else if (DoWhat == "消费")
                {
                    m -= Money;
                    Msg = "操作成功！当前账户余额：" + m.ToString("0.00");
                    if (m < 0)
                    {
                        Msg = "余额不足";
                        return false;
                    }
                }



                db.Transact("update mem_card set Account='" + m.ToString("0.00") + "' where cardid = '" + CardID + " '",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("更新用户数据出错!");
                else

                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：更新用户数据信息失败！");
                //Common.ErrLog(exc.ToString());
                Msg = "执行失败！";
                return false;
            }
        }

        public DataTable GetMemberLevelView()
        {
            DataTable dt = new DataTable();
            DBManager db = DBManager.Instance();
            try
            {
                dt = db.GetDataTable("select * from Mem_Card_Level where enbled = '1'");
            }
            catch(Exception)
            {}
            return dt;
        }

        public DataTable GetProvinceView()
        {
            DataTable dt = new DataTable();
            DBManager db = DBManager.Instance();
            try
            {
                dt = db.GetDataTable("select * from Sys_Area_Province order by provinceid");
            }
            catch (Exception)
            { }
            return dt;
        }

        public DataTable GetDistrictView(string CityId)
        {
            DataTable dt = new DataTable();
            DBManager db = DBManager.Instance();
            try
            {
                dt = db.GetDataTable("select * from Sys_Area_District where cityid = '" + CityId +"'  order by Districtid");
            }
            catch (Exception)
            { }
            return dt;
        }

        public DataTable GetCityView(string ProvinceId)
        {
            DataTable dt = new DataTable();
            DBManager db = DBManager.Instance();
            try
            {
                dt = db.GetDataTable("select * from Sys_Area_City where provinceid = '" + ProvinceId + "' order  by Cityid");
            }
            catch (Exception)
            { }
            return dt;
        }

    }
}
