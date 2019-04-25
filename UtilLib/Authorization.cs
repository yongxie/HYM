using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DBUtil;
using System.Data;

namespace UtilLib
{
    /// <summary>
    /// 用户权限类 的摘要说明。
    /// </summary>
    public class Authorization
    {
        private HttpContext context;
        //读权限变量
        private bool blnRead = false;
        //修改权限变量
        private bool blnModify = false;
        //新增权限变量
        private bool blnAdd = false;
        //删除权限变量
        private bool blnDelete = false;
        //小区代码
        //private string BasePrecinct = "";
        private string ProgramID = "";
        //private string PrecinctID = "";
        /// <summary>
        /// 自定义Authorization构造方法，初始化引入参数
        /// </summary>
        /// <param name="UserID">用户代码</param>
        /// <param name="PrecinctID">小区ID</param>
        /// <param name="ProgramID">项目程序ID</param>
        public Authorization(string strProgramID)
        {
            ProgramID = strProgramID;
            //PrecinctID = strPrecinctID;
            context = HttpContext.Current;
            if (context.Session["UserID"] == null || context.Session["UserID"].ToString() == "")
            {
                string Url = "/Default.aspx";
                context.Response.Write("<script language=javascript>alert('系统提示：您没有访问权限或登录超时，请重新登录！');</script>");
                context.Response.Write("<script languaer=javascript>top.window.navigate('" + Url + "');</script>");
            }
            else
                GetRight();
        }

        public Authorization()
        {
            context = HttpContext.Current;
            if (context.Session["UserID"] == null || context.Session["UserID"].ToString() == "")
            {
                string Url = "/Default.aspx";
                context.Response.Write("<script language=javascript>alert('系统提示：您没有访问权限或登录超时，请重新登录！');</script>");
                context.Response.Write("<script languaer=javascript>top.window.navigate('" + Url + "');</script>");
            }
            else
            {
                //DBManager db = DBManager.Instance();
                //object strPrecinct;
                //SqlParameter[] prams = { data.MakeInParam("@UserID", SqlDbType.VarChar, 20, context.Session["Wygl_UserID"].ToString()) };
                //try
                //{
                //    data.RunProc("Wygl_System_UserAuthorization_FindUserPrecinct", prams, out strPrecinct);
                //    if (strPrecinct != DBNull.Value && strPrecinct != null)
                //        BasePrecinct = (String)strPrecinct;
                //    else
                //    {
                //        Common.PopMsg("系统警告：对不起，您还没有获得至少一个小区的使用权限！");	//向用户弹出出错信息						
                //        string Url = context.Request.ApplicationPath + "/index.aspx";
                //        context.Response.Write("<script languaer=javascript>top.window.navigate('" + Url + "');</script>");
                //    }
                //}
                //catch//(Exception exc)
                //{
                //    Common.ShowMsg("系统警告：查询小区权限出错");
                //    //Common.ErrLog(exc.ToString());					//将详细出错信息记录到系统信息里
                //}
            }
        }

        /// <summary>
        /// 获得用户权限方法
        /// </summary>
        /// <returns>返回当前用户的权限字符串，字符串是“rmad"的组合,如果用户不存在，返回为"null"</returns>
        private void GetRight()
        {
            DBManager db = DBManager.Instance();

            DataTable dt = new DataTable();

            dt = db.GetDataTable("select a.auth from auth_group a,Sys_User b where a.groupid = b.groupid and b.userid = '" + context.Session["UserID"].ToString() + "'");

            string[] strTmpRight;
            string strRight = "";
            

            try
            {
                //data.RunProc("Wygl_System_UserAuthorization_ShowRightInProc", prams, out strTmpRight);
                if(dt.Rows.Count > 0)
                {
                    strTmpRight = dt.Rows[0][0].ToString().Split('/');
                    for (int i = 0; i < strTmpRight.Length; i++)
                    {
                        if (strTmpRight[i].Contains(this.ProgramID))
                        {
                            strRight = strTmpRight[i];
                            break;
                        }
                    }
                }

                if (strRight != "")
                {
                    //strRight = (String)strTmpRight;
                    if (strRight.IndexOf('r') != -1) blnRead = true;
                    if (strRight.IndexOf('m') != -1) blnModify = true;
                    if (strRight.IndexOf('a') != -1) blnAdd = true;
                    if (strRight.IndexOf('d') != -1) blnDelete = true;
                }
                if (!blnRead)
                {
                    Common.ShowMsg("系统警告：对不起！当前页面您没有访问的权限!");
                    context = HttpContext.Current;
                    //string Url = context.Request.UrlReferrer.LocalPath;
                    string Url = context.Request.ApplicationPath + "include/main.aspx";
                    context.Response.Write("<script languaer=javascript>top.main.navigate('" + Url + "');</script>");
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：查询用户权限出错！");
                //Common.ErrLog(exc.ToString());
            }

        }

        /// <summary>
        /// 读权限属性
        /// </summary>
        public bool Read
        {
            get { return blnRead; }
        }

        /// <summary>
        /// 修改权限属性
        /// </summary>
        public bool Modify
        {
            get { return blnModify; }
        }

        /// <summary>
        /// 新增权限属性
        /// </summary>
        public bool Add
        {
            get { return blnAdd; }
        }

        /// <summary>
        /// 删除权限属性
        /// </summary>
        public bool Delete
        {
            get { return blnDelete; }
        }
    }
}
