<%@ Import Namespace="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_UserAuthorization_Admin.aspx.cs" Inherits="Web.main_system.program.System_UserAuthorization_Admin" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
		<title>ϵͳά��_�����û�Ȩ������</title>
		<%--/* ����������������Ϣע�ͣ���������������
          ��������ϵͳ����-�û�Ȩ�����ó���
          ��������������ϵͳ�û�Ȩ��
          �����˼�ʱ�䣺	Daniel��2002-10-28
          ����޸��˼�ʱ�䣺Daniel��2003-01-26
         ��������������������������������������*/--%>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../../css/default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
<body>
<form id="System_UserAuthorization_Admin" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="20" height="25">
										<p align="left"><IMG height="25" src="../../images/page/table_tit_l.gif" width="20"></p>
									</td>
									<td class="title1" noWrap>�û�Ȩ������</td>
									<td width="10"><IMG height="25" src="../../images/page/table_tit_r.gif" width="10"></td>
									<td class="tdimages" width="99%">&nbsp;</td>
								</tr>
							</table>
						</td>
						<td width="2"><IMG height="2" src="../../images/page/table_dot_r.gif" width="2"></td>
					</tr>
					<tr>
						<td>
							<table class="tableclass1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="table_top"></td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" id="T1" cellSpacing="0" cellPadding="0" width="100%" align="center">
											<tr>
												<td class="tdh" align="right" width="120">�� �� ����</td>
												<td width="220">&nbsp;
													<asp:textbox id="txtUserID" runat="server"  maxlength="20"></asp:textbox><font color="red">*
														<asp:requiredfieldvalidator id="vrftxtUserID" runat="server" errormessage="ϵͳ��ʾ���û���¼���벻��Ϊ��" display="None" controltovalidate="txtUserID"></asp:requiredfieldvalidator></font></td>
												<td class="tdh" align="right" width="120">�û����룺</td>
												<td><font color="red"><FONT color="#000000">&nbsp;
															<asp:textbox id="txtPassword" runat="server"  maxlength="20"></asp:textbox></FONT><FONT color="red">*
															<asp:requiredfieldvalidator id="vrftxtPassword" runat="server" errormessage="ϵͳ��ʾ���û����벻��Ϊ��" display="None" controltovalidate="txtPassword"></asp:requiredfieldvalidator></FONT></font></td>
											</tr>
                                            <tr><td>&nbsp;</td></tr>
											<tr>
												<td class="tdh" align="right" width="120">��ʵ������</td>
												<td width="220"><font color="red">&nbsp;
														<asp:textbox id="txtUserName" runat="server"  maxlength="20"></asp:textbox>&nbsp;<FONT color="red">
															</FONT></font></td>
												<td class="tdh" align="right" width="120">�������</td>
												<td>&nbsp;
													<asp:dropdownlist id="ddlGroupID" runat="server"></asp:dropdownlist></td>
												<TD class="tdh" align="right" width="120"></TD>
												<TD>&nbsp;</TD>
											</tr>
                                            <tr><td>&nbsp;</td></tr>
											<tr>
												<td class="tdh" align="right" width="120">��  ��</td>
												<td width="220">&nbsp;
													<asp:dropdownlist id="ddlSex" runat="server"></asp:dropdownlist></td>
												<td class="tdh" align="right" width="120">��  �䣺</td>
												<td>&nbsp;
													<asp:textbox id="txtAge" runat="server"  maxlength="20"></asp:textbox></td>
											</tr>
                                            <tr><td>&nbsp;</td></tr>
											<tr>
												<td class="tdh" align="right" width="120">��  ����</td>
												<td width="220"><font color="red">&nbsp;
													<asp:textbox id="txtTel" runat="server"  maxlength="20"></asp:textbox>&nbsp;</td>
												<td class="tdh" align="right" width="120">�ֻ����룺</td>
												<td>&nbsp;
													<asp:textbox id="txtMobile" runat="server"  maxlength="20" ></asp:textbox></td>
												<TD class="tdh" align="right" width="120"></TD>
												<TD>&nbsp;</TD>
											</tr>
                                            <tr><td>&nbsp;</td></tr>
                                            <tr>
												<td class="tdh" align="right" width="120">ְ  λ��</td>
												<td width="220">&nbsp;
													<asp:textbox id="txtJob" runat="server"  maxlength="20"></asp:textbox></td>
												<td class="tdh" align="right" width="120">�������ڣ�</td>
												<td>&nbsp;
													<asp:textbox id="txtBirthday" runat="server"  maxlength="20"></asp:textbox></td>
											</tr>
                                            <tr><td>&nbsp;</td></tr>
											<tr>
											<td class="tdh" align="right" width="120">סַ��</td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtAddr" runat="server" width="488px" rows="4"></asp:textbox>
												<asp:regularexpressionvalidator id="vretxtAddr" runat="server" 
                                                    validationexpression="(.|\n){0,300}" errormessage="ϵͳ��ʾ��סַ���ܳ���300���ַ�" 
                                                    display="None" controltovalidate="txtAddr"></asp:regularexpressionvalidator></td>
										    </tr>
                                            <tr><td>&nbsp;</td></tr>
											<tr>
												<td class="tdh" align="right" width="120">�ϼ�����Ա��</td>
												<td width="220">&nbsp;
													<asp:dropdownlist id="ddlFather" runat="server"></asp:dropdownlist>&nbsp;</td>
												<td class="tdh" align="right" width="120">�û�״̬��</td>
												<td>&nbsp;
													<asp:dropdownlist id="ddlStatus" runat="server"></asp:dropdownlist></td>
												<TD class="tdh" align="right" width="120"></TD>
												<TD>&nbsp;</TD>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td height="5"></td>
								</tr>

								<tr>
									<td class="table_bot"></td>
								</tr>
							</table>
						</td>
						<td vAlign="top" align="left" width="2" bgColor="#bfbfbf"><IMG height="2" src="../../images/page/table_dot_r.gif" width="2"></td>
					</tr>
					<tr bgColor="#bfbfbf">
						<td><IMG height="3" src="../../images/son/table_dot_l.gif" width="2"></td>
						<td width="2" height="3"></td>
					</tr>
				</table>
				<br>
                <asp:button id="btnSave" runat="server" cssclass="button" text="�� ��" OnClientClick="return ConfirmSave() " 
                    onclick="btnSave_Click"></asp:button>&nbsp;
				<asp:button id="btnDelete" runat="server" causesvalidation="False" 
                    cssclass="button" text="ɾ ��" OnClientClick="return ConfirmDel() " onclick="btnDelete_Click"></asp:button>&nbsp;
				<asp:button id="btnBack" runat="server" causesvalidation="False" text="����" 
                    cssclass="button" onclick="btnBack_Click"></asp:button>
                <br />
                <br />
                <br />
                <br />
            </div>
		</form>
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
