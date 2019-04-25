using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;
namespace Web.main_charge.program
{
    public partial class GoodsManager_View : System.Web.UI.Page
    {
        //string id = -1;
        DataTable dtTreeNode = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0302");
                btnAdd.Enabled = clsRighter.Modify | clsRighter.Add;
                if (clsRighter.Read)
                {
                    
                    this.txtId.Text = "-1";
                    if (Request.QueryString["NodeID"] != null && Request.QueryString["NodeID"].ToString() != "")
                    {

                        this.txtId.Text = Request.QueryString["NodeID"].ToString();
                        
                    }
                    this.txtPageIndex.Text = "0";
                    if (Request.QueryString["PageNum"] != null && Request.QueryString["PageNum"].ToString() != "")
                    {

                        this.txtPageIndex.Text = Request.QueryString["PageNum"].ToString();

                    }
                    //绑定treeview
                    DBManager db = DBManager.Instance();
                    dtTreeNode = db.GetDataTable("select * from Goods_Category");
                    TreeNode node = new TreeNode();
                    node.Text = "所有分类";
                    node.Value = "-1";
                    DataRow[] dRows = dtTreeNode.Select("fatherid = '0' ");
                    TreeNode sonNode = new TreeNode();
                    for (int i = 0; i < dRows.Length; i++)
                    {
                        sonNode = new TreeNode(dRows[i]["description"].ToString(), dRows[i]["GoodsCategoryId"].ToString());
                        AddSonNode(sonNode, dRows[i]["GoodsCategoryId"].ToString());
                        node.ChildNodes.Add(sonNode);
                    }
                    tvCategory.Nodes.Add(node);

                    //创建操作员记录数据表类实例
                    Goods goods = new Goods();
                    ////获取记录数据
                    //DataTable dt1 = goods.ShowCate();
                    //DataRow df = dt1.NewRow();
                    //df["Description"] = "---请选择---";
                    //dt1.Rows.InsertAt(df, 0);
                    //ddlGoodsCateID.DataSource = dt1;
                    //ddlGoodsCateID.DataTextField = "Description";
                    //ddlGoodsCateID.DataValueField = "GoodsCategoryId";
                    //ddlGoodsCateID.DataBind();
                    GoodsDataGrid.CurrentPageIndex = Convert.ToInt32(this.txtPageIndex.Text);
                    BindDataGrid();

                    int icount = this.GoodsDataGrid.Columns.Count;
                    if (!clsRighter.Add)
                    {
                        this.btnAdd.Visible = false;
                    }
                    if (!clsRighter.Modify)
                    {
                        this.GoodsDataGrid.Columns[icount -2].Visible = false;
                    }
                    if (!clsRighter.Delete)
                    {
                        this.GoodsDataGrid.Columns[icount -1].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 递归所有子节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public TreeNode AddSonNode(TreeNode node, string fatherid)
        {
            TreeNode sonNode = new TreeNode();
            DataRow[] dRows = dtTreeNode.Select("fatherid = '" + fatherid + "' ");
            for (int i = 0; i < dRows.Length; i++)
            {
                sonNode = new TreeNode(dRows[i]["description"].ToString(), dRows[i]["GoodsCategoryId"].ToString());
                AddSonNode(sonNode, dRows[i]["GoodsCategoryId"].ToString());
                node.ChildNodes.Add(sonNode);
            }

            return node;
        }

        /// <summary>
        /// 绑定数据到DataGrid控件GoodsDataGrid上
        /// </summary>		
        private void BindDataGrid()
        {
            //创建操作员记录数据表类实例
            Goods goods = new Goods();
            //获取记录数据
            DataTable dt = goods.BindNodes(this.txtId.Text.Trim());//goods.Bind();
            DataView dv = new DataView();
            dt.TableName = "Goods";
            if (dt != null)
            {
                dv.Table = dt;
                dv.Sort = " Price DESC";

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Url = "GoodsManager_Edit.aspx?GoodsId=";
            Server.Transfer(Url);
        }

        protected void GoodsDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //创建用户数据表操作类对象
                Goods goods = new Goods();
                string GoodsId = ((Label)e.Item.Cells[1].Controls[1]).Text;
                //删除用户数据
                if (goods.DelGoods(GoodsId))
                {
                    Common.ShowMsg("删除成功！");
                    //记录操作员操作
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "删除商品信息;商品ID：" + GoodsId);
                }
                Server.Transfer("GoodsManager_View.aspx?NodeID=" + this.txtId.Text + "&PageNum=" + GoodsDataGrid.CurrentPageIndex.ToString());
            }
            else
            {
                string Url = "GoodsManager_Edit.aspx?GoodsId=" + ((Label)e.Item.Cells[1].Controls[1]).Text + "&NodeID=" + this.txtId.Text + "&PageNum=" + GoodsDataGrid.CurrentPageIndex.ToString();
                Server.Transfer(Url);
            }
            
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

        protected void ddlCurrentPage_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int intCurrentPage = int.Parse(ddlCurrentPage.SelectedItem.Value);
            if (intCurrentPage < GoodsDataGrid.PageCount)
            {
                GoodsDataGrid.CurrentPageIndex = intCurrentPage;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void btnCha_Click(object sender, EventArgs e)
        {
            //string GoodsCateID = ddlGoodsCateID.SelectedItem.Value;
            string Condition = " 1=1 ";
            //if (GoodsCateID != null && GoodsCateID != "---请选择---" && GoodsCateID != "")
            //    Condition += " AND GoodsCategoryId='" + GoodsCateID + "'";

            if (this.txtGoodsId.Text.Trim() != "")
            {
                Condition += " AND goodsid like '%" + this.txtGoodsId.Text.Trim() + "%'";
            }
            if (this.txtGoodsName.Text.Trim() != "")
            {
                Condition += " and goodsname like '%" + this.txtGoodsName.Text.Trim() + "%'";
            }

            ViewState["Condition"] = Condition;
            BindDataGrid();
        }

        protected void tvCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            string id = tvCategory.SelectedNode.Value;
            this.txtId.Text = id;
            //创建操作员记录数据表类实例
            Goods goods = new Goods();
            //获取记录数据
            DataTable dt = goods.BindNodes(id);
            DataView dv = new DataView();
            dt.TableName = "Goods";
            if (dt != null)
            {
                dv.Table = dt;
                dv.Sort = " Price DESC";

                //if (ViewState["Condition"] != null && ViewState["Condition"].ToString() != "")
                //    dv.RowFilter = ViewState["Condition"].ToString();
                //else
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
    }
}