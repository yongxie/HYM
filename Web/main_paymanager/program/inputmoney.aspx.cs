using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using DBUtil;
using System.Data;
namespace Web.main_paymanager.program
{
    public partial class inputmoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetFocus("txtCardID");
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0102");
                this.btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                if (clsRighter.Read)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("key");
                    dt.Columns.Add("value");
                    //dt.Rows.Add("-1", "--请选择--");
                    //dt.Rows.Add("0","消费");
                    dt.Rows.Add("1", "充值");
                    dt.Rows.Add("2", "扣除");

                    this.ddlOperate.DataSource = dt;
                    ddlOperate.DataTextField = "value";
                    ddlOperate.DataValueField = "key";
                    ddlOperate.DataBind();

                }
                else
                { 
                    Common.ShowMsg("权限不足！"); 
                }
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strCardId = this.lbCardID.Text.ToString();

            string strMoney = this.txtMoney.Text.ToString();
            string dir = this.ddlOperate.SelectedValue.ToString();


            if (strCardId == "")
            {
                UtilLib.Common.ShowMsg("请先查询卡号！");
                this.txtCardID2.Focus();
                return;
            }

            if(strMoney == "")
            {
                Common.ShowMsg("请输入金额！");
                this.txtMoney.Focus();
                return;
            }

            double money = 0.00;
            if (!Double.TryParse(strMoney, out money))
            {
                Common.ShowMsg("金额输入不合法！");
                this.txtMoney.Focus();
                return;
            }
            if (dir == "2")
            {
                money = -money;
            }
            Member m = new Member();
            MemberDB mem =  m.FindMemByCardId(strCardId);

            if (mem == null)
            {
                Common.ShowMsg("用户不存在！");
                return;
            }
            if (mem.Status == 0)
            {
                Common.ShowMsg("会员卡尚未激活！请与系统管理员联系");
                return;
            }
            string msg = "";
            m.UpdateMoney(strCardId, money, "充值", out msg);
            Common.ShowMsg(msg);

            //RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员卡充值", "充值卡号：" + strCardId + "；充值金额：" + money);
            if (dir == "1")
            {
                MemCardLevelOperate.SaveRecord(Session["UserId"].ToString(), strCardId, "充值", "充值 " + strMoney + " 元", money, 1);
            }
            else if (dir == "2")
            {
                MemCardLevelOperate.SaveRecord(Session["UserId"].ToString(), strCardId, "扣除", "扣除" + strMoney + " 元", money, 1);
            }


            this.lbAccount.Text = "";
            this.txtCardID2.Text = "";

            this.lbUserName.Text = "";

            //this.txtCardID2.Enabled = true;

            this.lbCardID.Text = "";
            this.txtMoney.Text = "";
        }

        protected void btnShuaka_Click(object sender, EventArgs e)
        {
            string strCardId = this.txtCardID2.Text.Trim();

            //ViewState["CardId"] = strCardId;
            //ViewState["Pwd"] = strPwd;


            string strSql = @"select a.MemName,b.Account,c.LevelName,b.Pwd,a.CardId,b.Status from Mem a,Mem_Card b,Mem_Card_Level c
                                        where a.CardId = b.CardId and b.CardLevel = c.LevelId and b.cardid = '" + strCardId +  "'";


            DBManager db = DBManager.Instance();
            DataTable dt = db.GetDataTable(strSql);
            if (dt.Rows.Count <= 0)
            {
                Common.ShowMsg("卡号不存在！请重新输入");
                this.txtCardID2.Text = "";
                this.lbAccount.Text = "";
                this.lbCardID.Text = "";
                this.lbUserName.Text = "";
                return;
            }
            if (dt.Rows[0]["Status"].ToString().Trim() == "0")
            {
                Common.ShowMsg("此卡尚未激活！请与系统管理员联系");
                this.txtCardID2.Text = "";
                this.lbAccount.Text = "";
                this.lbCardID.Text = "";
                this.lbUserName.Text = "";
                return;
            }
            this.lbUserName.Text = dt.Rows[0]["MemName"].ToString().Trim();
            string temp = dt.Rows[0]["Account"].ToString().Trim();
            this.lbAccount.Text = Convert.ToDouble(temp).ToString("0.00");
            this.lbCardID.Text = dt.Rows[0]["CardId"].ToString().Trim();
            //ViewState["Account"] = Convert.ToDouble(dt.Rows[0]["Account"].ToString().Trim());
            //this.txtCardID2.Enabled = false;

            this.txtCardID2.Text = "";
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.lbAccount.Text = "";
            this.txtCardID2.Text = "";

            this.lbUserName.Text = "";

            //this.txtCardID2.Enabled = true;

            this.lbCardID.Text = "";
            this.txtMoney.Text = "";
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    Server.Transfer("../../include/main.aspx");
        //}
    }
}