using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;

namespace Web.main_system.program
{
    public partial class System_MemCardExpendRecord_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtBeginDate.Text = DateTime.Now.AddDays(-7).Date.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0103");
                if (clsRighter.Read)
                {

                    //创建操作员记录数据表类实例
                    //MemCarsLevelOperate clsRecord = new MemCarsLevelOperate();
                    ////获取记录数据
                    //DataTable dt1 = clsRecord.ShowName();
                    //DataRow df = dt1.NewRow();
                    //df["MemId"] = "---请选择---";
                    //dt1.Rows.InsertAt(df, 0);
                    //ddlUserID.DataSource = dt1;
                    //ddlUserID.DataTextField = "MemId";
                    //ddlUserID.DataValueField = "MemId";
                    //ddlUserID.DataBind();
                    BindDataGrid();
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
            //获取记录数据
            DataTable dt = new DataTable();
            if (Session["UserGroupID"].ToString() == "2" || Session["UserGroupID"].ToString() == "3")
            {
                dt = clsRecord.Bind(Convert.ToDateTime(this.txtBeginDate.Text.Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndDate.Text.Trim()).AddDays(1).ToShortDateString(), Session["UserID"].ToString());
            }
            else
            {
                dt = clsRecord.Bind(Convert.ToDateTime(this.txtBeginDate.Text.Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndDate.Text.Trim()).AddDays(1).ToShortDateString(), "");
                
            }
            DataView dv = new DataView();
            dt.TableName = "Mem_Log";
            if (dt != null)
            {
                dv.Table = dt;
                dv.Sort = " operatetime DESC";

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

        ///// <summary>
        /////  翻页LinkButton公用事件方法
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Link_Click(object sender, System.EventArgs e)
        //{
        //    String arg = (((LinkButton)sender).CommandArgument);
        //    switch (arg)
        //    {
        //        case ("Next"):		//下一页
        //            if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
        //                MyDataGrid.CurrentPageIndex++;
        //            break;
        //        case ("Previous"):	//上一页
        //            if (MyDataGrid.CurrentPageIndex > 0)
        //                MyDataGrid.CurrentPageIndex--;
        //            break;
        //        case ("Last"):		//尾页
        //            MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
        //            break;
        //        default:			//首页
        //            //本页值
        //            MyDataGrid.CurrentPageIndex = 0;
        //            break;
        //    }
        //    BindDataGrid();			//重新绑定数据到DataGrid
        //}

        ///// <summary>
        ///// 分页下拉菜单选择事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ddlCurrentPage_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    int intCurrentPage = int.Parse(ddlCurrentPage.SelectedItem.Value);
        //    if (intCurrentPage < MyDataGrid.PageCount)
        //    {
        //        MyDataGrid.CurrentPageIndex = intCurrentPage;
        //    }
        //    BindDataGrid();			//重新绑定数据到DataGrid
        //}

        #endregion

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

        protected void btnCha_Click(object sender, EventArgs e)
        {
            string CardID = this.txtCardID.Text.Trim();
            string Condition = " 1=1 ";
            if (CardID != null && CardID != "")
                Condition += " AND CardId like '%" + CardID + "%'";
            //			if(txtProgramName.Text.Trim()!="")
            //				Condition += " AND ModuleName = '" + txtProgramName.Text + "'";
            if (this.txtBeginDate.Text.Trim() != "")
                Condition += " AND operatetime>='" + Common.CStrToDate(txtBeginDate.Text).ToShortDateString();

            Condition += "' AND operatetime <'" + Common.CStrToDate(txtEndDate.Text).AddDays(1).ToShortDateString() + "'";

            ViewState["Condition"] = Condition;
            BindDataGrid();	
        }
    }
}