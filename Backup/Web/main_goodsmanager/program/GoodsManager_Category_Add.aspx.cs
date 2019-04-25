using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;

namespace Web.main_goodsmanager.program
{
    public partial class GoodsManager_Category_Add : System.Web.UI.Page
    {
        string strGoodsCategoryId = "";
        string strGoodsFatherCategoryId = "";
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                dtTemp.Columns.Add("GoodsCategoryId");
                dtTemp.Columns.Add("Description");
                dtTemp.Columns.Add("FatherId");

                //if (Request.QueryString["GoodsCategoryId"] != null && Request.QueryString["GoodsCategoryId"].ToString() != "")
                if (Request.QueryString["Operate"].ToString() == "AddBrother")
                {
                    strGoodsCategoryId = Request.QueryString["GoodsCategoryId"].ToString();
                    strGoodsFatherCategoryId = Request.QueryString["GoodsFatherCategoryId"].ToString();
                    FillDataToCtrl(false);
                    ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                    this.btnDelete.Visible = false;
                }
                else if (Request.QueryString["Operate"].ToString() == "AddSon")
                {
                    strGoodsCategoryId = Request.QueryString["GoodsCategoryId"].ToString();
                    strGoodsFatherCategoryId = Request.QueryString["GoodsFatherCategoryId"].ToString();
                    FillDataToCtrl(false);
                    ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                    this.btnDelete.Visible = false;
                }
                else if (Request.QueryString["Operate"].ToString() == "Edit")
                {
                    strGoodsCategoryId = Request.QueryString["GoodsCategoryId"].ToString();
                    strGoodsFatherCategoryId = Request.QueryString["GoodsFatherCategoryId"].ToString();
                    FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                    ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                }


                //程序模块权限验证
                Authorization clsRighter = new Authorization("0303");
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
            }
        }
        private void InsertdtTemp(string fatherid, string nullStr)
        {
            DataRow[] dRows = dt.Select("fatherid = '" + fatherid + "'");
            nullStr += "—";
            for (int i = 0; i < dRows.Length; i++)
            {
                dtTemp.Rows.Add(dRows[i]["GoodsCategoryId"], nullStr + dRows[i]["Description"].ToString(), dRows[i]["FatherId"]);
                InsertdtTemp(dRows[i]["GoodsCategoryId"].ToString(), nullStr);
            }
        }
        /// <summary>
        /// 填充数据到表单文本控件,下拉框控件
        /// </summary>
        /// <param name="IsFill"></param>
        private void FillDataToCtrl(bool IsFill)
        {
            DBManager db = DBManager.Instance();
            string strSql = "select GoodsCategoryId,Description,FatherID from goods_category";
            //获取记录数据
             dt = db.GetDataTable(strSql);


             dtTemp.TableName = "GoodsCategory";
             if (dt != null)
             {
                 dtTemp.Rows.Clear();
                 DataRow[] dRows = dt.Select("fatherid = '0'");
                 for (int i = 0; i < dRows.Length; i++)
                 {
                     dtTemp.Rows.Add(dRows[i]["GoodsCategoryId"], dRows[i]["Description"], dRows[i]["FatherId"]);
                     InsertdtTemp(dRows[i]["GoodsCategoryId"].ToString(), "—");
                 }



                 DataRow df = dtTemp.NewRow();
                 df["Description"] = "---顶级分类---";
                 df["GoodsCategoryId"] = "0";
                 dtTemp.Rows.InsertAt(df, 0);
                 ddlFather.DataSource = dtTemp;
                 ddlFather.DataTextField = "Description";
                 ddlFather.DataValueField = "GoodsCategoryId";
                 ddlFather.DataBind();




                 GoodsCategoryDB goodscatedb = new GoodsCategoryDB();

                 if (IsFill)
                 {
                     GoodsCategory goodscate = new GoodsCategory();
                     goodscatedb = goodscate.FindCate(strGoodsCategoryId);

                     //txtCateId.Text = Common.CCToEmpty(goodscatedb.GoodsCategoryId);
                     txtCateName.Text = Common.CCToEmpty(goodscatedb.Description);
                     //ddlFather.SelectedIndex = Convert.ToInt32(Common.CCToEmpty(goodscatedb.FatherId));
                     ddlFather.SelectedValue = goodscatedb.FatherId;
                 }
                 else
                 {
                     goodscatedb = new GoodsCategoryDB();
                     ddlFather.SelectedValue = strGoodsFatherCategoryId;
                     //this.txtCateId.Enabled = true;
                 }
             }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户数据表操作类对象
                GoodsCategory goodscate = new GoodsCategory();
                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                   // string CateId = this.txtCateId.Text.Trim();
                    string CateName = this.txtCateName.Text.Trim();
                    string Father = this.ddlFather.SelectedItem.Value;
                    //this.txtFather.ReadOnly = false;
                    //增加用户数据
                    if (goodscate.AddCate( CateName, Father))
                    {
                        Common.ShowMsg("添加成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "增加商品分类;分类名称：" + CateName);
                    }
                    else
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    //string CateId = this.txtCateId.Text.Trim();
                    string CateName = this.txtCateName.Text.Trim();
                    string Father = this.ddlFather.SelectedItem.Value;

                    //更新用户数据
                    if (goodscate.UpdateCate(strGoodsCategoryId, CateName, Father))
                    {
                        Common.ShowMsg("更新成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "更新商品分类;分类名称：" + CateName);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Server.Transfer("GoodsManager_Category_Index.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            GoodsCategory goodscate = new GoodsCategory();
            //string CateId = this.txtCateId.Text.Trim();
            string CateName = this.txtCateName.Text.Trim();
            //删除用户数据
            if (goodscate.DelCate(strGoodsCategoryId))
            {
                Common.ShowMsg("删除成功！");
                //记录操作员操作
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "删除商品分类;分类名称：" + CateName);
            }
            else
            {
                return;
            }
            Server.Transfer("GoodsManager_Category_Index.aspx");
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("GoodsManager_Category_Index.aspx");
        }
    }
}