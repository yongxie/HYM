using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtil;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Web.include
{
    public partial class left_index : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        public string addcontent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();

            //DBManager db = DBManager.Instance();
            //DataTable dt = db.GetDataTable("select * from Auth_Menu");
            DataTable dtAuth = new DataTable();
            SqlCommand cmd = new SqlCommand("HYM_System_GroupAuthorization_ShowAllRightMenuInProc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@groupid", SqlDbType.NVarChar, 20);
            p1.SqlValue = Session["UserGroupID"].ToString();
            p1.Direction = ParameterDirection.Input;

            SqlParameter p5 = new SqlParameter("@retResult", SqlDbType.NVarChar, 100);
            p5.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(p1);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dtAuth);
            DataRow[] dRowsAuth = dtAuth.Select("a like '%r%'");
            //DataTable dtAuth2 = new DataTable();
            

            DataTable dtMenu = new DataTable();
            DBManager db = DBManager.Instance();
            dtMenu = db.GetDataTable("select * from Auth_Menu");
            DataRow[] dRowFatherMenu = dtMenu.Select("father = '0'");

            DataTable dtMenuTemp = new DataTable();
            //dtMenuTemp = dtFatherMenu.row
            dtMenuTemp.Columns.Add("programid");
            dtMenuTemp.Columns.Add("description");
            dtMenuTemp.Columns.Add("father");
            dtMenuTemp.Columns.Add("haveson");
            dtMenuTemp.Columns.Add("url");
            dtMenuTemp.Columns.Add("imgurl");

            for (int i = 0; i < dRowFatherMenu.Length; i++)
            {
                for(int j = 0; j < dRowsAuth.Length; j ++)
                {
                    if (dRowsAuth[j]["father"].ToString().Trim() == dRowFatherMenu[i]["programid"].ToString().Trim())
                    {
                        DataRow[] dRows = dtMenu.Select("programid ='" + dRowsAuth[j]["programid"].ToString().Trim() + "'");
                        if (dtMenuTemp.Select("programid = '" + dRowsAuth[j]["programid"].ToString().Trim() + "'").Length > 0)
                        {
                            continue;
                        }
                        else
                        {
                            dtMenuTemp.Rows.Add(dRows[0]["programid"].ToString(),
                                dRows[0]["description"].ToString(),
                                dRows[0]["father"].ToString(),
                                dRows[0]["haveson"].ToString(),
                                dRows[0]["url"].ToString(),
                                dRows[0]["imgurl"].ToString());
                        }

                        dRows = dtMenu.Select("programid ='" + dRowsAuth[j]["father"].ToString().Trim() + "'");
                        if (dtMenuTemp.Select("programid = '" + dRowsAuth[j]["father"].ToString().Trim() + "'").Length > 0)
                        {
                            continue;
                        }
                        else
                        {
                            dtMenuTemp.Rows.Add(dRows[0]["programid"].ToString(),
                                dRows[0]["description"].ToString(),
                                dRows[0]["father"].ToString(),
                                dRows[0]["haveson"].ToString(),
                                dRows[0]["url"].ToString(),
                                dRows[0]["imgurl"].ToString());
                        }
                    }
                }
                //if(dRowsAuth.c)
            }

                sb.Append("<table width=\"151\" height=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");


                DataRow[] dRowsTemp = dtMenuTemp.Select("father = '0'");
            for (int i = 0; i < dRowsTemp.Length; i++ )
            {
                sb.Append("										<tr>");
                sb.Append("											<TD id=\"outlooktitle" + i.ToString() + "\" onclick=\"switchoutlookBar(" + i.ToString() + ")\" noWrap align=\"middle\" name=\"outlooktitle" + i.ToString() + "\"><IMG onmouseover=\"makevisible(this,1)\" style=\"FILTER: alpha(opacity=100); CURSOR: hand\" onmouseout=\"makevisible(this,0)\"  width=\"151\" src=\"" +dRowsTemp[i]["ImgUrl"].ToString() +"\"></TD>");
                sb.Append("										</tr>");
                sb.Append("										<tr id=\"outlookdiv" +i.ToString() + "\" style=\"DISPLAY: none; WIDTH: 100%; HEIGHT: 0%\" name=\"outlookdiv" + i.ToString()+ "\">");
                sb.Append("											<td bgcolor=\"#EBF2E7\" style=\"background:url(../images/images/left_bg.gif) repeat-y 0 0;\">");
                sb.Append("												<DIV id=\"outlookdivin" +i.ToString() + "\" style=\"OVERFLOW: auto; WIDTH: 100%; HEIGHT: 100%\" name=\"outlookdivin" + i.ToString() + "\">");
                sb.Append("													<TABLE class=\"a9px\" width=\"90%\" align=\"center\">");
                sb.Append("														<TBODY>");
                sb.Append("															<TR>");
                sb.Append("																<TD width=\"10%\" height=\"4\"></TD>");
                sb.Append("																<TD width=\"90%\"></TD>");
                sb.Append("															</TR>");

                DataRow[] dRows2 = dtMenuTemp.Select("father = '" + dRowsTemp[i]["ProgramId"].ToString() + "'");
                for (int j = 0; j < dRows2.Length; j++)
                {
                    if (dRows2[j]["Description"].ToString() == "数据备份" || dRows2[j]["Description"].ToString() == "数据恢复")
                        continue;
                    sb.Append("															<TR>");
                    sb.Append("																<TD>&nbsp;</TD>");
                    sb.Append("																<TD><a href=\"" + dRows2[j]["Url"].ToString() + "\" target=\"main\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('Image11','','../images/images/top_dot.gif',1)\"><img src=\"../images/images/ico_1.gif\" name=\"Image11\" width=\"11\" height=\"11\" border=\"0\">");
                    sb.Append("																		" + dRows2[j]["Description"].ToString() +  "</a></TD>");

                    sb.Append("															</TR>");
                }
                sb.Append("														</TBODY>");
                sb.Append("													</TABLE>");
                sb.Append("												</DIV>");
                sb.Append("											</td>");
                sb.Append("										</tr>");
            }


            sb.Append("										<TR>");
            sb.Append("											<TD id=\"blankdiv\" vAlign=\"top\" align=\"middle\" name=\"blankdiv\">");
            sb.Append("												<DIV style=\"OVERFLOW: auto; WIDTH: 100%; HEIGHT: 100%\"></DIV>");
            sb.Append("											</TD>");
            sb.Append("										</TR>");
            sb.Append("									</table>");


            addcontent = sb.ToString();

       
        }
    }
}