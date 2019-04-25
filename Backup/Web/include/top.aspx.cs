using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using DBUtil;
using System.Data;
using System.Timers;

namespace Web.include
{
    public partial class top : System.Web.UI.Page
    {
        private HttpContext context;
        protected void Page_Load(object sender, EventArgs e)
        {
            //const string Day = "日一二三四五六";
            //this.lblMun.Text = DateTime.Today.Month.ToString();
            //this.lblDay.Text = DateTime.Today.Day.ToString();
            //this.lblZhou.Text = "星期" + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            string strSql = "select NewsContent from Sys_News where ShowOnSys='0'";
            DBManager db = DBManager.Instance();
            DataTable dt = db.GetDataTable(strSql);
            RptNews.DataSource = dt.DefaultView;
            RptNews.DataBind();

            //Timer time = new Timer(30000);//600000
            //time.Elapsed += new ElapsedEventHandler(time_Elapsed);
            //time.Enabled = true;
            //time.Start();


            
        }

        //void time_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    //绑定要在桌面显示的新闻信息
        //    string strSql = "select NewsContent from Sys_News where ShowOnSys='0'";
        //    DBManager db = DBManager.Instance();
        //    DataTable dt = db.GetDataTable(strSql);
        //    //RptNews.Items.
        //    RptNews.DataSource = dt.DefaultView;
        //    RptNews.DataBind();
        //    //throw new NotImplementedException();
        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            context = HttpContext.Current;
            string Url = context.Request.ApplicationPath + "include/main.aspx";
            context.Response.Write("<script languaer=javascript>top.main.navigate('" + Url + "');</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            context = HttpContext.Current;
            string Url = context.Request.ApplicationPath + "main_system/program/Sys_EditPassward.aspx";
            context.Response.Write("<script languaer=javascript>top.main.navigate('" + Url + "');</script>");
        }


    }
}