<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>购买源码QQ：800075827</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            overflow:hidden;
        }
        .STYLE3
        {
            color: #528311;
            font-size: 12px;
        }
        .STYLE4
        {
            color: #42870a;
            font-size: 12px;
        }
        .STYLE4 a
        {
            color:Gray;
            text-decoration:none;
        }
        .STYLE5 a
        {
            color:#60951C;
            text-decoration:none;
            vertical-align:super;
            font-weight:bolder;
        }
        .code
        {
            background-image: url(code.jpg);
            font-family: Arial;
            font-style: italic;
            color: Red;
            border: 0;
            padding: 2px 1px;
            letter-spacing: 1px;
            font-weight: bolder;
        }
        .unchanged
        {
            border: 0;
        }
        #input1
        {
            width: 54px;
        }
    </style>
    <script language="javascript" type="text/javascript">

        var code; //在全局 定义验证码  
        function createCode() {
            code = "";
            var codeLength = 6; //验证码的长度  
            var checkCode = document.getElementById("checkCode");
            var selectChar = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'); // 所有候选组成验证码的字符，当然也可以用中文的  

            for (var i = 0; i < codeLength; i++) {
                var charIndex = Math.floor(Math.random() * 36);
                code += selectChar[charIndex];
            }
            if (checkCode) {
                checkCode.className = "code";
                checkCode.value = code;
            }
        }

        function validate() {
            var inputCode = document.getElementById("input1").value;

            if (inputCode.length <= 0) {
                alert("请输入验证码！");
                return false;
            }
            else if (inputCode != code) {
                alert("验证码输入错误！");
                createCode(); //刷新验证码
                return false;
            }
            else {
                return true;
            }
        }  
         
    </script>
<script type="text/javascript" defer="defer">
    window.onload = function () {
        createCode();
        document.getElementById("txtPwd").value = "";
        document.getElementById("txtUserName").value = "";
        var a = document.getElementById("txtUserName").value;
        //alert(a);
    }
</script>
<script type="text/javascript">
    function Clear() {
        document.getElementById("txtUserName").value = "";
        document.getElementById("txtPwd").value = "";

        //var a = document.getElementById("txtCardID2").value;
        //alert(a);
    }
</script>
</head>
<body>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
    
        <tr>
            <td background="images/login/login_03.gif">
                <form id="form1" runat="server">
                <table width="862" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="266" background="images/login/login_04.gif">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="95">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <%--<td width="424" height="95" background="images/login/login_06.gif">
                                        &nbsp;
                                    </td>--%>
                                     <td class="STYLE5" width="424" height="95" align"left" background="images/login/login_06.gif">
                                        <a href="http://www.yijiayi777.com/" target="_blank"><font size="5">>>进入商城</font></a>
                                    </td>

                                    <td width="183" background="images/login/login_07.gif">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="30%" height="30">
                                                    <div align="center">
                                                        <span class="STYLE3">用户名</span></div>
                                                </td>
                                                <td width="70%" height="30">
                                                    <asp:TextBox ID="txtUserName" runat="server" Style="height: 18px; width: 130px; border: solid 1px #cadcb2;
                                                        font-size: 12px; color: #81b432;" AutoCompleteType="Disabled" autocomplete="off">admin</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30">
                                                    <div align="center">
                                                        <span class="STYLE3">密&nbsp;&nbsp;码</span></div>
                                                </td>
                                                <td height="30">
                                                    <asp:TextBox ID="txtPwd" runat="server" Style="height: 18px; width: 130px; border: solid 1px #cadcb2;
                                                        font-size: 12px; color: #81b432;" AutoCompleteType="Disabled" TextMode="Password">admin</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30">
                                                    <div align="center">
                                                        <span class="STYLE3">验证码</span></div>
                                                </td>
                                                <td height="30">
                                                    <input type="text" id="input1" runat="server" />
                                                    
                                                    <input type="button" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged"
                                                        style="width: 66px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <%--<td width="255" background="images/login/login_08.gif">
                                        &nbsp;
                                    </td>--%>
                                    <td class="STYLE5" width="255" align="right" background="images/login/login_08.gif">
                                        <a href="http://www.tszhsm.com" target="_blank"><font size="5">>>进入官网</font></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="247" valign="top" background="images/login/login_09.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="22%" height="30">
                                        &nbsp;
                                    </td>
                                    <td width="26%">
                                        &nbsp;
                                    </td>
                                    <td width="30%">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/login/dl.png" OnClientClick="return validate()"
                                           OnClick="btn_Login_Click" /> <%--OnClientClick="return validate()" --%>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/login/cz.png"
                                            OnClick="btn_Rest_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td width="22%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td height="30">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="46%" height="20">
                                                    &nbsp;
                                                </td>
                                                <td width="54%" class="STYLE4">
                                                    版本 V1.0.0
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br /><br /><br /><br /><br /><br />
                            <table style="float:right">
                                <tr>
                                    <td class="STYLE4">研发团队：<a href="http://www.tsxckj.com" target="_blank">星辰科技</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </form>
            </td>
        </tr>
    </table>
</body>
</html>
