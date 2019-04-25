<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_SMSTemplate_Edit.aspx.cs"
    Inherits="Web.main_system.program.System_SMSTemplate_Edit" %>

<html>
<head>
    <title>新增短信模版</title>
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
                当前位置：&nbsp;系统功能&nbsp;&gt;&nbsp;新增短信模版
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
                            新增短信模版
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
                                    <td class="tdh" align="right" width="144">
                                        模版名称：
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                        <asp:TextBox ID="txtSMSTempName" runat="server" MaxLength="20"></asp:TextBox><font
                                            color="red">*
                                            <asp:RequiredFieldValidator ID="vrftxtGoodsID" runat="server" ErrorMessage="系统提示：模版名称不能为空"
                                                Display="None" ControlToValidate="txtSMSTempName"></asp:RequiredFieldValidator></font>
                                    </td>
                                    <td class="tdh" align="right" width="144">
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
                                    <td class="table_iteam" align="right" width="144">
                                        模版内容：
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                        <asp:TextBox ID="txtSMSContent" runat="server" Width="600px" Rows="8" TextMode="MultiLine"></asp:TextBox>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_iteam" align="right" width="144">
                                        <font color="blue">短信模版通配符说明：</font>
                                    </td>
                                    <td colspan="3">
                                        <font color="blue">使用通配符功能可以使短信内容更加灵活，发送更加方便，请严格按照以下格式进行设置（通配符区分大小写）</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table cellspacing="0" align="center" cellpadding="5" width="62%" border="1">
                                        <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;会员卡号：#CardID#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;卡片尾号：#LCardID#
                                            </td>
                                        </tr>
                                        <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;当前日期：#Date#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;当前时间：#Time#
                                            </td>
                                        </tr>
                                        <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;会员姓名：#Name#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;账户余额：#Money# 
                                            </td>
                                        </tr>
                   <%--                     <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;账户动作：#Dir#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;变动金额：#TempMoney#
                                            </td>
                                        </tr>--%>
                                    </table>
                                    </td>
                                    <td>
                                        &nbsp;
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
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保 存" OnClientClick="return ConfirmSave() "
            OnClick="btnSave_Click"></asp:Button>&nbsp;
        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="button"
            Text="删 除" OnClientClick="return ConfirmDel() " OnClick="btnDelete_Click"></asp:Button>&nbsp;
        <asp:Button ID="Return" runat="server" CausesValidation="False" Text="返 回" CssClass="button"
            OnClick="Return_Click"></asp:Button></div>
    </form>
    <script src="../../js/PressEnter.js"></script>
</body>
</html>
<script type="text/javascript">
    function ConfirmSave() {
        if (Page_ClientValidate()) {
            return confirm('确定要保存所选择的数据项吗？');
        }
        else {
            return false;
        }
    }
    function ConfirmDel() {
        if (Page_ClientValidate()) {
            return confirm('确定要删除所选择的数据项吗？');
        }
        else {
            return false;
        }
    }
</script>
