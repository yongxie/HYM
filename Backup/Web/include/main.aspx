<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Web.include.main"
    CodePage="936" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>我的桌面</title>
    <style type="text/css"> 
    .px_14 { font-size: 14px; font-weight: normal; color: #006600; text-decoration: none; font-family: "宋体"}
	p { font-size: 12px; text-indent: 10px}
	td { font-size: 12px}
	<%--body {margin:0px;background-image:url(../images/son/main_bg.jpg);background-repeat:no-repeat;}--%>
	a:link {color: #006600;text-decoration: none;}
	a:hover{color: #666666;text-decoration: underline;}
	a{font-size: 14px;vertical-align: text-bottom;color: #006600;font-family: 宋体; text-decoration: none;}
	</style>
</head>
<body style="margin: 0px;">
    <form id="form2" runat="server">
    <table border="0" cellspacing="30" cellpadding="0" width="99%" id="Table4">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <font color="green">通过下面的快捷方式，直接进行操作。</font>
            </td>
        </tr>
    </table>
    <table width="99%" height="83%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="100%" align="center" valign="middle">
                <table border="0" cellspacing="30" cellpadding="0" width="100%" id="Table5" style="overflow: auto;">
                    <tr align="middle">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <a href="../main_paymanager/program/gouwu.aspx">
                                <img name="img1" src="../images/son/xiaofei.gif" border="0" width="80" height="80"><p>
                                </p>
                                会员消费</a>
                        </td>
                        <td>
                            <a href="../main_paymanager/program/inputmoney.aspx">
                                <img name="img1" src="../images/son/chongzhi.gif" border="0" width="80" height="80"><p>
                                </p>
                                会员充值</a>
                        </td>
                        <td>
                            <a href="../main_membermanager/program/MemManager_Edit.aspx">
                                <img name="img1" src="../images/son/vipluru.gif" border="0" width="80" height="80"><p>
                                </p>
                                会员录入</a>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="30" cellpadding="0" width="100%" id="Table6">
                    <tr align="middle">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <a href="../main_membermanager/program/MemManager_View.aspx">
                                <img name="img1" src="../images/son/vipchaxun.gif" border="0" width="80" height="80"><p>
                                </p>
                                会员查询</a>
                        </td>
                        <td>
                            <a href="../main_tongji/program/Tongji_Mem_View.aspx">
                                <img name="img1" src="../images/son/shangpinluru.gif" border="0" width="80" height="80"><p>
                                </p>
                                会员统计</a>
                        </td>
                        <td>
                            <a href="../main_goodsmanager/program/GoodsManager_View.aspx">
                                <img name="img1" src="../images/son/shangpinchaxun.gif" border="0" width="80" height="80"><p>
                                </p>
                                商品查询</a>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <%--<table border="0" cellspacing="00" cellpadding="0" width="100%">
        <tr>
            <td style="width:8px; background-color: #F0F0F0;">
            </td>
            <td style="width:8px; background-color: #F0F0F0;">
            </td>
        </tr>
        <tr>
            <td>
                <form id="form1" runat="server">
                <table border="0" cellspacing="30" cellpadding="0" width="99%" id="Table2">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <font color="green">通过下面的快捷方式，直接进行操作。</font>
                        </td>
                    </tr>
                </table>
                <table width="99%" height="83%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="100%" align="center" valign="middle">
                            <table border="0" cellspacing="30" cellpadding="0" width="100%" id="Table3">
                                <tr align="middle">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <a href="../main_paymanager/program/gouwu.aspx">
                                            <img name="img1" src="../images/son/xiaofei.gif" border="0" width="80" height="80"><p>
                                            </p>
                                            会员消费</a>
                                    </td>
                                    <td>
                                        <a href="../main_paymanager/program/inputmoney.aspx">
                                            <img name="img1" src="../images/son/chongzhi.gif" border="0" width="80" height="80"><p>
                                            </p>
                                            会员充值</a>
                                    </td>
                                    <td>
                                        <a href="../main_membermanager/program/MemManager_Edit.aspx">
                                            <img name="img1" src="../images/son/vipluru.gif" border="0" width="80" height="80"><p>
                                            </p>
                                            会员录入</a>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellspacing="30" cellpadding="0" width="100%" id="Table1">
                                <tr align="middle">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <a href="../main_membermanager/program/MemManager_View.aspx">
                                            <img name="img1" src="../images/son/vipchaxun.gif" border="0" width="80" height="80"><p>
                                            </p>
                                            会员查询</a>
                                    </td>
                                    <td>
                                        <a href="../main_goodsmanager/program/GoodsManager_Edit.aspx">
                                            <img name="img1" src="../images/son/shangpinluru.gif" border="0" width="80" height="80"><p>
                                            </p>
                                            商品录入</a>
                                    </td>
                                    <td>
                                        <a href="../main_goodsmanager/program/GoodsManager_View.aspx">
                                            <img name="img1" src="../images/son/shangpinchaxun.gif" border="0" width="80" height="80"><p>
                                            </p>
                                            商品查询</a>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </form>
            </td>
            <td style="width:8px; background-color: #F0F0F0;">
            </td>
        </tr>
        <tr>
            <td style="width:8px; background-color: #F0F0F0;">
            </td>
            <td style="width:8px; background-color: #F0F0F0;">
            </td>
        </tr>
    </table>--%>
</body>
</html>
