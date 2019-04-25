<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_EditPassward.aspx.cs"
    Inherits="Web.main_system.program.Sys_EditPassward" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>修改密码</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../../css/Default.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../js/Time_Popup.js"></script>
</head>
<body>
    <table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="center" align="middle" width="32">
                <img height="16" src="../../images/page/page_place.gif" width="16">
            </td>
            <td>
                当前位置：&nbsp;系统功能&nbsp;&gt;&nbsp;修改密码
            </td>
        </tr>
    </table>
    <br>
    <form id="form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="20" height="25">
                            <img height="25" src="../../images/page/table_tit_l.gif" width="20">
                        </td>
                        <td class="title1" nowrap>
                            修改密码
                        </td>
                        <td width="10">
                            <img height="25" src="../../images/page/table_tit_r.gif" width="10">
                        </td>
                        <td width="99%" class="tdimages">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2">
                <img height="2" src="../../images/page/table_dot_r.gif" width="2">
            </td>
        </tr>
        <tr>
            <td>
                <table class="tableclass1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="table_top">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="tableclass" id="SaleManagerList_Table" cellspacing="0" cellpadding="0"
                                width="100%" align="center">
                                <tr>
                                    <td class="tdh" align="right" width="200">
                                        用户名：
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                        <asp:Label ID="lblUserId" runat="server"></asp:Label>
                                    </td>
                                    &nbsp;
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdh" align="right" width="200">
                                        原密码：
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox><font color="red">*
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" errormessage="系统提示：原密码不能为空" display="None" controltovalidate="txtOldPwd"></asp:requiredfieldvalidator></font>
                                    </td>
                                    <td class="tdh" align="right" width="200">
                                        &nbsp;
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                    </td>
                                    <td class="tdh" align="right" width="200">
                                        &nbsp;
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdh" align="right" width="200">
                                        新密码：
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox><font color="red">*
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" errormessage="系统提示：新密码不能为空" display="None" controltovalidate="txtNewPwd"></asp:requiredfieldvalidator></font>
                                    </td>
                                    <td class="tdh" align="right" width="200">
                                        &nbsp;
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                    </td>
                                    <td class="tdh" align="right" width="200">
                                        &nbsp;
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdh" align="right" width="200">
                                        确认密码：
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                        <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox><font color="red">* </font>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtNewPwd2" ControlToValidate="txtNewPwd" 
                                            ErrorMessage="系统警告：两次密码输入不同！" Display="None"></asp:CompareValidator>
                                    </td>
                                    <td class="tdh" align="right" width="200">
                                        &nbsp;
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                    </td>
                                    <td class="tdh" align="right" width="200">
                                        &nbsp;
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdh" align="right" width="200">
                                    </td>
                                    <td class="tdh" align="right" width="89">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <asp:ValidationSummary ID="vvsError" runat="server" ShowMessageBox="True" ShowSummary="False"
                                DisplayMode="List"></asp:ValidationSummary>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_bot">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" align="left" width="2" bgcolor="#bfbfbf">
                <img height="2" src="../../images/page/table_dot_r.gif" width="2">
            </td>
        </tr>
        <tr bgcolor="#bfbfbf">
            <td>
                <img height="3" src="../../images/son/table_dot_l.gif" width="2">
            </td>
            <td width="2" height="3">
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="btnEdit" runat="server"  Text="修 改" OnClick="btnEdit_Click">
        </asp:Button>&nbsp; &nbsp;<br />
        <br />
        <br />
    </div>
    </form>
    <script src="../../js/PressEnter.js"></script>
</body>
</html>
