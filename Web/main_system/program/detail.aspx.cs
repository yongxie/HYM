using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace Web
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DataGridBind();
            } 
        }

        private void DataGridBind()
        {
            SMSOperateDB smsdb;
            SMSOperate sms = new SMSOperate();

            smsdb = sms.ShowMsg(Request.QueryString["MsgId"]);
            this.txtNum.Text = smsdb.DirNum.ToString();
            this.txtMsg.Text = smsdb.Msg;
            this.txtTime.Text = smsdb.SendTime.ToString();
        } 
    }
}