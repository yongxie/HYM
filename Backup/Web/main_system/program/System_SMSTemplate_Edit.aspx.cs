using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;

namespace Web.main_system.program
{
    public partial class System_SMSTemplate_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0505");
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
                if (clsRighter.Read)
                {
                    if (Request.QueryString["Id"] != null && Request.QueryString["Id"].ToString() != "")
                    {
                        FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                        ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                    }
                    else
                    {
                        ViewState["Id"] = "";
                        FillDataToCtrl(false);
                        ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                        this.btnDelete.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 填充数据到表单文本控件,下拉框控件
        /// </summary>
        /// <param name="IsFill"></param>
        private void FillDataToCtrl(bool IsFill)
        {
            DBManager db = DBManager.Instance();
            SMSTemplateDB smsdb = new SMSTemplateDB();

            if (IsFill)
            {
                SMSTemplate sms = new SMSTemplate();
                smsdb = sms.FindTemp(Request.QueryString["Id"].ToString());

                txtSMSContent.Text = Common.CCToEmpty(smsdb.TemplateContent);
                txtSMSTempName.Text = Common.CCToEmpty(smsdb.TemplateName);

            }
            else
            {
                smsdb = new SMSTemplateDB();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户数据表操作类对象
                SMSTemplate sms = new SMSTemplate();
                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    string count = this.txtSMSContent.Text.Trim();
                    string name = this.txtSMSTempName.Text.Trim();
                    //增加用户数据
                    if (sms.AddTemp(name, count))
                    {
                        Common.ShowMsg("添加成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "增加短信模版");
                    }
                    else
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    string count = this.txtSMSContent.Text.Trim();
                    string name = this.txtSMSTempName.Text.Trim();

                    //更新用户数据
                    if (sms.UpdateTEmp(name, count, Request.QueryString["Id"].ToString()))
                    {
                        Common.ShowMsg("更新成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "修改短信模版");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Server.Transfer("System_SMSTemplate_View.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            SMSTemplate sms = new SMSTemplate();
            string Id = Request.QueryString["Id"];
            //删除用户数据
            if (sms.DelSMSTemp(Id))
            {
                Common.ShowMsg("删除成功！");
                //记录操作员操作
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "删除短信模版");
            }
            else
            {
                return;
            }
            Server.Transfer("System_SMSTemplate_View.aspx");
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_SMSTemplate_View.aspx");
        }
    }
}