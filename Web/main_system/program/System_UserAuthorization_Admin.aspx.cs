using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;

namespace Web.main_system.program
{
    public partial class System_UserAuthorization_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0601");
                if (clsRighter.Read)
                {
                    this.btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                    if (Request.QueryString["UserID"] != null && Request.QueryString["UserID"].ToString() != "")
                    {
                        ViewState["UserID"] = Request.QueryString["UserID"].ToString();
                        FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件

                        ViewState["OperateStatus"] = "EditData";
                        //imgPopup.Visible = true;					//显示修改密码弹出对话框按钮
                        DisabledSuper((string)ViewState["UserID"]);
                    }
                    else
                    {
                        ViewState["UserID"] = "";
                        FillDataToCtrl(false);
                        ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作
                        //imgPopup.Visible = false;					//隐藏修改密码弹出对话框按钮					
                    }
                }
                else
                {
                    Common.ShowMsg("权限不足！");
                }
            }
        }
        /// <summary>
        /// 填充数据到表单文本控件,下拉框控件
        /// </summary>
        /// <param name="IsFill"></param>
        private void FillDataToCtrl(bool IsFill)
        {
            UserAuthorizationDB clsUserDB;		//创建用户权限表类对象
            GroupAuthorization clsGroupUser = new GroupAuthorization();	//创建用户组权限表操作类对象
            DataTable dt = clsGroupUser.GetGroName();
            //DataRow dr = dt.NewRow();
            //dr["GroupID"] = "";
            //dr["GroupName"] = "--请选择--";
            //dt.Rows.Add(dr);
            this.ddlGroupID.DataTextField = "GroupName";
            this.ddlGroupID.DataValueField = "GroupID";
            this.ddlGroupID.DataSource = dt.DefaultView;
            this.ddlGroupID.DataBind();

            string strSql = "select userid,username from Sys_User";
            DBManager db = DBManager.Instance();
            DataTable dt1 = db.GetDataTable(strSql);
            DataRow df = dt1.NewRow();
            df["UserName"] = "---请选择---";
            df["UserId"] = "0";
            dt1.Rows.InsertAt(df, 0);
            ddlFather.DataSource = dt1;
            ddlFather.DataTextField = "UserName";
            ddlFather.DataValueField = "UserId";
            ddlFather.DataBind();

            this.ddlSex.Items.Clear();
            //this.ddlSex.Items.Add("---请选择---");
            this.ddlSex.Items.Add("男");
            this.ddlSex.Items.Add("女");
            this.ddlSex.SelectedIndex = 0;

            this.ddlStatus.Items.Clear();
            this.ddlStatus.Items.Add("禁用");
            this.ddlStatus.Items.Add("激活");
            this.ddlStatus.SelectedIndex = 0;

            if (IsFill)
            {
                OperatorAuthorization clsUser = new OperatorAuthorization();
                clsUserDB = clsUser.FindUser((string)ViewState["UserID"]);
                this.txtUserID.Text = ViewState["UserID"].ToString();
                this.txtUserID.Enabled = false;

                txtPassword.Text = Common.CCToEmpty(clsUserDB.Pwd);
                txtUserName.Text = Common.CCToEmpty(clsUserDB.UserName);
                txtAge.Text = Common.CCToEmpty(clsUserDB.Age);
                txtBirthday.Text = Common.CCToEmpty(clsUserDB.Birthday);
                txtJob.Text = Common.CCToEmpty(clsUserDB.Job);
                txtMobile.Text = Common.CCToEmpty(clsUserDB.Mobile);
                txtAddr.Text = Common.CCToEmpty(clsUserDB.Addr);
                txtTel.Text = Common.CCToEmpty(clsUserDB.Tel);
                if (clsUserDB.Sex.Trim() == "男")
                {
                    ddlSex.SelectedIndex = 0;
                }
                else if (clsUserDB.Sex.Trim() == "女")
                {
                    ddlSex.SelectedIndex = 1;
                }

                if (clsUserDB.Status.ToString() == "0")
                {
                    ddlStatus.SelectedIndex = 0;
                }
                else if (clsUserDB.Status.ToString() == "1")
                {
                    ddlStatus.SelectedIndex = 1;
                }

                for (int i = 0; i < ddlGroupID.Items.Count; i++)
                {
                    if (this.ddlGroupID.Items[i].Value == clsUserDB.GroupID)
                    {
                        ddlGroupID.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < ddlFather.Items.Count; i++)
                {
                    if (this.ddlFather.Items[i].Value == clsUserDB.Father)
                    {
                        ddlFather.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                clsUserDB = new UserAuthorizationDB();
                this.txtUserID.Text = "";
                this.txtUserID.Enabled = true;
            }

        }

        /// <summary>
        /// 对于用户为超级用户的，只能修改密码
        /// </summary>
        private void DisabledSuper(string strUser)
        {
            if (strUser.ToUpper() == "ADMIN")
            {

                ddlGroupID.Enabled = false;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户权限数据表操作类对象
                OperatorAuthorization clsUser = new OperatorAuthorization();

                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    UserAuthorizationDB clsUserDB = clsUser.FindUser((string)ViewState["UserID"]);
                    string userid = this.txtUserID.Text.Trim();
                    string pwd = this.txtPassword.Text.Trim();
                    string username = this.txtUserName.Text.Trim();
                    string groupid = this.ddlGroupID.Items.Count > 0 ? ddlGroupID.SelectedItem.Value : "";
                    string Sex = this.ddlSex.Items.Count > 0 ? ddlSex.SelectedItem.Value : "";
                    string Tel = this.txtTel.Text.Trim();
                    string Age = this.txtAge.Text.Trim();
                    string Job = this.txtJob.Text.Trim();
                    string Mobile = this.txtMobile.Text.Trim();
                    string Birthday = this.txtBirthday.Text.Trim();
                    string Addr = this.txtAddr.Text.Trim();
                    string Status = this.ddlStatus.SelectedIndex.ToString();
                    string Father = this.ddlFather.SelectedItem.Value;
                    //增加用户数据

                    if (clsUser.AddUser(userid, pwd, username, groupid, Sex, Tel, Age, Job, Mobile, Birthday, Addr, Status,Father))
                    {
                        Common.ShowMsg("添加成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "权限设置", "增加用户权限信息;卡号：" + (string)ViewState["UserID"]);

                    }
                    else
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    UserAuthorizationDB clsUserDB = clsUser.FindUser((string)ViewState["UserID"]);
                    string userid = ViewState["UserID"].ToString();
                    string pwd = Common.CCToEmpty(clsUserDB.Pwd);
                    string username = this.txtUserName.Text.Trim();
                    string groupid = this.ddlGroupID.Items.Count > 0 ? ddlGroupID.SelectedItem.Value : "";
                    string Sex = this.ddlSex.Items.Count > 0 ? ddlSex.SelectedItem.Value : "";
                    string Tel = this.txtTel.Text.Trim();
                    string Age = this.txtAge.Text.Trim();
                    string Job = this.txtJob.Text.Trim();
                    string Mobile = this.txtMobile.Text.Trim();
                    string Birthday = this.txtBirthday.Text.Trim();
                    string Addr = this.txtAddr.Text.Trim();
                    string Status = this.ddlStatus.SelectedIndex.ToString();
                    string Father = this.ddlFather.SelectedItem.Value;
                    //更新用户数据
                    if (clsUser.UpdateUser(userid,pwd,username,groupid,Sex,Tel,Age,Job,Mobile,Birthday,Addr,Status,Father))
                    {
                        Common.ShowMsg("更新成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "权限设置", "修改用户权限信息;用户ID：" + (string)ViewState["UserID"]);
                    }
                }
            }
            Server.Transfer("System_UserAuthorization_Index.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_UserAuthorization_Index.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            OperatorAuthorization operauth = new OperatorAuthorization();
            string userid = this.txtUserID.Text.Trim();
            //删除用户数据
            if (operauth.DelOperater(userid))
            {
                Common.ShowMsg("删除成功！");
                //记录操作员操作
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统管理", "删除用户信息");
            }
            else
            {
                return;
            }
            Server.Transfer("System_UserAuthorization_Index.aspx");
        }

    }
}