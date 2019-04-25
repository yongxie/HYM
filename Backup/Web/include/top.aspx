<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Web.include.top"
    CodePage="936" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Untitled Document</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../css/normal.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        <%--.top_botbg
        {
            background-position: 50% bottom;
            background-image: url(../images/index/top_botbg.gif);
            background-repeat: repeat-x;
        }--%>
        .help_bg
        {
            background-position: right 50%;
            background-image: url(../images/index/help_bg.gif);
            background-repeat: no-repeat;
        }
    </style>
    <%--<script Language=JavaScript>
    window.setTimeout('this.location.reload();', 5000);
 </script>
    --%>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <table style="width: 100%; height:60px; background: url(../images/images/botbg.gif) repeat-x;" cellpadding="5" cellspacing="0">
        <tr>
            <td rowspan="2" width="7%" height="55" valign="top">
                <asp:ImageButton ID="ImageButton1" width="153" height="55" runat="server" 
                     ImageUrl="../images/images/logo_1.gif" onclick="ImageButton1_Click" />
            </td>
            <td width="93%">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="5%" align="left"><img src="../images/images/titbar.gif"></td>
                    <td width="95%" align="right"><table border="0" cellpadding="0" cellspacing="0" align="right">
                    <tr>
                        <td>
                            <img src="../images/images/ico_1.gif" align="textTop">&nbsp;
                        </td>
                        <TD width=60 nowrap?><A href="main.aspx" target="main">我的桌面</A></TD>
                        <%--<TD>
										<img width="15" 
                  height="26" align="textTop" src="../images/index/top_dot1.gif"></TD>
										<td width="60" nowrap><a href="#" onclick="javascript:window.open('../main_help/index.html','','top=20,left=20,width=750,height=500')">帮助手册</a></td>
										<td><img src="../images/index/top_dot1.gif" width="15" height="26" align="textTop"></td>
										<td width="60" nowrap>常见问题</td>
										<td><img src="../images/index/top_dot1.gif" width="15" height="26" align="textTop"></td>
										<td width="60" nowrap><a href="../main_help/intro.htm" target=main>系统简介</a></td>--%>
                        <td>
                            <img src="../images/images/ico_1.gif" align="textTop">&nbsp;
                        </td>
                        <td width="60" nowrap>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">修改密码</asp:LinkButton>
                        </td>
                        <td>
                            <img src="../images/images/ico_1.gif" align="textTop">&nbsp;
                        </td>
                        <td width="80" nowrap>
                            <a href="javascript:window.showModalDialog('about.htm','','dialogwidth:467px;dialogheight:362px;help:no;status:no;scroll:no')">
                                关于系统说明</a>
                        </td>
                        <td>
                            <img src="../images/images/top_dot.gif" align="textTop">&nbsp;
                        </td>
                        <td width="30" nowrap>
                            <a href="#" onclick="javascript:top.window.navigate('/Default.aspx');"><font color="red">
                                退出</font></a>
                        </td>
                    </tr>
                </table></td>
                </tr>
            </table>
                
            </td>
        </tr>
        <tr>
            <td class="top_botbg" width="93%" >
                <div style="background: url(../images/images/top_notice.gif); left: 0px; width: 100%;
                    position: relative; top: 0px; height: 30px">
                    <div id="Layer1" style="z-index: 1; left: 15px; right:15px; overflow: hidden; width: 97%; position: absolute; top: 9px; height: 15px">
                        <asp:Label ID="lbl_sor" runat="server">
                            <marquee scrollamount="3" width="100%" onmouseover="this.stop()" onmouseout="this.start()">
                                <asp:Repeater ID="RptNews" runat="server"> 
                                    <ItemTemplate> 
                                       &nbsp;&nbsp;<%# Eval("NewsContent")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </ItemTemplate> 
                                </asp:Repeater>
                            </marquee>
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
