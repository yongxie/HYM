using System;
using System.Collections.Generic;
using System.Text;

namespace SMSAgent
{
    /// <summary>
    /// ResultMessage��Ŀ���Ƕ�Boolean������һ����չ
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
        /// ���������trueΪ�ɹ���falseΪʧ��
        /// </summary>
        public bool Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _message = "";
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
