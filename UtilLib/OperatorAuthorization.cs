//--------------------------------------------------------
//程序功能：用户权限数据表类与用户权限数据表操作类
//最后修改时间： 
//--------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using DBUtil;

namespace UtilLib
{
    /// <summary>
    /// 用户权限数据表类(UserAuthorization)
    /// </summary>
    public class UserAuthorizationDB
    {
        public string UserID;
        public string UserName;
        public string Pwd;
        public string GroupID;
        public string Authorization;

        public string Mobile;
        public string Sex;
        public string Tel;
        public string Age;
        public string Job;

        public string Birthday;
        public string Addr;
        public string CreateDate;
        public string Status;
        public string Father;
        public string HaveSon;

        //附加信息变量定义
        public string GroupName;
        public string EmployeeName;
    }

    public class OperatorAuthorization
    {
        /// <summary>
        /// 获取系统用户列表数据
        /// </summary>
        /// <returns></returns>
        public DataTable BindData()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("UserAuthorization");
            try
            {
                dt = db.GetDataTable("select a.UserId, a.UserName, a.Pwd, a.Sex, a.Tel, a.Age, a.Job, a.Mobile, a.Birthday, a.Addr, a.CreateDate, a.Status ,Father=CASE a.Father WHEN '0' THEN '无' WHEN a.Father THEN a.Father end, b.groupid,b.groupname from Sys_User a , auth_group b where a.groupid = b.groupid;");
                if (dt == null) throw new Exception("查询系统用户列表数据出错!");
                return dt;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询系统用户列表数据失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 根据操作员ID查询该用户权限信息
        /// </summary>
        /// <param name="UserID">会员卡号</param>
        /// <returns>返回用名权限数据表类</returns>
        public UserAuthorizationDB FindUser(string UserID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();

                dt = db.GetDataTable(@"select a.UserId, a.UserName, a.Pwd, a.Sex, a.Tel, a.Age, a.Job, a.Mobile, a.Birthday, a.Addr, a.CreateDate, a.Status ,a.Father,b.groupid,b.groupname 
                                                               FROM Auth_Group b,Sys_User a where a.GroupId = b.GroupId and a.UserId='" + UserID + "';");

                UserAuthorizationDB clsUser = new UserAuthorizationDB();
                if (dt.Rows.Count > 0)
                {
                    clsUser.UserID = UserID;
                    clsUser.Pwd = Common.CNullToStr(dt.Rows[0]["Pwd"]);
                    clsUser.UserName = Common.CNullToStr(dt.Rows[0]["UserName"]);
                    clsUser.GroupID = Common.CNullToStr(dt.Rows[0]["GroupID"]);
                    clsUser.GroupName = Common.CNullToStr(dt.Rows[0]["GroupName"]);
                    clsUser.Sex = Common.CNullToStr(dt.Rows[0]["Sex"]);
                    clsUser.Tel = Common.CNullToStr(dt.Rows[0]["Tel"]);
                    clsUser.Age = Common.CNullToStr(dt.Rows[0]["Age"]);
                    clsUser.Job = Common.CNullToStr(dt.Rows[0]["Job"]);
                    clsUser.Mobile = Common.CNullToStr(dt.Rows[0]["Mobile"]);
                    clsUser.Birthday = Common.CNullToStr(dt.Rows[0]["Birthday"]);
                    clsUser.Addr = Common.CNullToStr(dt.Rows[0]["Addr"]);
                    clsUser.CreateDate = Common.CNullToStr(dt.Rows[0]["CreateDate"]);
                    clsUser.Status = Common.CNullToStr(dt.Rows[0]["Status"]);
                    clsUser.Father = Common.CNullToStr(dt.Rows[0]["Father"]);
                }
                return clsUser;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询用户权限信息失败！");
                //Common.ErrLog(exc.ToString());
                return new UserAuthorizationDB();
            }

        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="Password">用户密码</param>
        /// <param name="EmployeeID">姓名</param>
        /// <param name="GroupID">用户所属组ID</param>
        public bool UpdateUser(string UserID, string Password, string UserName, string GroupID, string Sex, string Tel, string Age, string Job, string Mobile, string Birthday, string Addr, string Status, string Father)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类

            try
            {
                int ReturnValue = 0;
                db.Transact(@"update Sys_User set pwd = '" + Password + "' , userName = '"
                    + UserName + "' , groupid = '" + GroupID + "', Sex = '" + Sex + "', Tel = '"
                    + Tel + "', Age = '" + Age + "', Job = '" + Job + "', Mobile = '"
                    + Mobile + "', Birthday = '" + Birthday + "', Addr = '" + Addr + "', Status = '"
                    + Status + "', CreateDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', Father = '" + Father + "' where userid = '" + UserID + " '", out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("修改系统用户权限信息出错!");
                else
                    return true;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：修改系统用户权限信息失败!");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdatePwd(string UserID, string Password)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类

            try
            {
                int ReturnValue = 0;
                db.Transact(@"update Sys_User set pwd = '" + Password + "' where userid = '" + UserID + " '", out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("修改用户密码信息出错!");
                else
                    return true;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：修改用户密码信息失败!");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool AddUser(string UserID, string Password, string UserName, string GroupID, string Sex, string Tel, string Age, string Job, string Mobile, string Birthday, string Addr, string Status, string Father)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from Sys_User where UserId='" + UserID + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact(@"insert into Sys_User(UserId, Pwd, UserName, GroupId, Sex, Tel, Age, Job, Mobile, Birthday, Addr, CreateDate, Status,Father) 
                values('" + UserID + "','" + Password + "','" + UserName + "','" + GroupID + "','" + Sex + "','" + Tel + "','" + Age + "','" + Job + "','" + Mobile + "','" + Birthday + "','" + Addr + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Status + "','" + Father + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增用户信息数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：新增用户信息数据失败，此用户信息数据已经存在！");
                    return false;
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增用户信息数据失败，可能此用户信息数据已经存在！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool DelOperater(string UserID)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                if (UserID == "admin")
                {
                    Common.ShowMsg("系统警告：禁止删除此管理员账号！");
                    return false;
                }
                int ReturnValue = -1;
                db.Transact("delete Sys_User where userid = '" + UserID + " '",
                    out ReturnValue);

                if (ReturnValue <= 0)
                {
                    throw new Exception("删除用户信息数据出错!");
                }
                return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：删除用户信息数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        /// <summary>
        /// 获取系统用户列表数据
        /// </summary>
        /// <returns></returns>
        public DataTable BindNodes(string Id)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("UserAuthorization");
            try
            {
                if (Id == "0")
                {
                    dt = db.GetDataTable("select a.UserId, a.UserName, a.Pwd, a.Sex, a.Tel, a.Age, a.Job, a.Mobile, a.Birthday, a.Addr, a.CreateDate, a.Status, Father=CASE a.Father WHEN '0' THEN '无' WHEN a.Father THEN a.Father end,b.groupid,b.groupname from Sys_User a , auth_group b where a.groupid = b.groupid;");
                }
                else
                {
                    dt = db.GetDataTable(@"with subqry(UserId,UserName,Father) as (select UserId,UserName,Father from Sys_User where 
UserId='" + Id + "' union all select Sys_User.UserId,Sys_User.UserName,Sys_User.Father from Sys_User,subqry where Sys_User.Father = subqry.UserId) select Sys_User.UserId, Sys_User.UserName, Sys_User.Pwd, Sys_User.Sex, Sys_User.Tel, Sys_User.Age, Sys_User.Job, Sys_User.Mobile, Sys_User.Birthday, Sys_User.Addr, Sys_User.CreateDate, Sys_User.Status,Father=CASE Sys_User.Father WHEN '0' THEN '无' WHEN Sys_User.Father THEN Sys_User.Father end,auth_group.groupid,auth_group.groupname from subqry, Sys_User,auth_group where Sys_User.groupid = auth_group.groupid and Sys_User.UserId = subqry.UserId");
                }
                if (dt == null) throw new Exception("查询系统用户列表数据出错!");
                return dt;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询系统用户列表数据失败!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }
    }

}
