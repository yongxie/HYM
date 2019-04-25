using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace SMSAgent
{
    public class SMS
    {
        private string strGatewayChannelUrlForNotice = "http://n.020sms.com/NOTICE.ewing?";
        /// <summary>
        /// 网关通道发送短信URL
        /// </summary>
        public string GatewayChannelUrlForNotice
        {
            get
            {
                return strGatewayChannelUrlForNotice;
            }
            set
            {
                strGatewayChannelUrlForNotice = value;
            }
        }

        //private string strGatewayChannelUrlForSendMsg = "http://113.108.232.61/YFMsg.asp?";
        private string strGatewayChannelUrlForSendMsg = "http://n.020sms.com/MSMSEND.ewing?";
        /// <summary>
        /// 网关通道发送短信URL
        /// </summary>
        public string GatewayChannelUrlForSendMsg
        {
            get
            {
                return strGatewayChannelUrlForSendMsg;
            }
            set
            {
                strGatewayChannelUrlForSendMsg = value;
            }
        }

        private string strGatewayChannelUrlForAccount = "http://n.020sms.com/ACCOUNT.ewing?";
        /// <summary>
        /// 网关通道查询余额URL
        /// </summary>
        public string GatewayChannelUrlForAccount
        {
            get
            {
                return strGatewayChannelUrlForAccount;
            }
            set
            {
                strGatewayChannelUrlForAccount = value;
            }
        }
        private string strGatewayChannelUrlForUpdatePwd = "http://n.020sms.com/UPDATEPASSWORD.ewing?";
        /// <summary>
        /// 网关通道修改密码URL
        /// </summary>
        public string GatewayChannelUrlForUpdatePwd
        {
            get
            {
                return strGatewayChannelUrlForUpdatePwd;
            }
            set
            {
                strGatewayChannelUrlForUpdatePwd = value;
            }
        }
        private string strGatewayChannelUrlForGetTime = "http://n.020sms.com/getTime.ewing?";
        /// <summary>
        /// 网关通道获取服务器系统时间URL
        /// </summary>
        public string GatewayChannelUrlForGetTime
        {
            get
            {
                return strGatewayChannelUrlForGetTime;
            }
            set
            {
                strGatewayChannelUrlForGetTime = value;
            }
        }
        private string strGatewayChannelUrlForGetMO = "http://n.020sms.com/MO.ewing?";
        /// <summary>
        /// 网关通道获取上行短信URL
        /// </summary>
        public string GatewayChannelUrlForGetMO
        {
            get
            {
                return strGatewayChannelUrlForGetMO;
            }
            set
            {
                strGatewayChannelUrlForGetMO = value;
            }
        }


        private string strGatewayChannelCode = "wbcs001";
        /// <summary>
        /// 网关通道用户代码
        /// </summary>
        public string GatewayChannelCode
        {
            get
            {
                return strGatewayChannelCode;
            }
            set
            {
                strGatewayChannelCode = value;
            }
        }

        private string strGatewayChannelUserName = "wbcs223";
        /// <summary>
        /// 网关通道会员卡号
        /// </summary>
        public string GatewayChannelUserName
        {
            get
            {
                return strGatewayChannelUserName;
            }
            set
            {
                strGatewayChannelUserName = value;
            }
        }
        private string strGatewayChannelPwd = "111222";
        /// <summary>
        /// 网关通道密码
        /// </summary>
        public string GatewayChannelPwd
        {
            get
            {
                return strGatewayChannelPwd;
            }
            set
            {
                strGatewayChannelPwd = value;
            }
        }

        private string strGatewayChannelExtno = "ewing";
        /// <summary>
        ///  接入扩展号(如没有回复功能时此项为空)
        /// </summary>
        public string GatewayChannelExtno
        {
            get
            {
                return strGatewayChannelExtno;
            }
            set
            {
                strGatewayChannelExtno = value;
            }
        }

        public SMS()
        { }
        public SMS(string code, string userid, string pwd)
        {
            this.strGatewayChannelCode = code;
            this.strGatewayChannelUserName = userid;
            this.strGatewayChannelPwd = pwd;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="tel">对方手机号</param>
        /// <param name="content">短信内容</param>
        /// <returns></returns>
        public ResMsg Send(string tel, string content)
        {
            //string sql = "select * from Sys_User where Tel=''";

            ResMsg res = new ResMsg();
            //if (tempid != "0")
            //{

            //}

            //编码
            string SmsMsg = System.Web.HttpUtility.UrlEncode(content, System.Text.Encoding.GetEncoding("utf-8"));

            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(this.strGatewayChannelUrlForSendMsg);
            sbTemp.AppendFormat("ECODE={0}&USERNAME={1}&PASSWORD={2}&EXTNO={3}&MOBILE={4}&CONTENT={5}",
                this.strGatewayChannelCode, this.strGatewayChannelUserName, this.strGatewayChannelPwd, "", tel, SmsMsg);

            // 用户调用
            //mToUrl = "http://113.108.232.61/YFMsg.asp?ECODE=ueasy&USERNAME=ueasy&PASSWORD=123456&EXTNO=&MOBILE=" + this.txtDirNumber.Text.Trim() + "&CONTENT=" + SmsMsg + "";
            ////mToUrl = "http://n.020sms.com/NOTICE.ewing?ECODE=ueasy&USERNAME=ueasy&PASSWORD=123456&EXTNO=&MOBILE=" + this.txtDirNumber.Text.Trim() + "&CONTENT=" + SmsMsg + "";

            res = Post(sbTemp.ToString());
            return res;
        }
        /// <summary>
        /// 获取系统消息
        /// </summary>
        /// <returns></returns>
        public ResMsg GetNotice()
        {
            ResMsg res = new ResMsg();
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(this.strGatewayChannelUrlForNotice);
            res = Post(sbTemp.ToString());
            return res;
        }

        /// <summary>
        /// 获取账户余额
        /// </summary>
        /// <returns></returns>
        public ResMsg GetAccount()
        {
            ResMsg res = new ResMsg();
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(this.strGatewayChannelUrlForAccount);
            sbTemp.AppendFormat("ECODE={0}&USERNAME={1}&PASSWORD={2}",
                this.strGatewayChannelCode, this.strGatewayChannelUserName, this.strGatewayChannelPwd);

            res = Post(sbTemp.ToString());
            return res;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ResMsg UpdatePwd(string oldpwd, string newpwd)
        {
            ResMsg res = new ResMsg();
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(this.strGatewayChannelUrlForUpdatePwd);
            sbTemp.AppendFormat("ECODE={0}&USERNAME={1}&PASSWORD={2}&NEWPASSWORD={3}",
                this.strGatewayChannelCode, this.strGatewayChannelUserName, oldpwd, newpwd);

            res = Post(sbTemp.ToString());
            return res;
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public ResMsg GetTime()
        {
            ResMsg res = new ResMsg();
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(this.strGatewayChannelUrlForGetTime);
            //sbTemp.AppendFormat("ECODE={0}&USERNAME={1}&PASSWORD={2}&NEWPASSWORD={3}",
            // this.strGatewayChannelCode, this.strGatewayChannelUserName, oldpwd, newpwd);

            //this.strGatewayChannelUrlForUpdatePwd += sbTemp;
            res = Post(sbTemp.ToString());
            return res;
        }
        /// <summary>
        /// 获取上行短信
        /// </summary>
        /// <returns></returns>
        public ResMsg GetMO(out DataTable dtMessageTemp)
        {
            ResMsg res = new ResMsg();
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(this.strGatewayChannelUrlForGetMO);
            sbTemp.AppendFormat("ECODE={0}&USERNAME={1}&PASSWORD={2}",
                this.strGatewayChannelCode, this.strGatewayChannelUserName, this.strGatewayChannelPwd);
            res = Post(sbTemp.ToString());


            DataTable dt = new DataTable();
            dt.Columns.Add("Extno");
            dt.Columns.Add("MobiNumber");
            dt.Columns.Add("Content");
            dt.Columns.Add("GetTime");
            if (res.Result == true && res.Message.Trim() != "0")
            {
                String temp = res.Message;
                // String temp = "8888|^|15027551295|^|宸ョ▼搴^|2012-08-20 10:28:38|#|8888|^|15027551295|^|宸ョ▼搴^|2012-08-20 10:28:38|#|8888|^|15027551295|^|鍥炬|^|2012-08-20 10:29:19|#|";
                string utf8String = temp;


                byte[] buffer1 = Encoding.Default.GetBytes(utf8String);
                byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Default, buffer1, 0, buffer1.Length);
                temp = Encoding.Default.GetString(buffer2, 0, buffer2.Length);


                string[] sArray = temp.Split(new string[] { "|#|" }, StringSplitOptions.RemoveEmptyEntries);


                foreach (string sArrayson in sArray)
                {
                    string[] sArrayson2 = sArrayson.Split(new string[] { "|^|" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sArrayson2.Length >= 4)
                    {
                        dt.Rows.Add(sArrayson2[0], sArrayson2[1], sArrayson2[2], sArrayson2[3]);
                    }
                }

            }
            dtMessageTemp = dt;

            return res;
        }

        public ResMsg Post(string urltemp)
        {
            ResMsg res = new ResMsg();
            string mRtv = "";		//引用的返回字符串
            try
            {
                System.Net.HttpWebResponse rs = (System.Net.HttpWebResponse)System.Net.HttpWebRequest.Create(urltemp).GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(rs.GetResponseStream(), System.Text.Encoding.Default);
                mRtv = sr.ReadToEnd();

            }
            catch (Exception ex)
            {
                res.Result = false;	//对 url http 请求的时候发生的错误  比如页面不存在 或者页面本身执行发生错误
                res.Message = ex.ToString();
                return res;
            }

            if (mRtv == "1")
            {
                res.Result = true;
                res.Message = "发送成功！";
            }
            else if (mRtv == "-1")
            {
                res.Result = false;
                res.Message = "不能初始化SO！";
            }
            else if (mRtv == "-2")
            {
                res.Result = false;
                res.Message = "网络不通！";
            }
            else if (mRtv == "-3")
            {
                res.Result = false;
                res.Message = "一次发送的手机号码过多！";
            }
            else if (mRtv == "-4")
            {
                res.Result = false;
                res.Message = "内容包含不合法文字！";
            }
            else if (mRtv == "-5")
            {
                res.Result = false;
                res.Message = "登录账户错误！";
            }
            else if (mRtv == "-6")
            {
                res.Result = false;
                res.Message = "通信数据传送失败！";
            }
            else if (mRtv == "-7")
            {
                res.Result = false;
                res.Message = "没有进行参数初始化！";
            }
            else if (mRtv == "-8")
            {
                res.Result = false;
                res.Message = "扩展号码长度不对！";
            }
            else if (mRtv == "-9")
            {
                res.Result = false;
                res.Message = "手机号码不合法！";
            }
            else if (mRtv == "-10")
            {
                res.Result = false;
                res.Message = "号码太长！";
            }
            else if (mRtv == "-11")
            {
                res.Result = false;
                res.Message = "内容太长！";
            }
            else if (mRtv == "-12")
            {
                res.Result = false;
                res.Message = "内部错误！";
            }
            else if (mRtv == "-13")
            {
                res.Result = false;
                res.Message = "余额不足！";
            }
            else if (mRtv == "-14")
            {
                res.Result = false;
                res.Message = "扩展号不正确！";
            }
            else if (mRtv == "-17")
            {
                res.Result = false;
                res.Message = "发送内容为空！";
            }
            else if (mRtv == "-19")
            {
                res.Result = false;
                res.Message = "没有找到该动作（不存在的url地址）！";
            }
            else if (mRtv == "-20")
            {
                res.Result = false;
                res.Message = "手机号格式不正确！";
            }
            else if (mRtv == "-50")
            {
                res.Result = false;
                res.Message = "配置参数错误！";
            }
            else if (mRtv == "-52")
            {
                res.Result = false;
                res.Message = "URL编码错误！";
            }
            else if (mRtv == "-53")
            {
                res.Result = false;
                res.Message = "参数大小写错误！";
            }

            else
            {
                res.Result = true;
                res.Message = mRtv;
            }
            return res;
        }
    }
}
