<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Web.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>详细信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	<link href="../../css/Default.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table id="Table1" style="z-index: 101; left: 32px; position: absolute; top: 32px"
        cellspacing="0" cellpadding="1" width="500" border="0">
        <tr>
            <td style="width: 120px">
                手机号码：
            </td>
            <td>
                <asp:TextBox ID="txtNum" runat="server" Width="410px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                短信内容：
            </td>
            <td>
                <asp:TextBox ID="txtMsg" runat="server" Width="410px" Height="120" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                发送时间：
            </td>
            <td>
                <asp:TextBox ID="txtTime" runat="server" Width="410px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                &nbsp;
            </td>
            <td align="right">
                <input type="submit" name="Submit" value="确 定" style="font-size: 12px; width: 83px;
                    cursor: hand; height: 25px" onclick="window.close()" id="Submit1">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
