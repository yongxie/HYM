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
    public partial class GoodsManager_Edit : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();
        //加载数据
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                dtTemp.Columns.Add("GoodsCategoryId");
                dtTemp.Columns.Add("Description");
                dtTemp.Columns.Add("FatherId");

                //程序模块权限验证
                Authorization clsRighter = new Authorization("0301");
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
                if (clsRighter.Read)
                {
                    if (Request.QueryString["GoodsID"] != null && Request.QueryString["GoodsID"].ToString() != "")
                    {
                        Goods Goods = new Goods();
                        FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                        ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                    }
                    else
                    {
                        ViewState["GoodsID"] = "";
                        FillDataToCtrl(false);
                        ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                        this.btnDelete.Visible = false;
                    }
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
                }
                
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
            dt = db.GetDataTable(strSql) ;
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
                df["Description"] = "---请选择---";
                dtTemp.Rows.InsertAt(df, 0);
                ddlGoodsCateId.DataSource = dtTemp;
                ddlGoodsCateId.DataTextField = "Description";
                ddlGoodsCateId.DataValueField = "GoodsCategoryId";
                ddlGoodsCateId.DataBind();

                //this.ddlGoodsCateId.Items.Clear();
                //this.ddlGoodsCateId.Items.Add("类别1");
                //this.ddlGoodsCateId.Items.Add("类别2");
                this.ddlGoodsCateId.SelectedIndex = 0;

                GoodsDB goodsdb = new GoodsDB();

                if (IsFill)
                {
                    Goods goods = new Goods();
                    goodsdb = goods.FindGoods(Request.QueryString["GoodsID"].ToString());
                    this.txtGoodsID.Enabled = false;
                    this.txtCode.Enabled = false;

                    txtCode.Text = Common.CCToEmpty(goodsdb.Code);
                    txtDesc.Text = Common.CCToEmpty(goodsdb.Description);
                    txtGoodsID.Text = goodsdb.GoodsId.ToString();
                    txtGoodsName.Text = Common.CCToEmpty(goodsdb.GoodsName);
                    txtPrice.Text = Convert.ToDouble(goodsdb.Price).ToString("0.00");


                    for (int i = 0; i < ddlGoodsCateId.Items.Count; i++)
                    {
                        if (this.ddlGoodsCateId.Items[i].Value == goodsdb.GoodsCategoryId.Trim())
                        {
                            ddlGoodsCateId.SelectedIndex = i;
                            break;
                        }
                    }
                    //if (goodsdb.GoodsCategoryId.Trim() == "类别1")
                    //{
                    //    ddlGoodsCateId.SelectedIndex = 0;
                    //}
                    //else if (goodsdb.GoodsCategoryId.Trim() == "类别2")
                    //{
                    //    ddlGoodsCateId.SelectedIndex = 1;
                    //}
                }
                else
                {
                    goodsdb = new GoodsDB();
                    this.txtGoodsID.Enabled = true;
                }
            }
        }

        //保存数据
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (this.ddlGoodsCateId.SelectedValue == "")
                {
                    Common.ShowMsg("请选择商品类别！");
                    return;
                }
                //创建用户数据表操作类对象
                Goods Goods = new Goods();
                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    
                    string Goodsid = this.txtGoodsID.Text.Trim();
                    string GoodsName = this.txtGoodsName.Text.Trim();
                    string Code = this.txtCode.Text.Trim();
                    string Desc = this.txtDesc.Text.Trim();
                    string GoodsCate = this.ddlGoodsCateId.SelectedItem.Value;
                    double Price = Convert.ToDouble(this.txtPrice.Text.Trim());
                    //增加用户数据
                    if (Goods.AddGoods(Goodsid, GoodsName, Code, Price, GoodsCate, Desc))
                    {
                        Common.ShowMsg("添加成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "增加商品信息;商品简码：" + Code);
                    }
                    else 
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    string Goodsname = this.txtGoodsName.Text.Trim();
                    string Desc = this.txtDesc.Text.Trim();
                    string GoodsCate = this.ddlGoodsCateId.SelectedItem.Value;
                    string GoodsId = this.txtGoodsID.Text.Trim();
                    double Price = Convert.ToDouble(this.txtPrice.Text.Trim());

                    //更新用户数据
                    if (Goods.UpdateGoods(GoodsId, Goodsname, Price, GoodsCate, Desc))
                    {
                        Common.ShowMsg("更新成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "商品管理 ;商品名称：" + Goodsname);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Server.Transfer("GoodsManager_View.aspx?NodeId=" + this.txtId.Text + "&PageNum=" + this.txtPageIndex.Text);
        }

        //删除数据
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            Goods goods = new Goods();
            string GoodsId = this.txtGoodsID.Text.Trim();
            //删除用户数据
            if (goods.DelGoods(GoodsId))
            {
                Common.ShowMsg("删除成功！");
                //记录操作员操作
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "商品管理", "删除商品信息;商品ID：" + GoodsId);
            }
            else
            {
                return;
            }
            Server.Transfer("GoodsManager_View.aspx?NodeId=" + this.txtId.Text + "&PageNum=" + this.txtPageIndex.Text);
        }

        //返回上一页
        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("GoodsManager_View.aspx?NodeId=" + this.txtId.Text + "&PageNum=" + this.txtPageIndex.Text);
        }
    }
}