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
    public partial class System_QuestionFB_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0609");
                btnAdd.Enabled = clsRighter.Modify | clsRighter.Add;
                if (clsRighter.Read)
                {
                    //创建操作员记录数据表类实例
                    QuestionOperate question = new QuestionOperate();
                    //获取记录数据
                    DataTable dt = question.ShowQuestion();
                    DataRow df = dt.NewRow();
                    df["UserName"] = "---请选择---";
                    dt.Rows.InsertAt(df, 0);
                    ddlQues.DataSource = dt;
                    ddlQues.DataTextField = "UserName";
                    ddlQues.DataValueField = "UserId";
                    ddlQues.DataBind();

                    //控制前台的“编辑”“回复”的显示方式
                    //DBManager db = DBManager.Instance();//通用数据操作类
                    //string sql = db.GetValue("select GroupId from Sys_User where UserId='" + Session["UserID"].ToString() + "'").ToString();
                    //int count = int.Parse(sql);
                    ButtonColumn sel = (ButtonColumn)GoodsDataGrid.Columns[8];
                    EditCommandColumn edit = (EditCommandColumn)GoodsDataGrid.Columns[6];
                    if (Session["UserGroupID"].ToString() != "2" && Session["UserGroupID"].ToString() != "3")
                    {
                        sel.Visible = true;
                        edit.Visible = false;
                        this.btnAdd.Visible = false;
                    }
                    else
                    {
                        sel.Visible = false;
                        edit.Visible = true;
                        this.btnAdd.Visible = true;
                        ddlQues.SelectedValue = Session["UserID"].ToString();
                        ddlQues.Enabled = false;
                    }

                    BindDataGrid();


                    int icount = this.GoodsDataGrid.Columns.Count;
                    if (!clsRighter.Add)
                    {
                        this.btnAdd.Visible = false;
                    }
                    //if (!clsRighter.Modify)
                    //{
                    //    this.GoodsDataGrid.Columns[icount - 2].Visible = false;
                    //}
                    if (!clsRighter.Delete)
                    {
                        this.GoodsDataGrid.Columns[icount - 2].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定数据到DataGrid控件GoodsDataGrid上
        /// </summary>		
        private void BindDataGrid()
        {
            //创建操作员记录数据表类实例
            QuestionOperate question = new QuestionOperate();
            //获取记录数据
            DataTable dt = question.Bind(Session["UserGroupID"].ToString(), Session["UserID"].ToString());
            DataView dv = new DataView();
            dt.TableName = "Questions";
            if (dt != null)
            {
                dv.Table = dt;
                dv.Sort = " QuestionTime DESC";

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
                GoodsDataGrid.DataSource = dv;
                int PageCount = 0;
                if (intCountRecNum % GoodsDataGrid.PageSize == 0)
                    PageCount = intCountRecNum / GoodsDataGrid.PageSize;
                else
                    PageCount = intCountRecNum / GoodsDataGrid.PageSize + 1;

                if (PageCount != 0 && GoodsDataGrid.CurrentPageIndex >= PageCount)
                    GoodsDataGrid.CurrentPageIndex = PageCount - 1;

                GoodsDataGrid.DataBind();
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
            int intCurrentPage = (int)GoodsDataGrid.CurrentPageIndex;
            //显示当前页数
            lblCurrentPage.Text = Convert.ToString(intCurrentPage + 1);	//显示当前页数
            lblTotalPage.Text = GoodsDataGrid.PageCount.ToString();		//显示总页数
            //绑定页数到下拉框
            this.ddlCurrentPage.Items.Clear();
            for (int i = 0; i < GoodsDataGrid.PageCount; i++)
                this.ddlCurrentPage.Items.Add(new ListItem(Convert.ToString(i + 1), i.ToString()));
            this.ddlCurrentPage.SelectedIndex = intCurrentPage;			//指定当前页

            if (GoodsDataGrid.PageCount > 1)
            {
                //控制链接按钮显示状态
                if (GoodsDataGrid.CurrentPageIndex == (GoodsDataGrid.PageCount - 1))
                {
                    this.lnkFirst.Visible = true;
                    this.lnkPrevious.Visible = true;
                    this.lnkNext.Visible = false;
                    this.lnkLast.Visible = false;
                }
                else if (GoodsDataGrid.CurrentPageIndex == 0)
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
            string Question = ddlQues.SelectedItem.Value;
            string Condition = " 1=1 ";
            if (Question != null && Question != "---请选择---" && Question != "")
                Condition += " AND Qer='" + Question + "'";

            if (this.txtQuesTitle.Text.Trim() != "")
            {
                Condition += " AND QAName like '%" + this.txtQuesTitle.Text.Trim() + "%'";
            }
            if (this.txtQuesContent.Text.Trim() != "")
            {
                Condition += " and Question like '%" + this.txtQuesContent.Text.Trim() + "%'";
            }

            ViewState["Condition"] = Condition;
            BindDataGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Url = "System_QuestionFB_Edit.aspx?ID=";
            Server.Transfer(Url);
        }

        protected void ddlCurrentPage_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int intCurrentPage = int.Parse(ddlCurrentPage.SelectedItem.Value);
            if (intCurrentPage < GoodsDataGrid.PageCount)
            {
                GoodsDataGrid.CurrentPageIndex = intCurrentPage;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            String arg = (((LinkButton)sender).CommandArgument);
            switch (arg)
            {
                case ("Next"):		//下一页
                    if (GoodsDataGrid.CurrentPageIndex < (GoodsDataGrid.PageCount - 1))
                        GoodsDataGrid.CurrentPageIndex++;
                    break;
                case ("Previous"):	//上一页
                    if (GoodsDataGrid.CurrentPageIndex > 0)
                        GoodsDataGrid.CurrentPageIndex--;
                    break;
                case ("Last"):		//尾页
                    GoodsDataGrid.CurrentPageIndex = (GoodsDataGrid.PageCount - 1);
                    break;
                default:			//首页
                    //本页值
                    GoodsDataGrid.CurrentPageIndex = 0;
                    break;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void GoodsDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //创建用户数据表操作类对象
                QuestionOperate question = new QuestionOperate();
                string Id = ((Label)e.Item.Cells[1].Controls[1]).Text;
                //删除用户数据
                if (question.DelQues(Id))
                {
                    Common.ShowMsg("删除成功！");
                    string newsname = ((Label)e.Item.Cells[2].Controls[1]).Text;
                    string subNewName = newsname;
                    //记录操作员操作
                    if (newsname.Length > 16)
                        subNewName = newsname.Substring(0, 16) + "...";
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "删除问题反馈信息：" + subNewName);

                }
                Server.Transfer("System_QuestionFB_View.aspx");
            }
            else if (e.CommandName == "Select")
            {
                string Url = "System_QuestionFB_Reply.aspx?Id=" + ((Label)e.Item.Cells[1].Controls[1]).Text;
                Server.Transfer(Url);
            }
            else
            {
                string Url = "System_QuestionFB_Edit.aspx?Id=" + ((Label)e.Item.Cells[1].Controls[1]).Text;
                Server.Transfer(Url);
            }
        }
    }
}