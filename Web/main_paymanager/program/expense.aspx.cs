using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtil;
using System.Data;
using UtilLib;
using System.Drawing.Printing;
using System.IO;
using System.Drawing;
using System.Text;

namespace Web.main_paymanager.program
{
    public partial class expense : System.Web.UI.Page
    {
        double dTotalMoney = 0.00;
        DataTable dtGoods = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["keyword"] != null)
            {
                string keyword = Request.QueryString["keyword"].ToString();

                //查数据库，请将此处改为你要检索的数据库及其账户密码
                //string connString = @"Data Source=.\sqlexpress;Initial Catalog=HYM;User ID=sa;pwd=sa";
                //using (SqlConnection conn = new SqlConnection(connString))
                DBManager db = DBManager.Instance();
                DataTable dt = db.GetDataTable("select Code from Goods where Code like '" + keyword + "%' ");

                string str = "";
                foreach (DataRow dr in dt.Rows)
                {
                    str += dr[0].ToString() + ",";
                }
                if (str != "")//去最后一个,号
                    str = str.Substring(0, str.Length - 1);

                Response.Write(str);
                Response.End();


            }
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0101");
                this.btnJiezhang.Enabled = clsRighter.Modify | clsRighter.Add;

                dtGoods.Columns.Add("idno");
                dtGoods.Columns.Add("GoodsCode");
                dtGoods.Columns.Add("GoodsName");
                dtGoods.Columns.Add("Price");
                dtGoods.Columns.Add("Count");
                dtGoods.Columns.Add("Money");
                //dtGoods.Rows.RemoveAt(
                ViewState["dtGoods"] = dtGoods;

                BindDataGrid();

                this.lbAccount.Enabled = false;
                this.lbUserName.Enabled = false;
                this.txtSumMoney.Enabled = false;
                
                this.lbAccount.Text = "";
                this.txtCardID2.Text = "";
                this.txtPwd2.Text = "";
                this.txtSumMoney.Text = "";
                this.lbUserName.Text = "";
                this.lbCardID.Text = "";
                SetFocus("txtCardID2");
            }
        }

        private void BindDataGrid()
        {
            dtGoods = ViewState["dtGoods"] as DataTable;
            DataView dv = new DataView();
            dv = dtGoods.DefaultView;

            //新增ID自增值列绑定
            //dt.Columns.Add(new DataColumn("idno", Type.GetType("System.Int32")));
            int intCountRecNum = dv.Count;	//获取数据表记录数
            for (int i = 0; i < intCountRecNum; i++)
            {
                dv[i]["idno"] = i + 1;
            }
            this.GoodsDataGrid.DataSource = dv;

            int PageCount = 0;
            if (intCountRecNum % GoodsDataGrid.PageSize == 0)
                PageCount = intCountRecNum / GoodsDataGrid.PageSize;
            else
                PageCount = intCountRecNum / GoodsDataGrid.PageSize + 1;

            if (PageCount != 0 && GoodsDataGrid.CurrentPageIndex >= PageCount)
                GoodsDataGrid.CurrentPageIndex = PageCount - 1;


            this.GoodsDataGrid.DataBind();

            lblRecNum.Text = intCountRecNum.ToString();	//显示总记录数
            ShowStats();								//显示页数信息

            GetTotalMoney();
        }

        private void GetTotalMoney()
        {
            dTotalMoney = 0.00;
            dtGoods = ViewState["dtGoods"] as DataTable;
            for (int i = 0; i < dtGoods.Rows.Count; i++)
            {
                dTotalMoney += Convert.ToDouble(dtGoods.Rows[i]["Money"].ToString().Trim());
            }
            this.txtSumMoney.Text = dTotalMoney.ToString();
        }

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

        protected void btnShuaka_Click(object sender, EventArgs e)
        {

            string strCardId = this.txtCardID2.Text.Trim();
            string strPwd = this.txtPwd2.Text.Trim();

            //ViewState["CardId"] = strCardId;
            //ViewState["Pwd"] = strPwd;


            string strSql =@"select a.MemName,b.Account,c.LevelName,b.Pwd,a.CardId,b.Status from Mem a,Mem_Card b,Mem_Card_Level c
                                        where a.CardId = b.CardId and b.CardLevel = c.LevelId and b.cardid = '" + strCardId + "' and b.pwd = '" + strPwd + "'";


            DBManager db = DBManager.Instance();
            DataTable dt = db.GetDataTable(strSql);
            if (dt.Rows.Count <= 0)
            {
                Common.ShowMsg("密码错误！请重新输入");
                this.txtPwd2.Text = "";
                this.txtCardID2.Text = "";
                this.lbAccount.Text = "";
                this.lbCardID.Text = "";
                this.lbUserName.Text = "";
                return;
            }
            if (dt.Rows[0]["Status"].ToString().Trim() =="0")
            {
                Common.ShowMsg("此卡尚未激活！请与系统管理员联系");
                this.txtPwd2.Text = "";
                this.txtCardID2.Text = "";
                this.lbAccount.Text = "";
                this.lbCardID.Text = "";
                this.lbUserName.Text = "";
                return;
            }
            this.lbUserName.Text = dt.Rows[0]["MemName"].ToString().Trim();
            string temp =  dt.Rows[0]["Account"].ToString().Trim();
            this.lbAccount.Text =Convert.ToDouble(temp).ToString("0.00") ;
            this.lbCardID.Text = dt.Rows[0]["CardId"].ToString().Trim();
            //ViewState["Account"] = Convert.ToDouble(dt.Rows[0]["Account"].ToString().Trim());
            //this.txtCardID2.Enabled = false;

            this.txtPwd2.Text = "";
            this.txtCardID2.Text = "";
            
            //this.txtPwd2.TextMode = TextBoxMode.SingleLine;

            //Response.Cookies["some"].Expires = DateTime.Now.AddDays(-1);

        }

        protected void Luru_Click(object sender, EventArgs e)
        {
            dtGoods = ViewState["dtGoods"] as DataTable;

            double price = Convert.ToDouble(TextAmt.Text);
            DataRow dr = dtGoods.NewRow();
            dr["idno"] = "";
            dr["GoodsCode"] = "快速消费";
            dr["GoodsName"] = "快速消费";
            dr["Price"] = price.ToString("0.00");
            dr["count"] = 1;
            dr["money"] = price.ToString("0.00");
            dtGoods.Rows.InsertAt(dr, dtGoods.Rows.Count);

            ViewState["dtGoods"] = dtGoods;

            BindDataGrid();
        }

        protected void btnJiezhang_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.lbCardID.Text.Trim() == "")
                {
                    Common.ShowMsg("请刷卡！");
                    return;
                }
                if (this.lbAccount.Text.Trim() == "")
                {
                    Common.ShowMsg("账户错误！");
                    return;
                }
                double dAccount = Convert.ToDouble(this.lbAccount.Text.Trim());

                dAccount -= Convert.ToDouble(this.txtSumMoney.Text.Trim());
                if (dAccount < 0)
                {
                    Common.ShowMsg("余额不足，购买失败！");
                    return;
                }
                string strSql = "update Mem_Card set Account = '" + dAccount + "'  where cardid = '" + this.lbCardID.Text.Trim() + "'";


                DBManager db = DBManager.Instance();
                int i = 0;
                db.Transact(strSql, out i);
                if (i > 0)
                {
                    Common.ShowMsg("结账完成！");
                    //记录操作员操作
                    //RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员消费", "卡号【" + this.txtCardID2.Text + "】消费" + this.txtSumMoney.Text + "元");

                    
                    dtGoods = ViewState["dtGoods"] as DataTable;
                    DataTable dt1 = dtGoods;
                    for (int j = 0; j < this.dtGoods.Rows.Count; j++)
                    {

                        MemCardLevelOperate.SaveRecord(Session["UserId"].ToString(), this.lbCardID.Text.Trim(), "消费", "买商品【" + dtGoods.Rows[j]["GoodsName"].ToString() + "】数量：" + dtGoods.Rows[j]["Count"].ToString(), Convert.ToDouble(dtGoods.Rows[j]["Money"].ToString()), 0);
                    }
                    var user =new []{ lbCardID.Text , lbUserName.Text , txtSumMoney.Text,lbAccount.Text };
                    this.lbAccount.Text = "";
                    this.txtCardID2.Text = "";
                    this.txtPwd2.Text = "";
                    this.txtSumMoney.Text = "";
                    this.lbUserName.Text = "";
                    this.lbCardID.Text = "";
                    DataTable dt = new DataTable();
                    dt.Columns.Add("idno");
                    dt.Columns.Add("GoodsCode");
                    dt.Columns.Add("GoodsName");
                    dt.Columns.Add("Price");
                    dt.Columns.Add("Count");
                    dt.Columns.Add("Money");
                    ViewState["dtGoods"] = dt;
                    BindDataGrid();

                    this.txtCardID2.Enabled = true;
                    SetFocus("txtCardID2");
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("           美奥口腔  \n");
                    //sb.Append("*************************************\n");
                    //sb.Append("会员卡号：" + user[0] + "\n");
                    //sb.Append("会员名称:" + user[1] + "\n");
                    //sb.Append("项目" + "\t\t" + "数量" + "\t" + "单价" + "\t" + "小计" + "\n");
                    //for (int j = 0; j < dt1.Rows.Count; j++)
                    //{
                    //    sb.Append(dt1.Rows[j]["GoodsName"].ToString() + "\t" + dt1.Rows[j]["Count"].ToString() + "\t" + Convert.ToDouble(dt1.Rows[j]["Money"].ToString()) + "\t" + Convert.ToDouble(dt1.Rows[j]["Money"].ToString())+"\n");
                    //}
                    //sb.Append("总计消费:\t\t\t" + user[2] + "\n");
                    //sb.Append("当前余额:\t\t\t" + (Convert.ToDecimal(user[3])- Convert.ToDecimal(user[2])) + "\n");

                    //sb.Append("\n消费人\n\n");
                    //sb.Append("*************************************\n");
                    //sb.Append("     谢谢惠顾欢迎下次光临  ");

                    //Print(sb.ToString());
                }
                else
                {
                    Common.ShowMsg("结账失败！");
                }
            }
            catch (Exception ex)
            {
                Common.ShowMsg("未知异常！");
            }
        }

        private StringReader sr;
        public bool Print(string str)
        {
            bool result = true;
            try
            {

                sr = new StringReader(str);

                PrintDocument pd = new PrintDocument();
                pd.PrintController = new System.Drawing.Printing.StandardPrintController();
                pd.DefaultPageSettings.Margins.Top = 2;
                pd.DefaultPageSettings.Margins.Left = 0;
                pd.DefaultPageSettings.PaperSize.Width = 320;
                pd.DefaultPageSettings.PaperSize.Height = 5150;
                pd.PrinterSettings.PrinterName = pd.DefaultPageSettings.PrinterSettings.PrinterName;//默认打印机
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();

            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
            return result;
        }



        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font printFont = new Font("Arial", 9);//打印字体

            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = "";

            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            while (count < linesPerPage && ((line = sr.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
           
            this.lbAccount.Text = "";
            this.txtCardID2.Text = "";
            this.txtPwd2.Text = "";
            this.lbUserName.Text = "";
            
            //this.txtCardID2.Enabled = true;
            
            this.txtPwd2.Text = "";
            
            this.txtCardID2.Text = "";
            
            this.lbAccount.Text = "";
            
            this.lbCardID.Text = "";
            
            this.lbUserName.Text = "";
             //this.txtPwd2.TextMode = TextBoxMode.SingleLine;


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Url = "inputmoney.aspx?";
            Server.Transfer(Url);
        }

        protected void GoodsDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //创建用户数据表操作类对象
                dtGoods = ViewState["dtGoods"] as DataTable;

                string GoodsId = ((Label)e.Item.Cells[1].Controls[1]).Text;
                //删除用户数据
                dtGoods.Rows.Remove(dtGoods.Select("GoodsCode = '" + GoodsId + "'")[0]);
                ViewState["dtGoods"] = dtGoods;

                BindDataGrid();

            }
        }

        [System.Web.Services.WebMethod]
        public static  string GetArray(string name)
        {
            try
            {
                List<string> list = new List<string>();
                #region
                list.Add("1");
                list.Add("12");
                list.Add("123");
                list.Add("1234");
                list.Add("12345");
                list.Add("123456");
                list.Add("1234567");
                list.Add("12345678");
                list.Add("123456789");
                list.Add("9876543210");
                list.Add("987654321");
                list.Add("98765432");
                list.Add("9876543");
                list.Add("987654");
                list.Add("98765");
                list.Add("9876");
                list.Add("987");
                list.Add("98");
                list.Add("9");
                list.Add("1111222");
                list.Add("1sdfsdf.comdos32.cn");
                list.Add("111222.comdos32.cn");
                list.Add("a11sdafs.netdos32.cn");
                list.Add("b22dsafsdfdos32.cn");
                list.Add("c333asdfsadfdos32.cn");
                list.Add("4444dsafasdfdos32.cn");
                list.Add("dddsfddsafdsafdos32.cn");
                list.Add("121213dsafsdafdos32.cn");
                list.Add("43213asdfadsfdos32.cn");
                list.Add("dsa3121dasf3dos32.cn");
                list.Add("a213dos32.cn");
                list.Add("323313dos32.cn");
                list.Add("3213dos32.cn");
                list.Add("32213dos32.cn");
                list.Add("dsfsdddddos32.cn");
                list.Add("ds911dfsfddos32.cn");
                list.Add("ffdafddos32.cn");
                list.Add("杨澜");
                list.Add("杨扬");
                list.Add("杨白劳");
                list.Add("杨钰莹");
                list.Add("杨百万");
                list.Add("杨一洋");
                list.Add("杨丞琳");
                list.Add("杨一尔");
                list.Add("杨二尔");
                #endregion
                List<string> l1 = list.FindAll(delegate(string ss) { return ss.Contains(name); });
                string str = "[";
                foreach (string s in l1)
                {
                    str += "\"" + s + "\"" + ",";
                }
                str = str.TrimEnd(',') + "]";
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}