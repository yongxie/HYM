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
    /// 用户组权限数据表类(GroupAuthorization)
    /// </summary>
    public class GroupAuthorizationDB
    {
        public string GroupID;
        public string GroupName;
        public string Authorization;
    }

    /// <summary>
    /// 用户组权限数据表操作类（GroupAuthorization)
    /// </summary>
    public class GroupAuthorization
    {
        /// <summary>
        /// 获取绑定数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetGroupName()
        {
            DBManager db = DBManager.Instance();

            DataTable dt = new DataTable("GroupAuthorization");
            try
            {
                dt = db.GetDataTable("select groupid,groupname from Auth_group");
                if (dt == null) throw new Exception("查询绑定数据出错!");
                return dt;
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告：查询绑定数据出错!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取绑定数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetGroName()
        {
            DBManager db = DBManager.Instance();

            DataTable dt = new DataTable("GroupAuthorization");
            try
            {
                dt = db.GetDataTable("select groupid,groupname from auth_group");
                if (dt == null) throw new Exception("查询绑定数据出错!");
                return dt;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询绑定数据出错!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
        }

        /// <summary>
        /// 根据用户组名查询该用户组权限信息
        /// </summary>
        /// <param name="GroupID">用户组名</param>
        /// <returns>返回用户权限数据表类</returns>
        public GroupAuthorizationDB FindGroup(string GroupID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            DataTable dt = new DataTable();
            

            try
            {
                dt = db.GetDataTable("select * from auth_group where groupid = '" + GroupID + "'");
                GroupAuthorizationDB clsGroupDB = new GroupAuthorizationDB();
                if (dt.Rows.Count > 0)
                {
                    clsGroupDB.GroupID = GroupID;
                    clsGroupDB.GroupName = Common.CNullToStr(dt.Rows[0]["GroupName"]);
                }
                return clsGroupDB;
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告：查询用户组权限信息出错!" + exc);
                //Common.ErrLog(exc.ToString());
                return new GroupAuthorizationDB();
            }
            finally
            {

            }
        }

        /// <summary>
        /// 获取用户组在所有程序模块中的权限
        /// </summary>
        /// <param name="GroupID">用户组ID</param>
        /// <returns>返回用户组在程序模块中的权限，返回用字符串数组表示
        /// String[N,0]为 程序模块ID(ProgramID)
        /// String[N,1]为 程序模块名(ProgramName)
        /// String[N,2]为 权限(读取修改新增删除RMAD)
        ///</returns>
        public String[,] ShowGroupRightInPrograms(String GroupID)
        {
            //DBManager db = DBManager.Instance();	//通用数据操作类
            string conStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            DataTable dt = new DataTable();
            String[,] strProgram = new String[80, 3];   //注：最大80个程序模块


            try
            {
                SqlCommand cmd = new SqlCommand("HYM_System_GroupAuthorization_ShowAllRightInProc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@groupid", SqlDbType.NVarChar, 20);
                p1.SqlValue = GroupID;
                p1.Direction = ParameterDirection.Input;

                SqlParameter p5 = new SqlParameter("@retResult", SqlDbType.NVarChar, 100);
                p5.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(p1);


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                //data.RunProc("Wygl_System_GroupAuthorization_ShowAllRightInProc", prams, out dataReader);
                int intRow = 0, intCol;
                DataRow[] dRows = dt.Select(""); 
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    intCol = 0;
                    strProgram[intRow, intCol] = Common.CNullToStr(dt.Rows[i][0]);
                    strProgram[intRow, ++intCol] = Common.CNullToStr(dt.Rows[i][1]);
                    strProgram[intRow, ++intCol] = Common.CNullToStr(dt.Rows[i][2]);
                    intRow++;
                }
                if (intRow == 0)
                    return null;
                else
                    return strProgram;
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告：查询用户组权限信息出错!");
                //Common.ErrLog(exc.ToString());
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 更新用户组信息
        /// </summary>
        /// <param name="GroupID">用户组ID</param>
        /// <param name="GroupName">用户组名称</param>
        /// <param name="Authorization">用户组权限</param>
        public void UpdateGroup(string GroupID, string GroupName, string Authorization)
        {
            DBManager db = DBManager.Instance();//通用数据操作类			
            
            try
            {
                int ReturnValue = -1;
                db.Transact("update auth_group set groupname = '" + GroupName + "' ,auth = '" + Authorization + "' where groupid = '" + GroupID + "'",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("修改用户组信息出错!");
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：修改用户组信息出错!");
                //Common.ErrLog(exc.ToString());
            }
        }

        /// <summary>
        /// 新增用户组权限方法
        /// </summary>
        /// <param name="GroupID">用户组ID</param>
        /// <param name="GroupName">用户组名称</param>
        /// <param name="Authorization">用户组权限列表</param>
        public void AddGroup(string GroupID, string GroupName, string Authorization)
        {
            DBManager db = DBManager.Instance();//通用数据操作类			
            
            try
            {
                string sql = db.GetValue("select COUNT(*) from auth_group where GroupID='" + GroupID + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact("insert into auth_group (groupid,groupname,auth)  values('" + GroupID + "','" + GroupName + "' ,'" + Authorization + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增用户组数据出错!");
                }
                else
                {
                    Common.ShowMsg("系统警告：新增用户组数据失败，此用户组数据已经存在！");
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增用户组数据失败，可能此用户组数据已经存在！");
                //Common.ErrLog(exc.ToString());
            }
        }

        /// <summary>
        /// 删除用户组信息
        /// </summary>
        /// <param name="GroupID">用户组ID</param>
        public void DeleteGroup(String GroupID)
        {
           DBManager db = DBManager.Instance();//通用数据操作类			
            
            try
            {
                if (GroupID == "1" || GroupID == "2" || GroupID == "3")
                {
                    Common.ShowMsg("系统警告：此用户组为系统固定用户组，禁止删除！");
                    return;
                }
                string sql = db.GetValue("select COUNT(*) from Sys_User where GroupID='" + GroupID + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact("delete auth_group where groupid = '" + GroupID + "'",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("删除用户组信息出错!");
                }
                else
                {
                    Common.ShowMsg("系统警告：删除用户组数据失败，此用户组下存在用户！");
                }
            }
            catch(Exception exc)
            {
                Common.ShowMsg("系统警告：删除用户组信息出错，可能此用户组已经被删除!");
                //Common.ErrLog(exc.ToString());
            }
        }

        ///// <summary>
        ///// 新增会员方法
        ///// </summary>
        ///// <param name="GroupID">用户组ID</param>
        ///// <param name="GroupName">用户组名称</param>
        ///// <param name="Authorization">用户组权限列表</param>
        //public void AddUser(string GroupID, string GroupName, string Authorization)
        //{
        //    DBManager db = DBManager.Instance();//通用数据操作类			

        //    try
        //    {
        //        int ReturnValue = -1;
        //        db.Transact("insert into acc_user (groupid,groupname,auth)  values('" + GroupID + "','" + GroupName + "' ,'" + Authorization + "')",
        //            out ReturnValue);
        //        if (ReturnValue <= 0) throw new Exception("新增用户组数据出错!");
        //    }
        //    catch//(Exception exc)
        //    {
        //        Common.ShowMsg("系统警告：新增用户组数据失败，可能此用户组数据已经存在！");
        //        //Common.ErrLog(exc.ToString());
        //    }
        //}
    }
}
