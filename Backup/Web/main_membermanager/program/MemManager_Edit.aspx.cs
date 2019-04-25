using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Data;
using DBUtil;

namespace Web.main_membermanager.program
{
    public partial class MemManager_Edit : System.Web.UI.Page
    {
        //private string strAgentID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0201");

                //if (ViewState["OperateStatus"].Equals(null) && !clsRighter.Add)
                //{
                //    Common.ShowMsg("权限不足！");
                //    return;
                //}
                this.ddlStatus.Enabled = true;
                btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                btnDelete.Enabled = clsRighter.Delete;
                if (Session["UserGroupId"].ToString() == "2" || Session["UserGroupId"].ToString() == "3")
                {
                    this.ddlStatus.Enabled = false;
                }
                if (Request.QueryString["MemID"] != null && Request.QueryString["MemID"].ToString() != "")
                {
                    //ViewState["UserID"] = Request.QueryString["UserID"].ToString();
                    MemberOperate mem = new MemberOperate();
                    FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                    ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                }
                else
                {
                    ViewState["CardID"] = "";
                    FillDataToCtrl(false);
                    ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                    this.btnDelete.Visible = false;
                }
                if (Request.QueryString["AgentID"] != null && Request.QueryString["AgentID"].ToString() != "")
                {
                    if (Request.QueryString["AgentID"].ToString() != null && Request.QueryString["AgentID"].ToString() != "---请选择---" && Request.QueryString["AgentID"].ToString() != "")
                    {
                        this.txtAgent.Text = Request.QueryString["AgentID"].ToString();
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
            this.ddlSex.Items.Clear();
            //this.ddlSex.Items.Add("---请选择---");
            this.ddlSex.Items.Add("男");
            this.ddlSex.Items.Add("女");
            this.ddlSex.SelectedIndex = 0;

            this.ddlStatus.Items.Clear();
            this.ddlStatus.Items.Add("禁用");
            this.ddlStatus.Items.Add("激活");
            this.ddlStatus.SelectedIndex = 0;
            
            MemberDB memberdb;
            //GroupAuthorization group = new GroupAuthorization();
            //DataTable dt = group.GetGroupName();
            Member mem = new Member();
            DataTable dt = mem.GetMemberLevelView();
            ddlMemLevelID.DataTextField = "LevelName";
            ddlMemLevelID.DataValueField = "LevelID";
            ddlMemLevelID.DataSource = dt.DefaultView;
            ddlMemLevelID.DataBind();
            ddlMemLevelID.SelectedIndex = 0;

            dt = mem.GetProvinceView();
            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataSource = dt.DefaultView;
            ddlProvince.DataBind();
            if (this.ddlProvince.Items.Count > 0)
            {
                this.ddlProvince.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlProvince.SelectedIndex = 0;
            }

            this.ddlCity.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlCity.SelectedIndex = 0;

            this.ddlDistrict.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlDistrict.SelectedIndex = 0;

            //dt = mem.GetCityView(this.ddlProvince.SelectedItem.Value);
            //ddlCity.DataTextField = "CityName";
            //ddlCity.DataValueField = "CityId";
            //ddlCity.DataSource = dt.DefaultView;
            //ddlCity.DataBind();

            //ddlCity.SelectedIndex = 0;


            //dt = mem.GetDistrictView(this.ddlCity.SelectedItem.Value);
            //ddlDistrict.DataTextField = "DistrictName";
            //ddlDistrict.DataValueField = "DistrictId";
            //ddlDistrict.DataSource = dt.DefaultView;
            //ddlDistrict.DataBind();

            //ddlDistrict.SelectedIndex = 0;
            

            if (IsFill)
            {
                memberdb = mem.FindMemByMemId(Request.QueryString["MemID"]);
                //this.txtUserID.Enabled = false;
                this.txtCardID.Enabled = false;
                this.txtMemId.Enabled = false;
                txtAddr.Text = Common.CCToEmpty(memberdb.Addr);
                txtMemName.Text = Common.CCToEmpty(memberdb.MemName);
                txtBirthday.Text = memberdb.Birthday.ToString();
                txtCardID.Text = Common.CCToEmpty(memberdb.CardId);
                txtMobi.Text = Common.CCToEmpty(memberdb.Mobile);
                txtPwd.Text = Common.CCToEmpty(memberdb.CardPwd);
                txtTel.Text = Common.CCToEmpty(memberdb.Tel);
                txtAge.Text = Common.CCToEmpty(memberdb.Age);
                txtJob.Text = Common.CCToEmpty(memberdb.Job);
                txtMemId.Text = Common.CCToEmpty(memberdb.MemID);
                txtIdentitycard.Text = Common.CCToEmpty(memberdb.Identitycard);
                txtOpeningBank.Text = Common.CCToEmpty(memberdb.OpeningBank);
                txtAccountNumber.Text = Common.CCToEmpty(memberdb.AccountNumber);
                txtAccountName.Text = Common.CCToEmpty(memberdb.AccountName);


                //txtUserID.Text = Common.CCToEmpty(userdb.UserID);

                if (memberdb.Sex.Trim() == "男")
                {
                    ddlSex.SelectedIndex = 0;
                }
                else if (memberdb.Sex.Trim() == "女")
                {
                    ddlSex.SelectedIndex = 1;
                }

                if (memberdb.Status.ToString() == "0")
                {
                    ddlStatus.SelectedIndex = 0;
                }
                else if (memberdb.Status.ToString() == "1")
                {
                    ddlStatus.SelectedIndex = 1;
                }

                for (int i = 0; i < ddlMemLevelID.Items.Count; i++)
                {
                    if (this.ddlMemLevelID.Items[i].Value == memberdb.LevelID)
                    {
                        ddlMemLevelID.SelectedIndex = i;
                        break;
                    }
                }

                //dt = mem.GetProvinceView();
                //ddlProvince.DataTextField = "ProvinceName";
                //ddlProvince.DataValueField = "ProvinceId";
                //ddlProvince.DataSource = dt.DefaultView;
                //ddlProvince.DataBind();
                //if (this.ddlProvince.Items.Count > 0)
                //{
                //    this.ddlProvince.Items.Insert(0, new ListItem("请选择", "0"));
                //    this.ddlProvince.SelectedIndex = 0;
                //}


                this.ddlProvince.SelectedValue = memberdb.Province;
                dt = mem.GetCityView(this.ddlProvince.SelectedItem.Value);
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataSource = dt.DefaultView;
                ddlCity.DataBind();
                this.ddlCity.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlCity.SelectedValue = memberdb.City;

                dt = mem.GetDistrictView(this.ddlCity.SelectedItem.Value);
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictId";
                ddlDistrict.DataSource = dt.DefaultView;
                ddlDistrict.DataBind();

                this.ddlDistrict.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlDistrict.SelectedValue = memberdb.District;

            }
            else
            {
                memberdb = new MemberDB();
                //this.txtUserID.Enabled = true;
            }

            
        }
        ///// <summary>
        ///// 生成用户权限表格
        ///// </summary>
        ///// <param name="UserID">用户代码ID</param>
        //private void FillRightTable(string GroupID)
        //{
        //    GroupAuthorization clsGroup = new GroupAuthorization();
        //    String[,] strProgram = clsGroup.ShowGroupRightInPrograms(ViewState["GroupID"].ToString());
        //    if (strProgram != null)
        //    {
        //        //生成表体部分
        //        int j = 0;
        //        CheckBoxList cblTmp;
        //        while (strProgram[j, 0] != null && strProgram[j, 0] != String.Empty)
        //        {
        //            cblTmp = (CheckBoxList)FindControl("cbl" + strProgram[j, 0]);

        //            //判断是否有权限，如果没有,则CheckBox为“未选”状态。
        //            if (strProgram[j, 2] != null && strProgram[j, 2] != "")
        //            {
        //                if (strProgram[j, 2].IndexOf('r') != -1)
        //                    cblTmp.Items[0].Selected = true;

        //                if (strProgram[j, 2].IndexOf('m') != -1)
        //                    cblTmp.Items[1].Selected = true;

        //                if (strProgram[j, 2].IndexOf('a') != -1)
        //                    cblTmp.Items[2].Selected = true;

        //                if (strProgram[j, 2].IndexOf('d') != -1)
        //                    cblTmp.Items[3].Selected = true;
        //            }
        //            j++;
        //        }
        //    }
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (this.ddlCity.SelectedIndex == 0)
                {
                    Common.ShowMsg("请选择所在市！");
                    return;
                }
                if (this.ddlDistrict.SelectedIndex == 0)
                {
                    Common.ShowMsg("请选择所在县！");
                    return;
                }
                if (this.ddlProvince.SelectedIndex == 0)
                {
                    Common.ShowMsg("请选择所在省！");
                    return;
                }
                DBManager db = DBManager.Instance();
                string sql = "select * from Mem where Identitycard = '" + this.txtIdentitycard.Text.Trim() + "' and memid <> '" + this.txtMemId.Text.Trim() + "'" ;
                DataTable dt = new DataTable();
                dt = db.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Common.ShowMsg("身份证号已存在！请修改！");
                    return;
                }


                //创建用户数据表操作类对象
                Member mem = new Member();


                if (ViewState["OperateStatus"].ToString() == "AddData")
                {
                    string memid = this.txtMemId.Text.Trim();
                    string memname = this.txtMemName.Text.Trim();
                    string cardid = this.txtCardID.Text.Trim();
                    string pwd = this.txtPwd.Text.Trim();
                    string sex = this.ddlSex.Items.Count>0?ddlSex.SelectedItem.Value : "";
                    string levelid = this.ddlMemLevelID.Items.Count > 0 ? ddlMemLevelID.SelectedItem.Value : "";
                    string tel = this.txtTel.Text.Trim();
                    string mobile = this.txtMobi.Text.Trim();
                    string birthday = this.txtBirthday.Text.Trim();
                    string age = this.txtAge.Text.Trim();
                    string job = this.txtJob.Text.Trim();

                    string Identitycard = this.txtIdentitycard.Text.Trim();
                    string OpeningBank = this.txtOpeningBank.Text.Trim();
                    string AccountNumber = this.txtAccountNumber.Text.Trim();
                    string AccountName = this.txtAccountName.Text.Trim();
                    string Province = this.ddlProvince.SelectedItem.Value;
                    string City = this.ddlCity.SelectedItem.Value;
                    string District = this.ddlDistrict.SelectedItem.Value;
                    int status = ddlStatus.SelectedIndex;
                    string addr = this.txtAddr.Text.Trim();
                    int account = 0;
                    int jifen = 0;
                    DateTime createdate = DateTime.Now;
                    string father = Session["UserID"].ToString();
                    //增加用户数据
                    db = DBManager.Instance();
                    sql = "select * from Mem where memid = '" +memid + "'";
                    dt = new DataTable();
                    dt = db.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        Common.ShowMsg("此用户ID已存在！添加会员失败！");
                        return;
                    }
                    sql = "select * from Mem_card where CardId = '" + cardid + "'";
                    dt = db.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        Common.ShowMsg("此会员卡号已存在！添加会员失败！");
                        return;
                    }

                    if (mem.AddMember(memid, memname, cardid, sex, age, job, tel, mobile, createdate, birthday, status, addr, Identitycard, OpeningBank, AccountNumber, AccountName,
                        Province,City,District,father))
                    {
                        mem.AddMemCard(cardid,pwd,levelid,status);
                        Common.ShowMsg("添加成功！");
                        //记录操作员操作
                        RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "增加会员;卡号：" + cardid);

                    }
                    else 
                    {
                        return;
                    }
                }

                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    string memid = this.txtMemId.Text.Trim();
                    string memname = this.txtMemName.Text.Trim();

                    string sex = this.ddlSex.SelectedItem.Value;

                    string tel = this.txtTel.Text.Trim();
                    string mobile = this.txtMobi.Text.Trim();
                    string birthday = this.txtBirthday.Text;
                    string addr = this.txtAddr.Text.Trim();
                    string age = this.txtAge.Text.Trim();
                    string job = this.txtJob.Text.Trim();
                    string Identitycard = this.txtIdentitycard.Text.Trim();
                    string OpeningBank = this.txtOpeningBank.Text.Trim();
                    string AccountNumber = this.txtAccountNumber.Text.Trim();
                    string AccountName = this.txtAccountName.Text.Trim();
                    string Province = this.ddlProvince.SelectedItem.Value;
                    string City = this.ddlCity.SelectedItem.Value;
                    string District = this.ddlDistrict.SelectedItem.Value;

                    string cardid = this.txtCardID.Text.Trim();
                    string pwd = this.txtPwd.Text.Trim();
                    string levelid = this.ddlMemLevelID.Items.Count > 0 ? ddlMemLevelID.SelectedItem.Value : "";
                   

                    MemberDB memdb;
                    int status=-1;
                    memdb = mem.FindMemByMemId(Request.QueryString["MemID"]);
                    if (this.ddlStatus.SelectedIndex.ToString() == "0")
                    {
                        status = 0;
                    }
                    else if (this.ddlStatus.SelectedIndex.ToString() == "1")
                    {
                        status = 1;
                    }
                    try
                    {
                        //更新用户数据

                        if (mem.UpdateMember(memid, memname, cardid, sex, age, job, tel, mobile, birthday, addr, Identitycard, OpeningBank, AccountNumber, AccountName, Province, City, District, status))
                        {
                            mem.UpdateMemCard(cardid, pwd, levelid, status);
                            Common.ShowMsg("更新成功！");
                            //记录操作员操作
                            RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "更新会员信息;卡号：" + cardid);
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception)
                    {
 
                    }
                }
            }
            Server.Transfer("MemManager_View.aspx?AgentID=" + this.txtAgent.Text);
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("MemManager_View.aspx?AgentID=" + this.txtAgent.Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //创建用户数据表操作类对象
            Member mem = new Member();
            string cardid = this.txtCardID.Text.Trim();
            //删除用户数据
            if (mem.DelMember(cardid))
            {
                Common.ShowMsg("删除成功！");
                //记录操作员操作
                RecordOperate.SaveRecord(Session["UserID"].ToString(), "会员管理", "删除会员信息");
            }
            else
            {
                return;
            }
            Server.Transfer("MemManager_View.aspx?AgentID=" + this.txtAgent.Text);
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            Member mem = new Member();
            DataTable dt = new DataTable();
            dt = mem.GetCityView(this.ddlProvince.SelectedItem.Value);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataSource = dt.DefaultView;
            ddlCity.DataBind();

            if (ddlCity.Items.Count > 0)
            {
                this.ddlCity.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlCity.SelectedIndex = 0;

                this.ddlDistrict.Items.Clear();

                this.ddlDistrict.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlDistrict.SelectedIndex = 0;
            }

            
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDistrict.Items.Clear();
            Member mem = new Member();
            DataTable dt = new DataTable();
            dt = mem.GetDistrictView(this.ddlCity.SelectedItem.Value);
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "DistrictId";
            ddlDistrict.DataSource = dt.DefaultView;
            ddlDistrict.DataBind();

            if (ddlDistrict.Items.Count > 0)
            {
                this.ddlDistrict.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlDistrict.SelectedIndex = 0;
            }
        }

    }
}