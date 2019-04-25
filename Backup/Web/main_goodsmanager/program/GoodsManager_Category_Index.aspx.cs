using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;
using System.Data.SqlClient;

namespace Web.main_charge.program
{
    public partial class GoodsManager_Category_Index : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                //程序模块权限验证
                Authorization clsRighter = new Authorization("0303");
                if (clsRighter.Read)
                {

                    //获取记录数据
                    BindDataGrid();

                    int icount = this.MyDataGrid.Columns.Count;
                    if (!clsRighter.Add)
                    {
                        this.MyDataGrid.Columns[icount - 3].Visible = false;
                        this.MyDataGrid.Columns[icount - 4].Visible = false;
                    }
                    if (!clsRighter.Modify)
                    {
                        this.MyDataGrid.Columns[icount - 2].Visible = false;
                    }
                    if (!clsRighter.Delete)
                    {
                        this.MyDataGrid.Columns[icount - 1].Visible = false;
                    }
                    ViewState["dtTemp"] = dtTemp;
                }
                else
                {
                    //this.btnCha.Enabled = false;
                    Common.ShowMsg("权限不足！");
                }
            }
        }
        private void InsertdtTemp(string fatherid,string nullStr)
        {
            DataRow[] dRows = dt.Select("fatherid = '" + fatherid+ "'");
            nullStr += "—";
            for (int i = 0; i < dRows.Length; i++)
            {
                dtTemp.Rows.Add(dRows[i]["GoodsCategoryId"],nullStr + dRows[i]["Description"].ToString() , dRows[i]["FatherId"]);
                InsertdtTemp(dRows[i]["GoodsCategoryId"].ToString(), nullStr);
            }
        }
        /// <summary>
        /// 绑定数据到DataGrid控件MyDataGrid上
        /// </summary>		
        private void BindDataGrid()
        {
            //创建操作员记录数据表类实例
            GoodsCategory clsGood = new GoodsCategory();
            //获取记录数据
            dt = clsGood.Bind();

            dtTemp.TableName = "GoodsCategory";
            if (dt != null)
            {
                dtTemp.Rows.Clear();
                dtTemp.Columns.Add("GoodsCategoryId");
                dtTemp.Columns.Add("Description");
                dtTemp.Columns.Add("FatherId");
                DataRow[] dRows = dt.Select("fatherid = '0'");
                for (int i = 0; i < dRows.Length; i++)
                {
                    dtTemp.Rows.Add(dRows[i]["GoodsCategoryId"], dRows[i]["Description"], dRows[i]["FatherId"]);
                    InsertdtTemp(dRows[i]["GoodsCategoryId"].ToString(), "—");
                }



                DataView dv = new DataView();
                dv.Table = dtTemp;
                //dv.Sort = " GoodsCategoryId DESC";

                if (ViewState["Condition"] != null && ViewState["Condition"].ToString() != "")
                    dv.RowFilter = ViewState["Condition"].ToString();
                else
                    dv = dtTemp.DefaultView;

                //新增ID自增值列绑定
                dtTemp.Columns.Add(new DataColumn("idno", Type.GetType("System.Int32")));
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

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    string Url = "GoodsManager_Category_Add.aspx?GoodsCategoryId=";
        //    Server.Transfer(Url);
        //}

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

        protected void MyDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            //创建会员级别数据表操作类对象
           DataTable  dtFather =  ViewState["dtTemp"] as DataTable;
            GoodsCategory goods = new GoodsCategory();
            string goodsCategoryId = ((Label)e.Item.Cells[1].Controls[1]).Text;
            if (e.CommandName == "Delete")
            {
                //删除会员级别数据
                if (goods.DelCate(goodsCategoryId))
                {
                    Common.ShowMsg("删除成功！");
                    //记录操作员操作
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "删除商品分类信息");
                }
                Server.Transfer("GoodsManager_Category_Index.aspx");
            }
            else if (e.CommandName == "AddBrother")
            {
                string fatherid = dtFather.Select("goodsCategoryId = '" + goodsCategoryId + "'")[0]["fatherid"].ToString();
                string Url = "GoodsManager_Category_Add.aspx?GoodsFatherCategoryId=" + fatherid + "&GoodsCategoryId=" + goodsCategoryId + "&Operate=AddBrother";
                Server.Transfer(Url);
            }
            else if (e.CommandName == "Edit")
            {
                string fatherid = dtFather.Select("goodsCategoryId = '" + goodsCategoryId + "'")[0]["fatherid"].ToString();
                string Url = "GoodsManager_Category_Add.aspx?GoodsFatherCategoryId=" + fatherid + "&GoodsCategoryId=" + goodsCategoryId +"&Operate=Edit";
                Server.Transfer(Url);
            }
            else
            {
                string fatherid = dtFather.Select("goodsCategoryId = '" + goodsCategoryId + "'")[0]["fatherid"].ToString();
                string Url = "GoodsManager_Category_Add.aspx?GoodsFatherCategoryId=" + goodsCategoryId + "&GoodsCategoryId=" + goodsCategoryId +"&Operate=AddSon";
                Server.Transfer(Url);
            }
        }

        protected void btnCha_Click(object sender, EventArgs e)
        {
            string Condition = " 1=1 ";
            if (this.txtGoodName.Text.Trim() != "")
            {
                Condition += " AND Description like '%" + this.txtGoodName.Text.Trim() + "%'";
            }

            ViewState["Condition"] = Condition;
            BindDataGrid();
        }
    }
}