using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace Web.main_system.program
{
    public partial class Sys_EditPassward : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0607");
                if (clsRighter.Read)
                {
                    this.lblUserId.Text = Session["UserID"].ToString();
                }
                else
                {
                    Common.ShowMsg("权限不足！");
                }
                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string txtOldPwd = this.txtOldPwd.Text.ToString();
            string txtNewPwd = this.txtNewPwd.Text.ToString();

            OperatorAuthorization clsUser = new OperatorAuthorization();
            UserAuthorizationDB clsUserDB = clsUser.FindUser(Session["UserID"].ToString());

            if (txtOldPwd != clsUserDB.Pwd)
            {
                Common.ShowMsg("原密码输入错误！");
            }
            else if (clsUser.UpdatePwd(Session["UserID"].ToString(),txtNewPwd))
            {
                Common.ShowMsg("密码修改成功！");
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统管理", "成功修改密码");
            }
        }
    }
}