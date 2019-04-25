using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UtilLib;
using DBUtil;

namespace Web.main_system.program
{
    public partial class System_UserAuthorization_Index : System.Web.UI.Page
    {
        DataTable dtTreeNode = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0601");
                if (clsRighter.Read)
                {
                    //绑定treeview
                    DBManager db = DBManager.Instance();
                    dtTreeNode = db.GetDataTable("select * from Sys_User");
                    TreeNode node = new TreeNode();
                    node.Text = "所有用户";
                    node.Value = "0";
                    DataRow[] dRows = dtTreeNode.Select("father = '0' ");
                    TreeNode sonNode = new TreeNode();
                    for (int i = 0; i < dRows.Length; i++)
                    {
                        sonNode = new TreeNode(dRows[i]["UserName"].ToString(), dRows[i]["UserId"].ToString());
                        AddSonNode(sonNode, dRows[i]["UserId"].ToString());
                        node.ChildNodes.Add(sonNode);
                    }
                    tvCategory.Nodes.Add(node);

                    BindDataGrid();			//绑定所有用户信息数据到DataGrid


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
                    Common.ShowMsg("权限不足！");
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
            DataRow[] dRows = dtTreeNode.Select("father = '" + fatherid + "' ");
            for (int i = 0; i < dRows.Length; i++)
            {
                sonNode = new TreeNode(dRows[i]["UserName"].ToString(), dRows[i]["UserId"].ToString());
                AddSonNode(sonNode, dRows[i]["UserId"].ToString());
                node.ChildNodes.Add(sonNode);
            }

            return node;
        }

        /// <summary>
        /// 绑定数据到DataGrid控件MyDataGrid上
        /// </summary>
        private void BindDataGrid()
        {
            OperatorAuthorization clsRight = new OperatorAuthorization();	//创建用户权限数据表操作类实例
            DataTable dt = clsRight.BindData();		//获取绑定数据的数据集对象
            if (dt != null)
            {
                int intCountRecNum = dt.Rows.Count;	//获取数据表记录数
                MyDataGrid.DataSource = dt.DefaultView;
                MyDataGrid.DataBind();
                lblRecNum.Text = intCountRecNum.ToString();	//显示总记录数
                ShowStats();		//显示页数信息
            }
        }

        #region 控制分页信息
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

        /// <summary>
        ///  翻页LinkButton公用事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Link_Click(object sender, System.EventArgs e)
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
        #endregion
        /// <summary>
        /// DataGrid选择项响应事件方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void DataOperate(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //创建用户数据表操作类对象
                OperatorAuthorization operate = new OperatorAuthorization();
                string UserId = ((Label)e.Item.Cells[0].Controls[1]).Text;
                //删除用户数据
                if (operate.DelOperater(UserId))
                {
                    Common.ShowMsg("删除成功！");
                    //记录操作员操作
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统管理", "删除用户信息;用户ID：" + UserId);
                }
                Server.Transfer("System_UserAuthorization_Index.aspx");
            }
            else
            {
                string Url = "System_UserAuthorization_Admin.aspx?UserID=" + ((Label)e.Item.Cells[0].Controls[1]).Text;
                Server.Transfer(Url);
            }
        }

        protected void ddlCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCurrentPage = int.Parse(ddlCurrentPage.SelectedItem.Value);
            if (intCurrentPage < MyDataGrid.PageCount)
            {
                MyDataGrid.CurrentPageIndex = intCurrentPage;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //使用弹出屏幕对话窗口方式快整录入房间
            string Url = "System_UserAuthorization_Admin.aspx?UserID=";
            Server.Transfer(Url);
        }

        protected void tvCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            string id = tvCategory.SelectedNode.Value;
            OperatorAuthorization clsRight = new OperatorAuthorization();	//创建用户权限数据表操作类实例
            DataTable dt = clsRight.BindNodes(id);		//获取绑定数据的数据集对象
            if (dt != null)
            {
                int intCountRecNum = dt.Rows.Count;	//获取数据表记录数
                MyDataGrid.DataSource = dt.DefaultView;
                MyDataGrid.DataBind();
                lblRecNum.Text = intCountRecNum.ToString();	//显示总记录数
                ShowStats();		//显示页数信息
            }	
        }

    }

}