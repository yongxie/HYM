using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSAgent;
using UtilLib;

namespace Web.main_system.program
{
    public partial class System_SMS_GetLast : System.Web.UI.Page
    {
        SMS sms = new SMS("ew4878", "朕桦商贸", "yuzhen0808");
        ResMsg res = new ResMsg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0503");
                if (clsRighter.Read)
                {

                    res = sms.GetAccount();
                    if (res.Result == false)
                    {
                        Common.ShowMsg("短信平台连接短信网关失败！请与短信提供商联系！");
                    }
                    else
                    {
                        this.lbLast.Text = res.Message;
                    }
                }
                else
                {
                    Common.ShowMsg("权限不足！");
                }
            }
        }
    }
}