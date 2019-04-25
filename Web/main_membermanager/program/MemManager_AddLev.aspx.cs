using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;

namespace Web.main_membermanager.program
{
    public partial class MemManager_AddLev : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["LevelId"] != null && Request.QueryString["LevelId"].ToString() != "")
                {
                    FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                    ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                }
                else
                {
                    ViewState["LevelId"] = "";
                    FillDataToCtrl(false);
                    ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                    this.btnDelete.Visible = false;
                }
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0203");
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
            }
        }

        /// <summary>
        /// 填充数据到表单文本控件,下拉框控件
        /// </summary>
        /// <param name="IsFill"></param>
        private void FillDataToCtrl(bool IsFill)
        {
            this.ddlEnbled.Items.Clear();
            this.ddlEnbled.Items.Add("未激活");
            this.ddlEnbled.Items.Add("激活");
            this.ddlEnbled.SelectedIndex = 0;

            MemCardLevelDB memlevelDB;
            if (IsFill)
            {
                MemCardLevel level = new MemCardLevel();
                memlevelDB = level.FindLevel(Request.QueryString["LevelId"]);

                this.txtLevelName.Text = memlevelDB.LevelName;

                if (memlevelDB.Enbled == 1)
                {
                    ddlEnbled.SelectedIndex = 1;
                }
                else if (memlevelDB.Enbled == 0)
                {
                    ddlEnbled.SelectedIndex = 0;
                }
            }
            else
            {
                memlevelDB = new MemCardLevelDB();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户数据表操作类对象
                MemCardLevel level = new MemCardLevel();
                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    string txtlevelname = this.txtLevelName.Text.Trim();
                    int Enbled = this.ddlEnbled.SelectedIndex;
                    //增加用户数据
                    if (level.AddLevel(txtlevelname, Enbled))
                    {
                        Common.ShowMsg("添加成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "增加会员级别;级别名称：" + txtlevelname);

                    }
                    else
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    int levelid = Convert.ToInt32(Request.QueryString["LevelId"]);
                    string txtlevelname = this.txtLevelName.Text.Trim();
                    int enbled=-1;
                    //MemCarsLevelDB leveldb;
                    //leveldb = level.FindUserByCardId(Request.QueryString["CardID"]);
                    if (this.ddlEnbled.SelectedIndex.ToString() == "0")
                    {
                        enbled = 0;
                    }
                    else if (this.ddlEnbled.SelectedIndex.ToString() == "1")
                    {
                        enbled = 1;
                    }

                    //更新用户数据
                    if (level.UpdateLevel(levelid,txtlevelname,enbled))
                    {
                        Common.ShowMsg("更新成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "更新会员级别;级别名称：" + txtlevelname);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Server.Transfer("MemManager_Level.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            MemCardLevel level = new MemCardLevel();
            string levelid = Request.QueryString["LevelId"];
            //删除用户数据
            if (level.DelLevel(levelid))
            {
                Common.ShowMsg("删除成功！");
                //记录操作员操作
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "删除会员级别信息");
            }
            else
            {
                return;
            }
            Server.Transfer("MemManager_Level.aspx");
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("MemManager_Level.aspx");
        }
    }
}