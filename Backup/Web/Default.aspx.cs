using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtil;
using System.Data;
using UtilLib;
//using System.Data.Sql;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Login_Click(object sender, ImageClickEventArgs e)
        {
            string strName = this.txtUserName.Text.Trim();
            string strPwd = this.txtPwd.Text.Trim();
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            dt = db.GetDataTable("select * from Sys_User where userid = '" + strName + "' and pwd ='" + strPwd + "' and status = '1'");
            if (dt.Rows.Count > 0)
            {
                Session["UserID"] = strName;
                Session["UserGroupID"] = dt.Rows[0]["GroupId"].ToString().Trim();
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "用户登陆", "用户成功登陆系统");
                Response.Redirect("index.aspx");

            }
            else
            {
                Common.ShowMsg("用户名密码错误或者状态未激活！");
            }
        }

        protected void btn_Rest_Click(object sender, ImageClickEventArgs e)
        {
            this.txtUserName.Text = "";
            this.txtPwd.Text = "";
            this.input1.Value = "";
        }

    }
}