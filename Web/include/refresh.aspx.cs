using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtil;
using System.Data;

namespace Web.include
{
    public partial class refresh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //const string Day = "日一二三四五六";
            //this.lblMun.Text = DateTime.Today.Month.ToString();
            //this.lblDay.Text = DateTime.Today.Day.ToString();
            //this.lblZhou.Text = "星期" + Day[Convert.ToInt16(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").DayOfWeek)];
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
    }
}