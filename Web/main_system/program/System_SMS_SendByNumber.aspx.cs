using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SMSAgent;
using UtilLib;
using DBUtil;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace Web.main_system.program
{
    public partial class System_SMS_Send : System.Web.UI.Page
    {
        private const string MobileNumPath = @"..\..\sysfile\mobilenum\";

        SMS sms = new SMS("ew4878","朕桦商贸","yuzhen0808");
        ResMsg res = new ResMsg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0501");
                btnSend.Enabled = clsRighter.Modify | clsRighter.Add;

                DBManager db = DBManager.Instance();
                string strSql = "select Id, TemplateName,TemplateContent from SMS_Template";
                //获取记录数据
                DataTable dt1 = db.GetDataTable(strSql);
                DataRow df = dt1.NewRow();
                df["TemplateName"] = "---自定义---";
                dt1.Rows.InsertAt(df, 0);
                ddlTemp.DataSource = dt1;
                ddlTemp.DataTextField = "TemplateName";
                ddlTemp.DataValueField = "Id";
                ddlTemp.DataBind();

                res = sms.GetAccount();
                if (res.Result == false)
                {
                    Common.ShowMsg("短信平台连接短信网关失败！请与短信提供商联系！");
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string strNumTemp = this.txtNumber.Text.Trim();
            string strContent = this.txtContent.Text;

            string[] strNums = strNumTemp.Split(';');
            string strCardId = "";
            string strCardLast = "";
            string strNowDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string strNowTime = DateTime.Now.Date.ToString("hh:MM:ss");
            string strMemName = "";
            string strMoney = "";

            if (strContent.Contains("#"))
            {
                DBManager db = DBManager.Instance();
                DataTable dt = db.GetDataTable(@"select a.mobile, a.MemName,a.cardid,b.account from mem a,mem_card b where a.CardId = b.CardId ");
                foreach (string num in strNums)
                {
                    if (num.Length != 11)
                        continue;
                    DataRow[] dr = dt.Select("mobile ='" + num + "'");
                    if (dr.Length > 0)
                    {
                        strCardId = dr[0]["cardid"].ToString();
                        strMemName = dr[0]["MemName"].ToString();
                        strMoney = dr[0]["account"].ToString();
                        strCardLast = strCardId.Substring(strCardId.Length - 4);

                        string strTemp = strContent;
                        strTemp.Replace("#CardID#", strCardId);
                        strTemp.Replace("#LCardID#", strCardLast);
                        strTemp.Replace("#Date#", strNowDate);
                        strTemp.Replace("#Time#", strNowTime);
                        strTemp.Replace("##Name#", strMemName);
                        strTemp.Replace("#Money#", strMoney);

                        res = sms.Send(num, strTemp);
                        SMSOperate.SaveRecord(num, strTemp);
                    }


                }
            }
            else
            {
                foreach (string num in strNums)
                {
                    if (num.Length != 11)
                        continue;
                    res = sms.Send(num, strContent);
                    SMSOperate.SaveRecord(num, strContent);
                }
            }

            //res = sms.Send(strNumTemp, strContent);
            Common.ShowMsg("短信发送操作已完成！");

            //RecordOperate.SaveRecord(Session["UserID"].ToString(), "短信平台", "使用系统数据发送短信;对象号码：" + strNumTemp + ";发送内容：" + strContent);
            //RecordOperate.SaveRecord(Session["UserID"].ToString(), "短信平台", "使用系统数据发送短信;对象号码：" + strNumTemp + ";"); 
            //SMSOperate.SaveRecord(strNumTemp,strContent);
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("../son_sms.aspx");
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            Server.Transfer("System_SMSTemplate_Edit.aspx");
        }

        protected void ddlTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTemp.SelectedIndex == 0)
            {
                txtContent.Text = "";
            }
            else
            {
                SMSTemplate sms = new SMSTemplate();
                SMSTemplateDB smsdb = new SMSTemplateDB();
                smsdb = sms.ShowTemp(ddlTemp.SelectedItem.Value.ToString());

                txtContent.Text = Common.CCToEmpty(smsdb.TemplateContent);
            }
        }

        protected void BtnDaoru_Click(object sender, EventArgs e)
        {

            string FileName = File1.PostedFile.FileName;
          

              
            HttpPostedFile hpf=File1.PostedFile;
                
            String fname=hpf.FileName;
                
            String f_name=fname.Substring(fname.LastIndexOf("\\")+1);

            StringBuilder sb = new StringBuilder();
            sb.Append(Server.MapPath(MobileNumPath) + "\\" + Path.GetFileName(hpf.FileName));
            //hpf.SaveAs(Server.MapPath(MobileNumPath) + "\\" + Path.GetFileName(hpf.FileName));
            hpf.SaveAs(sb.ToString());

            //Common.ShowMsg("上传成功！");
            if (!File.Exists(sb.ToString()))
            {
                Common.ShowMsg("文件为空！！");
                return;
            }
            using (StreamReader sr = File.OpenText(sb.ToString()))
            {
                StringBuilder strTemp = new StringBuilder();
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    strTemp.Append(input + ";");
                    //Console.WriteLine(input);
                }
                //Console.WriteLine("The   end   of   the   stream   has   been   reached. ");
                this.txtNumber.Text = strTemp.ToString();
                sr.Close();

                FileInfo fi = new FileInfo(sb.ToString());
                fi.Delete();
            } 
 





            //HttpFileCollection fc = Request.Files;
            // HttpPostedFile pf = fc[0];
            // if (pf.ContentLength > 0)
            // {
            //     //string split = TextBox1.Text;
            //     int sum = 0;
            //     StringBuilder sb = new StringBuilder();
            //     StreamReader sr = new StreamReader(pf.InputStream, Encoding.Default);
            //     while (!sr.EndOfStream)
            //     {
            //         string sa = sr.ReadLine();
                     
            //            sb.Append(sa);
            //             //sb.Append(";");
            //             if (iptolong("58.18.40.1") <= iptolong(sa) && iptolong(sa) <= iptolong("58.18.40.254"))
            //             {
            //                 sum++;
            //             }
                    
            //        sb.Append("<br>");
            //     }
            //     Response.Write("SUM:" + sum + "<br>");
            //     Response.Write(sb.ToString());




        }

        protected void BtnQuchong_Click(object sender, EventArgs e)
        {
            //string input = this.txtNumber.Text.Trim();
            //input = Regex.Replace(input + ";", @"(?:([^,]+,))(?=.*?\1)", "");
            //this.txtNumber.Text = input.Substring(0, input.Length - 1);
            this.txtNumber.Text = Quchong(this.txtNumber.Text.Trim());
        }


        private string Quchong(string strTemp)
        {
            string result = "";
            string str = strTemp;
            ArrayList list = array(str);
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    result += list[i];
                }
                else
                {
                    result += list[i] + ";";
                }
            }

            return result;
        }
        static ArrayList array(string str)
        {
            ArrayList aimArr = new ArrayList();
            ArrayList strArr = new ArrayList();
            string[] strs = str.Split(';');
            foreach (string s in strs)
            {
                strArr.Add(s);
            }
            for (int i = 0; i < strs.Length; i++)
            {
                if (!aimArr.Contains(strs[i]))
                {
                    aimArr.Add(strs[i]);
                }
            }
            return aimArr;
        }
    }
}