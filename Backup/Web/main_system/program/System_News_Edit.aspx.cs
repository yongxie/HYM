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
    public partial class System_News_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0608");
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
                if (clsRighter.Read)
                {
                    if (Request.QueryString["NewsID"] != null && Request.QueryString["NewsID"].ToString() != "")
                    {
                        FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                        ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                    }
                    else
                    {
                        ViewState["NewsID"] = "";
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

            this.ddlType.Items.Clear();
            this.ddlType.Items.Add("---请选择---");
            this.ddlType.Items.Add("系统公告");
            this.ddlType.Items.Add("公司新闻");
            this.ddlType.SelectedIndex = 0;

            this.ddlShow.Items.Clear();
            this.ddlShow.Items.Add("是");
            this.ddlShow.Items.Add("否");
            this.ddlShow.SelectedIndex = 1;
            NewsOperateDB newsdb = new NewsOperateDB();

            if (IsFill)
            {
                NewsOperate news = new NewsOperate();
                newsdb = news.FindNews(Request.QueryString["NewsID"].ToString());

                txtCount.Text = Common.CCToEmpty(newsdb.NewsContent);
                txtNewsName.Text = Common.CCToEmpty(newsdb.NewsName);
                ddlShow.SelectedIndex= Convert.ToInt32(newsdb.ShowOnSys);
                ddlType.SelectedValue = Common.CCToEmpty(newsdb.NewsType);

            }
            else
            {
                newsdb = new NewsOperateDB();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户数据表操作类对象
                NewsOperate news = new NewsOperate();
                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    string count = this.txtCount.Text.Trim();
                    string newsname = this.txtNewsName.Text.Trim();
                    string show = this.ddlShow.SelectedIndex.ToString();
                    string type = this.ddlType.SelectedIndex > 0 ? ddlType.SelectedItem.Value : "";
                    //增加用户数据
                    if (news.AddNews(newsname,count,type,show,Session["UserId"].ToString()))
                    {
                        Common.ShowMsg("添加成功！");
                        string subNewName = newsname;
                        //记录操作员操作
                        if(newsname.Length >16)
                            subNewName = newsname.Substring(0,16) + "...";
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "增加新闻信息：" + subNewName);

                        ////重新在桌面加载新闻动态
                        //Response.Write("<script language=javascript>");
                        //Response.Write("window.top.reload();");
                        //Response.Write("</script>");
                    }
                    else
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    string count = this.txtCount.Text.Trim();
                    string newsname = this.txtNewsName.Text.Trim();
                    string show = this.ddlShow.SelectedIndex.ToString();
                    string type = this.ddlType.SelectedIndex > 0 ? ddlType.SelectedItem.Value : "";
                    string newsid = Request.QueryString["NewsID"].ToString();
                    //更新用户数据
                    if (news.UpdateNews(newsid, newsname, count, type, show, Session["UserID"].ToString()))
                    {
                        Common.ShowMsg("更新成功！");

                        string subNewName = newsname;
                        //记录操作员操作
                        if (newsname.Length > 16)
                            subNewName = newsname.Substring(0, 16) + "...";
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "修改新闻信息：" + subNewName);


                        ////重新在桌面加载新闻动态
                        //Response.Write("<script language=javascript>");
                        //Response.Write("window.top.reload();");
                        //Response.Write("</script>");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Server.Transfer("System_News_View.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            NewsOperate news = new NewsOperate();
            string NewsId = Request.QueryString["NewsID"];
            //删除用户数据
            if (news.DelNews(NewsId))
            {
                Common.ShowMsg("删除成功！");
                string newsname = this.txtNewsName.Text.Trim();
                string subNewName = newsname;
                //记录操作员操作
                if (newsname.Length > 16)
                    subNewName = newsname.Substring(0, 16) + "...";
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "删除新闻信息：" + subNewName);

                ////重新在桌面加载新闻动态
                //Response.Write("<script language=javascript>");
                //Response.Write("window.top.reload();");
                //Response.Write("</script>");
            }
            else
            {
                return;
            }
            Server.Transfer("System_News_View.aspx");
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_News_View.aspx");
        }
    }
}