using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;

namespace Web.main_membermanager.program
{
    public partial class MemManager_View : System.Web.UI.Page
    {
        //private HttpContext context;
        private string strAgentID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0202");
                if (clsRighter.Read)
                {
                    if (Request.QueryString["AgentID"] != null && Request.QueryString["AgentID"].ToString() != "")
                    {
                        if (Request.QueryString["AgentID"].ToString() != null && Request.QueryString["AgentID"].ToString() != "---请选择---" && Request.QueryString["AgentID"].ToString() != "")
                        {
                            strAgentID = Request.QueryString["AgentID"].ToString();
                        }
                    }

                    //Response.Write(Session.Timeout);
                    //context = HttpContext.Current;
                    //context.Response.Write("<script language=javascript>alert('" + Session.Timeout + "分钟后超时！');</script>");
                    //创建操作员记录数据表类实例
                    //MemberOperate clsMem = new MemberOperate();
                    //获取记录数据
                    string strSql = "";
                    if (Session["UserGroupID"].ToString() != "2" && Session["UserGroupID"].ToString() != "3")
                    {
                        strSql = "select userid,username from Sys_User";
                    }
                    else
                    {
                        strSql = @"with subqry(UserId,UserName,Father) as (select UserId,UserName,Father from Sys_User where
                                        UserId='" + Session["UserID"].ToString() + @"' union all select Sys_User.UserId,Sys_User.UserName, Sys_User.Father from Sys_User,subqry
                                        where Sys_User.Father = subqry.UserId) select * from subqry";
                    }
                    //DataTable dt1 = clsMem.GetMemName();
                    DBManager db = DBManager.Instance();
                    DataTable dt1 = db.GetDataTable(strSql);

                    DataRow df = dt1.NewRow();
                    df["UserName"] = "---请选择---";
                    dt1.Rows.InsertAt(df, 0);
                    ddlMemID.DataSource = dt1;
                    ddlMemID.DataTextField = "UserName";
                    ddlMemID.DataValueField = "UserId";
                    ddlMemID.DataBind();

                    if (strAgentID != "")
                    {
                        ddlMemID.SelectedValue = strAgentID;
                    }
                    //if (Session["UserGroupID"].ToString() != "1")
                    //{
                    //    ddlMemID.SelectedValue = Session["UserID"].ToString();
                    //    ddlMemID.Enabled = false;
                    //}
                    BindDataGrid();
                    int icount = this.MyDataGrid.Columns.Count;
                    if (!clsRighter.Add)
                    {
                        this.btnAdd.Visible = false;
                    }
                    if (!clsRighter.Modify)
                    {
                        this.MyDataGrid.Columns[icount -2].Visible = false;
                    }
                    if (!clsRighter.Delete)
                    {
                        this.MyDataGrid.Columns[icount -1].Visible = false;
                    }
                }
                else
                {
                    this.btnCha.Enabled = false;
                    Common.ShowMsg("权限不足！");
                }
            }
        }

        /// <summary>
        /// 绑定数据到DataGrid控件MyDataGrid上
        /// </summary>		
        private void BindDataGrid()
        {
            string MemID = ddlMemID.SelectedItem.Value;
            string Condition = " 1=1 ";
            if (MemID != null && MemID != "---请选择---" && MemID != "")
                Condition += " AND father='" + MemID + "'";
            //			if(txtProgramName.Text.Trim()!="")
            //				Condition += " AND ModuleName = '" + txtProgramName.Text + "'";
            if (this.txtCardId.Text.Trim() != "")
            {
                Condition += " AND cardid like '%" + this.txtCardId.Text.Trim() + "%'";
            }

            if (this.txtMemName.Text.Trim() != "")
            {
                Condition += " and memname like '%" + this.txtMemName.Text.Trim() + "%'";
            }

            ViewState["Condition"] = Condition;

            //创建操作员记录数据表类实例
            MemberOperate clsMem = new MemberOperate();
            //获取记录数据
            DataTable dt = new DataTable();
            if (Session["UserGroupID"].ToString() == "2" || Session["UserGroupID"].ToString() == "3")
            {
                dt = clsMem.Bind(Session["UserID"].ToString());
            }
            else
            {
                dt = clsMem.Bind("");
            }
             
            DataView dv = new DataView();
            dt.TableName = "Mem";
            if (dt != null)
            {
                dv.Table = dt;
                dv.Sort = " father DESC";

                if (ViewState["Condition"] != null && ViewState["Condition"].ToString() != "")
                    dv.RowFilter = ViewState["Condition"].ToString();
                else
                    dv = dt.DefaultView;

                //新增ID自增值列绑定
                dt.Columns.Add(new DataColumn("idno", Type.GetType("System.Int32")));
                int intCountRecNum = dv.Count;	//获取数据表记录数
                for (int i = 0; i < intCountRecNum; i++)
                {
                    dv[i]["idno"] = i + 1;
                }
                MyDataGrid.DataSource = dv;
                int PageCount = 0;
                if (intCountRecNum % MyDataGrid.PageSize == 0)
                    PageCount = intCountRecNum / MyDataGrid.PageSize;
                else
                    PageCount = intCountRecNum / MyDataGrid.PageSize + 1;

                if (PageCount != 0 && MyDataGrid.CurrentPageIndex >= PageCount)
                    MyDataGrid.CurrentPageIndex = PageCount - 1;

                MyDataGrid.DataBind();
                lblRecNum.Text = intCountRecNum.ToString();	//显示总记录数
                ShowStats();								//显示页数信息
            }
        }

        #region 控制分页显示状态
        /// <summary>
        /// 显示页面页数信息
        /// </summary>
        private void ShowStats()
        {
            int intCurrentPage = (int)MyDataGrid.CurrentPageIndex;
            //显示当前页数
            lblCurrentPage.Text = Convert.ToString(intCurrentPage + 1);	//显示当前页数
            lblTotalPage.Text = MyDataGrid.PageCount.ToString();		//显示总页数
            //绑定页数到下拉框
            this.ddlCurrentPage.Items.Clear();
            for (int i = 0; i < MyDataGrid.PageCount; i++)
                this.ddlCurrentPage.Items.Add(new ListItem(Convert.ToString(i + 1), i.ToString()));
            this.ddlCurrentPage.SelectedIndex = intCurrentPage;			//指定当前页

            if (MyDataGrid.PageCount > 1)
            {
                //控制链接按钮显示状态
                if (MyDataGrid.CurrentPageIndex == (MyDataGrid.PageCount - 1))
                {
                    this.lnkFirst.Visible = true;
                    this.lnkPrevious.Visible = true;
                    this.lnkNext.Visible = false;
                    this.lnkLast.Visible = false;
                }
                else if (MyDataGrid.CurrentPageIndex == 0)
                {
                    this.lnkFirst.Visible = false;
                    this.lnkPrevious.Visible = false;
                    this.lnkNext.Visible = true;
                    this.lnkLast.Visible = true;
                }
                else
                {
                    this.lnkFirst.Visible = true;
                    this.lnkPrevious.Visible = true;
                    this.lnkNext.Visible = true;
                    this.lnkLast.Visible = true;
                }
            }
            else
            {
                this.lnkNext.Visible = false;
                this.lnkLast.Visible = false;
                this.lnkFirst.Visible = false;
                this.lnkPrevious.Visible = false;
            }
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string Url = "MemManager_Edit.aspx?CardID=";
            Server.Transfer(Url);
        }

        protected void MyDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //创建用户数据表操作类对象
                Member user = new Member();
                string cardid = ((Label)e.Item.Cells[1].Controls[1]).Text;
                //删除用户数据
                if (user.DelMember(cardid))
                {
                    Common.ShowMsg("删除成功！");
                    //记录操作员操作
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "删除会员信息");
                }
                Server.Transfer("MemManager_View.aspx?AgentID=" + ddlMemID.SelectedValue);
            }
            else
            {
                //string Url = "MemManager_Edit.aspx?GroupId=" + ((Label)e.Item.Cells[0].Controls[1]).Text;
                string Url = "MemManager_Edit.aspx?MemID=" + ((Label)e.Item.Cells[1].Controls[1]).Text +"&AgentID=" + ddlMemID.SelectedValue ;
                Server.Transfer(Url);
            }
        }

        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            String arg = (((LinkButton)sender).CommandArgument);
            switch (arg)
            {
                case ("Next"):		//下一页
                    if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
                        MyDataGrid.CurrentPageIndex++;
                    break;
                case ("Previous"):	//上一页
                    if (MyDataGrid.CurrentPageIndex > 0)
                        MyDataGrid.CurrentPageIndex--;
                    break;
                case ("Last"):		//尾页
                    MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
                    break;
                default:			//首页
                    //本页值
                    MyDataGrid.CurrentPageIndex = 0;
                    break;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void ddlCurrentPage_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int intCurrentPage = int.Parse(ddlCurrentPage.SelectedItem.Value);
            if (intCurrentPage < MyDataGrid.PageCount)
            {
                MyDataGrid.CurrentPageIndex = intCurrentPage;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void btnCha_Click(object sender, EventArgs e)
        {

            BindDataGrid();
        }
    }
}