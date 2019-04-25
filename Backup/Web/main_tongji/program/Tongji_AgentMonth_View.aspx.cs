using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;

namespace Web.main_tongji.program
{
    public partial class Tongji_Agent_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtBeginDate.Text = DateTime.Now.AddDays(-30).Date.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0402");
                //DBManager db = DBManager.Instance();
                //string sql = db.GetValue("select GroupId from Sys_User where UserId='" + Session["UserId"].ToString() + "'").ToString();
                //int count = int.Parse(sql);
                if (clsRighter.Read)
                {

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
                    DBManager db = DBManager.Instance();
                    DataTable dt1 = db.GetDataTable(strSql);
                    DataRow df = dt1.NewRow();
                    df["UserName"] = "---请选择---";
                    dt1.Rows.InsertAt(df, 0);
                    ddlUserName.DataSource = dt1;
                    ddlUserName.DataTextField = "UserName";
                    ddlUserName.DataValueField = "UserId";
                    ddlUserName.DataBind();
                    //if (Session["UserGroupID"].ToString() != "1")
                    //{
                    //    ddlUserID.SelectedValue = Session["UserID"].ToString();
                    //    ddlUserID.Enabled = false;
                    //}
                    //string Condition = " 1=1 ";
                    //DateTime StartDate = DateTime.Now.Date.AddDays(-30);
                    //DateTime EndDate = DateTime.Now.Date.AddDays(1);
                    //DateTime.TryParse(this.txtBeginDate.Text.Trim(), out StartDate);
                    //DateTime.TryParse(this.txtEndDate.Text.Trim().Trim(), out EndDate);
                    //if (StartDate > EndDate)
                    //{
                    //    Common.ShowMsg("起始日期不能大于结束日期！");
                    //    return;
                    //}
                    //else
                    //{
                    //    Condition += " and OperateTime >= '" + StartDate.ToString() + "' and OperateTime < '" + EndDate.ToString() + "'";
                    //}
                    //ViewState["Condition"] = Condition;
                    BindDataGrid();

                    /////////////////////////////////////
                    //    //创建操作员记录数据表类实例
                    //    MemCarsLevelOperate clsRecord = new MemCarsLevelOperate();
                    //    //获取记录数据
                    //    DataTable dt1 = clsRecord.ShowName();
                    //    DataRow df = dt1.NewRow();
                    //    df["UserName"] = "---请选择---";
                    //    dt1.Rows.InsertAt(df, 0);
                    //    ddlUserName.DataSource = dt1;
                    //    ddlUserName.DataTextField = "UserName";
                    //    ddlUserName.DataValueField = "UserId";
                    //    ddlUserName.DataBind();

                    //    //this.tdShow1.Width = "57%";
                    //    //this.tdShow2.Width = "42%";

                    //BindDataGrid();
                }
                else
                {
                    Common.ShowMsg("权限不足！");
                }
            }
        }

        /// <summary>
        /// 绑定数据到DataGrid控件MyDataGrid上
        /// </summary>		
        private void BindDataGrid()
        {
            //创建操作员记录数据表类实例
            MemCardLevelOperate clsRecord = new MemCardLevelOperate();
            DataTable dt = new DataTable();
            //获取记录数据
            //if (Session["UserGroupID"].ToString() != "1")
            //{
            //    dt = clsRecord.BindAgent(Convert.ToDateTime(this.txtBeginDate.Text.Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndDate.Text.Trim()).AddDays(1).ToShortDateString(), Session["UserGroupId"].ToString(), Session["UserId"].ToString()); 
            //}
            //else
            //{
            //    dt = clsRecord.BindAgent(Convert.ToDateTime(this.txtBeginDate.Text.Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndDate.Text.Trim()).AddDays(1).ToShortDateString(),, Session["UserId"].ToString()""); 
            //}
            dt = clsRecord.BindAgent(Convert.ToDateTime(this.txtBeginDate.Text.Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndDate.Text.Trim()).AddDays(1).ToShortDateString(), Session["UserGroupId"].ToString(), Session["UserId"].ToString()); 

            //获取记录数据
            //DataTable dt = clsRecord.BindAgent(Convert.ToDateTime(this.txtBeginDate.Text.Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndDate.Text.Trim()).AddDays(1).ToShortDateString(),Session["UserId"].ToString());
            DataView dv = new DataView();
            dt.TableName = "Mem_Log";
            if (dt != null)
            {
                dv.Table = dt;

                if (ViewState["Condition"] != null && ViewState["Condition"].ToString() != "")
                    dv.RowFilter = ViewState["Condition"].ToString();
                else
                    dv = dt.DefaultView;

                //新增ID自增值列绑定
                dt.Columns.Add(new DataColumn("idno", Type.GetType("System.Int32")));
                int intCountRecNum = dv.Count;	//获取数据表记录数

                //double totalAccount = 0.00;
                double totalZongXiaofei = 0.00;
                double totalZongChongzhi = 0.00;

                for (int i = 0; i < intCountRecNum; i++)
                {
                    dv[i]["idno"] = i + 1;

                    //totalAccount += Convert.ToDouble(dv[i]["Account"]);
                    totalZongXiaofei += Convert.ToDouble(dv[i]["ZongXiaofei"]);
                    totalZongChongzhi += Convert.ToDouble(dv[i]["ZongCongzhi"]);
                }


                MyDataGrid.DataSource = dv;

                this.lbTotalXiaofei.Text = totalZongXiaofei.ToString();
                this.lbTotalChongzhi.Text = totalZongChongzhi.ToString();


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

        protected void btnCha_Click(object sender, EventArgs e)
        {
            string UserId = this.txtUserId.Text.Trim();
            string UserName = ddlUserName.SelectedItem.Value;
            string Condition = " 1=1 ";
            if (UserId != null && UserId != "")
                Condition += " AND UserId like '%" + UserId + "%'";

            if (UserName != null && UserName != "")
                Condition += " AND UserId like '%" + UserName + "%'";

            //if (this.txtBeginDate.Text.Trim() != "")
            //    Condition += " AND OperateTime>='" + Common.CStrToDate(txtBeginDate.Text).ToShortDateString();

            //Condition += "' AND OperateTime <'" + Common.CStrToDate(txtEndDate.Text).AddDays(1).ToShortDateString() + "'";

            ViewState["Condition"] = Condition;
            BindDataGrid();	
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
    }
}