using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.Text;
using DBUtil;
using System.Data;

namespace Web.main_system.program
{
    public partial class System_GroupAuthorization_Edit : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        public string addcontent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                //DBManager db = DBManager.Instance();
                //DataTable dt = db.GetDataTable("select * from Auth_Menu");

                //DataRow[] dRows = dt.Select("father = '0'");
                //for (int i = 0; i < dRows.Length; i++)
                //{
                //    sb.Append("                                                      <tr >    ");
                //    sb.Append("                                                        <td width=\"80\" align=\"right\" height=\"19px\">");

                //    sb.Append("                                                        </td>");
                //    sb.Append("                                                      </tr>");
                //    sb.Append("                                                      <tr >    ");
                //    sb.Append("                                                        <td width=\"80\" align=\"right\" height=\"19px\">");
                //    sb.Append("                                                            " + dRows[i]["description"].ToString());
                //    sb.Append("                                                        </td>");
                //    sb.Append("                                                      </tr>");




                //    DataRow[] dRows2 = dt.Select("father = '" + dRows[i]["ProgramId"].ToString() + "'");
                //    int r = dRows2.Length / 3;
                //    int y = dRows2.Length % 3;
                //    for (int j = 0; j <= r; j++)
                //    {
                //        sb.Append("                                                      <tr >    ");
                //        sb.Append("                                                        <td>");
                //        sb.Append("                                                            <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"left\">");
                //        sb.Append("                                                                <tr>");

                //        for (int k = 0; k < 3; k++)
                //        {
                //            if (j * 3 + k >= dRows2.Length)
                //            {
                //                break;
                //            }
                //            sb.Append("                                                                    <td width=\"130\" align=\"right\" height=\"19px\">" + dRows2[j * 3 + k]["description"] + "：</td>");
                //            sb.Append("                                                                    <td height=\"19px\">");
                //            sb.Append("                                                                        <asp:CheckBoxList id=\"cbl" + dRows2[j * 3 + k]["programid"] + "\" runat=\"server\" RepeatDirection=\"Horizontal\">");
                //            sb.Append("                                                                            <asp:ListItem Value=\"r\">读取</asp:ListItem>");
                //            sb.Append("                                                                            <asp:ListItem Value=\"m\">修改</asp:ListItem>");
                //            sb.Append("                                                                            <asp:ListItem Value=\"a\">新增</asp:ListItem>");
                //            sb.Append("                                                                            <asp:ListItem Value=\"d\">删除</asp:ListItem>");
                //            sb.Append("                                                                        </asp:CheckBoxList>");
                //            sb.Append("                                                                    </td>");
                //            sb.Append("								");
                //        }
                //        sb.Append("                                                                </tr>");
                //        sb.Append("                                                            </table>");
                //        sb.Append("                                                        </td>");
                //        sb.Append("                                                      </tr>");
                //    }


                //}
                //this.addcontent = sb.ToString();


                if (Request.QueryString["GroupID"] != null && Request.QueryString["GroupID"].ToString() != "")
                {
                    ViewState["GroupID"] = Request.QueryString["GroupID"].ToString();
                    FillDataToCtrl(true);			//填充数据到表单文本控件,下拉框控件
                    FillRightTable(ViewState["GroupID"].ToString());	//填充数据到权限表格
                    ViewState["OperateStatus"] = "EditData";				//置当前状态为编辑操作
                }
                else
                {
                    ViewState["GroupID"] = "";
                    FillDataToCtrl(false);
                    FillRightTable("");
                    ViewState["OperateStatus"] = "AddData";		//置当前状态为新增操作					
                    this.btnDelete.Visible = false;
                }
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0602");
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
            GroupAuthorizationDB clsGroupDB;		//创建用户权限表类对象			
            if (IsFill)
            {
                GroupAuthorization clsGroup = new GroupAuthorization();
                clsGroupDB = clsGroup.FindGroup((string)ViewState["GroupID"]);
                this.txtGroupID.Text = ViewState["GroupID"].ToString();
                this.txtGroupID.Enabled = false;
            }
            else
            {
                clsGroupDB = new GroupAuthorizationDB();
                this.txtGroupID.Text = "";
                this.txtGroupID.Enabled = true;
            }
            this.txtGroupName.Text = clsGroupDB.GroupName;
        }

        /// <summary>
        /// 生成用户权限表格
        /// </summary>
        /// <param name="UserID">用户代码ID</param>
        private void FillRightTable(string GroupID)
        {
            GroupAuthorization clsGroup = new GroupAuthorization();
            String[,] strProgram = clsGroup.ShowGroupRightInPrograms(ViewState["GroupID"].ToString());
            if (strProgram != null)
            {
                //生成表体部分
                int j = 0;
                CheckBoxList cblTmp;
                while (strProgram[j, 0] != null && strProgram[j, 0] != String.Empty)
                {
                    cblTmp = (CheckBoxList)FindControl("cbl" + strProgram[j, 0]);

                    //判断是否有权限，如果没有,则CheckBox为“未选”状态。
                    if (strProgram[j, 2] != null && strProgram[j, 2] != "")
                    {
                        if (strProgram[j, 2].IndexOf('r') != -1) 
                            cblTmp.Items[0].Selected = true;

                        if (strProgram[j, 2].IndexOf('m') != -1) 
                            cblTmp.Items[1].Selected = true;
                        
                        if (strProgram[j, 2].IndexOf('a') != -1) 
                            cblTmp.Items[2].Selected = true;
                        
                        if (strProgram[j, 2].IndexOf('d') != -1) 
                            cblTmp.Items[3].Selected = true;
                    }
                    j++;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //创建用户权限数据表操作类对象
                GroupAuthorization clsGroup = new GroupAuthorization();
                if (ViewState["OperateStatus"].ToString() == "EditData")
                {
                    //更新用户数据
                    clsGroup.UpdateGroup(
                        ViewState["GroupID"].ToString(),
                        this.txtGroupName.Text,
                        SaveTableData());
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "组权限设置", "修改用户组权限信息;组ID：" + ViewState["GroupID"].ToString());
                }
                else
                {
                    //新增用户组数据
                    clsGroup.AddGroup(
                        this.txtGroupID.Text,
                        this.txtGroupName.Text,
                        SaveTableData());
                    ViewState["OperateStatus"] = "EditData";
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "组权限设置", "新增用户组权限信息;组ID：" + this.txtGroupID.Text);
                }

                Server.Transfer("System_GroupAuthorization_Index.aspx");
            }
        }
        /// <summary>
        /// 存储用户权限字符串
        /// </summary>
        /// <returns>返回一个包含用户所有权限的字符串，如: 1000*rmad/1001*rmd/1002*rm,如果没有权限，返回为空字符串</returns>
        private string SaveTableData()
        {
            StringBuilder strRight = new StringBuilder();
            string[][] strTmp = new string[][] 
							{
                                //new string[] {"0202","0204","0206"},
                                //new string[] {"0402","0404","0406","0408"},
                                //new string[] {"0602","0604","0606","0608","0610","0612","0614"},
                                //new string[] {"1002","1004","1006"},
                                //new string[] {"1202","1204","1206","1208","1210","1212","1214"},
                                //new string[] {"1402","1404","1406","1408","1410"},
                                //new string[] {"1602","1604","1606","1608","1610","1612","1614","1616","1618"},
                                //new string[] {"1802","1804","1806"},
                                //new string[] {"2002","2004","2006"},
                                //new string[] {"0802","0806","0808","0810"},
								new string[] {"0101", "0102", "0103", "0104", "0201", "0202", "0203", "0301", "0302", "0303", "0401", "0402", "0403", "0501", "0502", "0503", "0504", "0505", "0601", "0602","0603","0604","0605","0607","0608","0609"}
							};

            CheckBoxList cblTmp;
            for (int i = 0; i < strTmp.Length; i++)
                for (int j = 0; j < strTmp[i].Length; j++)
                {
                    cblTmp = (CheckBoxList)FindControl("cbl" + strTmp[i][j]);
                    if (cblTmp != null)
                    {
                        strRight.Append(strTmp[i][j]);
                        strRight.Append("*");
                        if (cblTmp.Items[0].Selected)
                            strRight.Append("r");
                        if (cblTmp.Items[1].Selected)
                            strRight.Append("m");
                        if (cblTmp.Items[2].Selected)
                            strRight.Append("a");
                        if (cblTmp.Items[3].Selected)
                            strRight.Append("d");
                        strRight.Append("/");
                    }
                }
            strRight.Remove(strRight.Length - 1, 1);
            return strRight.ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_GroupAuthorization_Index.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GroupAuthorization clsGroup = new GroupAuthorization();
            clsGroup.DeleteGroup((string)ViewState["GroupID"]);
            //记录操作员操作
            RecordOperate.SaveRecord(Session["UserID"].ToString(), "组权限设置", "删除用户组权限信息");
            Server.Transfer("System_GroupAuthorization_Index.aspx");
        }

    }
}