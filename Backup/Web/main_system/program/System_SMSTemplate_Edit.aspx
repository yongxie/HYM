<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_SMSTemplate_Edit.aspx.cs"
    Inherits="Web.main_system.program.System_SMSTemplate_Edit" %>

<html>
<head>
    <title>��������ģ��</title>
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
                ��ǰλ�ã�&nbsp;ϵͳ����&nbsp;&gt;&nbsp;��������ģ��
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
                            ��������ģ��
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
                                        ģ�����ƣ�
                                    </td>
                                    <td width="186">
                                        &nbsp;
                                        <asp:TextBox ID="txtSMSTempName" runat="server" MaxLength="20"></asp:TextBox><font
                                            color="red">*
                                            <asp:RequiredFieldValidator ID="vrftxtGoodsID" runat="server" ErrorMessage="ϵͳ��ʾ��ģ�����Ʋ���Ϊ��"
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
                                        ģ�����ݣ�
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
                                        <font color="blue">����ģ��ͨ���˵����</font>
                                    </td>
                                    <td colspan="3">
                                        <font color="blue">ʹ��ͨ������ܿ���ʹ�������ݸ��������͸��ӷ��㣬���ϸ������¸�ʽ�������ã�ͨ������ִ�Сд��</font>
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
                                                &nbsp;&nbsp;&nbsp;��Ա���ţ�#CardID#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;��Ƭβ�ţ�#LCardID#
                                            </td>
                                        </tr>
                                        <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;��ǰ���ڣ�#Date#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;��ǰʱ�䣺#Time#
                                            </td>
                                        </tr>
                                        <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;��Ա������#Name#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;�˻���#Money# 
                                            </td>
                                        </tr>
                   <%--                     <tr height="30" align="left">
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;�˻�������#Dir#
                                            </td>
                                            <td width="200">
                                                &nbsp;&nbsp;&nbsp;�䶯��#TempMoney#
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
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="�� ��" OnClientClick="return ConfirmSave() "
            OnClick="btnSave_Click"></asp:Button>&nbsp;
        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="button"
            Text="ɾ ��" OnClientClick="return ConfirmDel() " OnClick="btnDelete_Click"></asp:Button>&nbsp;
        <asp:Button ID="Return" runat="server" CausesValidation="False" Text="�� ��" CssClass="button"
            OnClick="Return_Click"></asp:Button></div>
    </form>
    <script src="../../js/PressEnter.js"></script>
</body>
</html>
<script type="text/javascript">
    function ConfirmSave() {
        if (Page_ClientValidate()) {
            return confirm('ȷ��Ҫ������ѡ�����������');
        }
        else {
            return false;
        }
    }
    function ConfirmDel() {
        if (Page_ClientValidate()) {
            return confirm('ȷ��Ҫɾ����ѡ�����������');
        }
        else {
            return false;
        }
    }
</script>
