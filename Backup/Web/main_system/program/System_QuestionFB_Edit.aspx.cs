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
    public partial class System_QuestionFB_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0609");
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
                if (clsRighter.Read)
                {
                    if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
                    {
                        FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                        this.showtr.Visible = true;
                        ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                        this.trAnwser1.Visible = true;
                        this.trAnwser2.Visible = true;
                        this.txtQuesContent.ReadOnly = true;
                    }
                    else
                    {
                        ViewState["ID"] = "";
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
            QuestionOperateDB questionsdb = new QuestionOperateDB();

            if (IsFill)
            {
                QuestionOperate questions = new QuestionOperate();
                questionsdb = questions.FindQues(Request.QueryString["ID"].ToString());

                txtQuesName.Text = Common.CCToEmpty(questionsdb.QAName);
                txtQuesContent.Text = Common.CCToEmpty(questionsdb.Question);
                lblQer.Text = Common.CCToEmpty(questionsdb.Qer);
                lblTime.Text = Common.CCToEmpty(questionsdb.QuestionTime.ToString());
                txtAnwser.Text = Common.CCToEmpty(questionsdb.Anwser);
                lblAer.Text = Common.CCToEmpty(questionsdb.Aer);
                lblATime.Text = Common.CCToEmpty(questionsdb.AnwserTime.ToString());
            }
            else
            {
                questionsdb = new QuestionOperateDB();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户数据表操作类对象
                QuestionOperate questions = new QuestionOperate();
                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    string quesname = this.txtQuesName.Text.Trim();
                    string quescontent = this.txtQuesContent.Text.Trim();
                    string name = Session["UserID"].ToString();
                    this.showtr.Visible = false;

                    //增加用户数据
                    if (questions.AddQues(quesname, quescontent, name))
                    {
                        Common.ShowMsg("添加成功！");
                        string newsname = this.txtQuesName.Text;
                        string subNewName = newsname;
                        //记录操作员操作
                        if (newsname.Length > 16)
                            subNewName = newsname.Substring(0, 16) + "...";
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "添加问题反馈信息：" + subNewName);
                    }
                    else
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    string quesname = this.txtQuesName.Text.Trim();
                    string quescontent = "";
                    if (this.trNew.Visible == false)
                    {
                        quescontent = this.txtQuesContent.Text.Trim();
                    }
                    else
                    {
                        quescontent = this.txtNewContent.Text.Trim();
                    }
                    string id = Request.QueryString["ID"].ToString();
                    this.showtr.Visible = true;
                    //更新用户数据
                    if (questions.UpdateQues(id, quesname, quescontent))
                    {
                        Common.ShowMsg("更新成功！");
                        string newsname = this.txtQuesName.Text;
                        string subNewName = newsname;
                        //记录操作员操作
                        if (newsname.Length > 16)
                            subNewName = newsname.Substring(0, 16) + "...";
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "修改问题反馈信息：" + subNewName);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Server.Transfer("System_QuestionFB_View.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            QuestionOperate questions = new QuestionOperate();
            string Id = Request.QueryString["ID"].ToString();
            //删除用户数据
            if (questions.DelQues(Id))
            {
                Common.ShowMsg("删除成功！");
                string newsname = this.txtQuesName.Text;
                string subNewName = newsname;
                //记录操作员操作
                if (newsname.Length > 16)
                    subNewName = newsname.Substring(0, 16) + "...";
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "系统功能", "删除问题反馈信息：" + subNewName);
            }
            else
            {
                return;
            }
            Server.Transfer("System_QuestionFB_View.aspx");
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_QuestionFB_View.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.trNew.Visible = true;
        }
    }
}