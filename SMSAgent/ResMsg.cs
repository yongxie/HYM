using System;
using System.Collections.Generic;
using System.Text;

namespace SMSAgent
{
    /// <summary>
    /// ResultMessage，目的是对Boolean类型做一个扩展
    /// </summary>
    public class ResMsg
    {
        public ResMsg()
        {
        }
        public ResMsg(bool Result, string Message)
        {
            _result = Result;
            _message = Message;
        }
        private bool _result = true;
        /// <summary>
        /// 操作结果，true为成功；false为失败
        /// </summary>
        public bool Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _message = "";
        /// <summary>
        /// 操作信息
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
