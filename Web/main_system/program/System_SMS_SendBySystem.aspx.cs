using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using SMSAgent;
using DBUtil;

namespace Web.main_system.program
{
    public partial class System_SMS_SendBySystem : System.Web.UI.Page
    {
        SMS sms = new SMS("ew4878", "朕桦商贸", "yuzhen0808");
        ResMsg res = new ResMsg();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0502");
                btnSend.Enabled = clsRighter.Modify | clsRighter.Add;
                
                //GroupAuthorization group = new GroupAuthorization();
                //DataTable dt = group.GetGroupName();
                string strSql = @"select * from Mem_Card_Level";
                DataTable dt = new DataTable();
                DBManager db = DBManager.Instance();
                dt = db.GetDataTable(strSql);

                ddlLevelID.DataTextField = "LevelName";
                ddlLevelID.DataValueField = "LevelId";
                ddlLevelID.DataSource = dt.DefaultView;
                ddlLevelID.DataBind();

                string strSql2 = "select Id, TemplateName,TemplateContent from SMS_Template";
                //获取记录数据
                DataTable dt1 = db.GetDataTable(strSql2);
                DataRow df = dt1.NewRow();
                df["TemplateName"] = "---自定义---";
                dt1.Rows.InsertAt(df, 0);
                ddlTemp.DataSource = dt1;
                ddlTemp.DataTextField = "TemplateName";
                ddlTemp.DataValueField = "Id";
                ddlTemp.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string strCardId = "";
            string strCardLast = "";
            string strNowDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string strNowTime = DateTime.Now.Date.ToString("hh:MM:ss");
            string strMemName = "";
            string strMoney = "";

            string levelid = this.ddlLevelID.Items.Count > 0 ? ddlLevelID.SelectedItem.Value : "";
            string strContent = this.txtContent.Text;
            if(strContent == "")
            {
                Common.ShowMsg("发送内容不能为空！");
                return;
            }
            string strSql = @"select a.MemName,a.Mobile,b.Account,c.LevelName,b.Pwd,b.cardid from Mem a,Mem_Card b,Mem_Card_Level c
                                            where a.CardId = b.CardId and b.CardLevel = c.LevelId and c.LevelId = '" + levelid + "'";
            DataTable dt = new DataTable();
            DBManager db = DBManager.Instance();
            dt = db.GetDataTable(strSql);
            string strTel = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strTel = dt.Rows[i]["mobile"].ToString().Trim();




                if (strTel.Length != 11)
                {
                    continue;
                }
                else 
                {
                    strCardId = dt.Rows[i]["cardid"].ToString();
                    strMemName = dt.Rows[i]["MemName"].ToString();
                    strMoney = dt.Rows[i]["account"].ToString();
                    strCardLast = strCardId.Substring(strCardId.Length - 4);

                    string strTemp = strContent;
                    strTemp.Replace("#CardID#", strCardId);
                    strTemp.Replace("#LCardID#", strCardLast);
                    strTemp.Replace("#Date#", strNowDate);
                    strTemp.Replace("#Time#", strNowTime);
                    strTemp.Replace("##Name#", strMemName);
                    strTemp.Replace("#Money#", strMoney);


                    sms.Send(strTel, strContent);
                    SMSOperate.SaveRecord(strTel, strContent);
                }
            }
            Common.ShowMsg("短信发送操作已完成！");
            //RecordOperate.SaveRecord(Session["UserID"].ToString(), "短信平台", "使用系统数据发送短信;用户组ID：" + groupid + ";发送内容：" + strContent);
            //RecordOperate.SaveRecord(Session["UserID"].ToString(), "短信平台", "使用系统数据发送短信;会员级别：" + levelid + ";");
            
        }

        protected void ddlTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTemp.SelectedIndex == 0)
            {
                txtContent.Text = "";
            }
            else
            {
                SMSTemplate sms = new SMSTemplate();
                SMSTemplateDB smsdb = new SMSTemplateDB();
                smsdb = sms.ShowTemp(ddlTemp.SelectedItem.Value.ToString());

                txtContent.Text = Common.CCToEmpty(smsdb.TemplateContent);
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_SMSTemplate_Edit.aspx");
        }

    }
}