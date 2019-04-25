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
    public partial class System_News_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0608");
                if (clsRighter.Read)
                {
                    string strSql = "select userid,username from Sys_User";
                    DBManager db = DBManager.Instance();
                    DataTable dt1 = db.GetDataTable(strSql);

                    DataRow df = dt1.NewRow();
                    df["UserName"] = "---请选择---";
                    dt1.Rows.InsertAt(df, 0);
                    ddlUserID.DataSource = dt1;
                    ddlUserID.DataTextField = "UserName";
                    ddlUserID.DataValueField = "UserId";
                    ddlUserID.DataBind();

                    BindDataGrid();

                    int icount = this.MyDataGrid.Columns.Count;
                    if (!clsRighter.Add)
                    {
                        this.btnAdd.Visible = false;
                    }
                    if (!clsRighter.Modify)
                    {
                        this.MyDataGrid.Columns[icount - 2].Visible = false;
                    }
                    if (!clsRighter.Delete)
                    {
                        this.MyDataGrid.Columns[icount - 1].Visible = false;
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
            //创建操作员记录数据表类实例
            NewsOperate news = new NewsOperate();
            //获取记录数据
            DataTable dt = news.Bind();
            DataView dv = new DataView();
            dt.TableName = "News";
            if (dt != null)
            {
                dv.Table = dt;
                dv.Sort = " SendTime DESC";

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
                ShowStats();							//显示页数信息
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
            string UserId = ddlUserID.SelectedValue;
            string Condition = " 1=1 ";
            if (UserId != null && UserId != "---请选择---" && UserId != "")
                Condition += " AND UserId='" + UserId + "'";
            if (this.txtTitle.Text.Trim() != "")
            {
                Condition += " AND NewsName like '%" + this.txtTitle.Text.Trim() + "%'";
            }

            if (this.txtCount.Text.Trim() != "")
            {
                Condition += " and NewsContent like '%" + this.txtCount.Text.Trim() + "%'";
            }

            ViewState["Condition"] = Condition;
            BindDataGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Url = "System_News_Edit.aspx?NewsID=";
            Server.Transfer(Url);
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

        protected void MyDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //创建用户数据表操作类对象
                NewsOperate news = new NewsOperate();
                string newsid = ((Label)e.Item.Cells[1].Controls[1]).Text;
                //删除用户数据
                if (news.DelNews(newsid))
                {
                    Common.ShowMsg("删除成功！");
                    string newsname = ((Label)e.Item.Cells[2].Controls[1]).Text;
                    string subNewName = newsname;
                    //记录操作员操作
                    if (newsname.Length > 16)
                        subNewName = newsname.Substring(0, 16) + "...";
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "删除新闻信息：" + subNewName);
                }
                Server.Transfer("System_News_View.aspx");
            }
            else
            {
                string Url = "System_News_Edit.aspx?NewsID=" + ((Label)e.Item.Cells[1].Controls[1]).Text;
                Server.Transfer(Url);
            }
        }
    }
}