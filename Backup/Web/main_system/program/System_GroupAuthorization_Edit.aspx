<%@ Register TagPrefix="MyTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Import Namespace="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_GroupAuthorization_Edit.aspx.cs" Inherits="Web.main_system.program.System_GroupAuthorization_Edit" %>

<HTML>
	<HEAD>
		<title>ϵͳ����_�û���Ȩ��</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../../css/default.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="System_GroupAuthorization_Edit" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="20" height="25">
										<p align="left"><IMG height="25" src="../../images/page/table_tit_l.gif" width="20"></p>
									</td>
									<td class="title1" noWrap>�û���Ȩ������</td>
									<td width="10"><IMG height="25" src="../../images/page/table_tit_r.gif" width="10"></td>
									<td class="tdimages" width="99%">&nbsp;</td>
								</tr>
							</table>
						</td>
						<td width="2"><IMG src="../../images/page/table_dot_r.gif" width="2" 
                                style="height: 2px"></td>
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
												<td class="tdh" align="right" width="123">�û�����룺</td>
												<td width="201">&nbsp;
													<asp:textbox id="txtGroupID" runat="server"  maxlength="20"></asp:textbox><font color="red">*
														<asp:requiredfieldvalidator id="vrftxtGroupID" runat="server" errormessage="ϵͳ��ʾ���û�����벻��Ϊ��" display="None" controltovalidate="txtGroupID"></asp:requiredfieldvalidator></font></td>
												<td class="tdh" align="right" width="122">�û������ƣ�</td>
												<td>&nbsp;
													<asp:textbox id="txtGroupName" runat="server"  maxlength="50"></asp:textbox>&nbsp;<font color="red">*
														<asp:validationsummary id="vvsError" runat="server" showmessagebox="True" showsummary="False" displaymode="List"></asp:validationsummary><asp:requiredfieldvalidator id="vrftxtGroupName" runat="server" errormessage="ϵͳ��ʾ���û������Ʋ���Ϊ��" display="None"
															controltovalidate="txtGroupName"></asp:requiredfieldvalidator></font></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" cellSpacing="0" cellPadding="0" width="100%" align="center">
							            			  <tr bgColor="#bdd7ad">
												<td>
													<table cellSpacing="0" cellPadding="0" align="left" border="0">
														<tr>
															<td>
																<table border="0">
																	<tr>
																		<td><input id="chkRead" onclick="CheckedAll(0)" type="checkbox" name="chkRead"><label for="chkRead">��ȡ</label></td>
																		<td><input id="chkModify" onclick="CheckedAll(1)" type="checkbox" name="chkModify"><label for="chkModify">�޸�</label></td>
																		<td><input id="chkAdd" onclick="CheckedAll(2)" type="checkbox" name="chkAdd"><label for="chkAdd">����</label></td>
																		<td><input id="chkDelete" onclick="CheckedAll(3)" type="checkbox" name="chkDelete"><label for="chkDelete">ɾ��</label></td>
																	</tr>
																</table>
															</td>
															<td>
																<table border="0">
																	<tr>
																		<td><input id="chkSuper" onclick="CheckedAll(9)" type="checkbox" name="chkSuper"><label for="chkSuper">����Ȩ��</label></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;���ѹ���</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ա���ѣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0101" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ա��ֵ��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0102" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ���Ѽ�¼��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0103" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;��Ա����</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ա¼�룺
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0201" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ա��ѯ��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0202" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ա����
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0203" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;��Ʒ����</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ʒ¼�룺
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0301" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ʒ��ѯ��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0302" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ʒ���ࣺ
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0303" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;ͳ�Ʒ�����</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ��Աͳ�ƣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0401" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��������ͳ�ƣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0402" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ա����ͳ�ƣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0403" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;����ƽ̨��</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ָ�����뷢�ͣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0501" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ϵͳ���ݷ��ͣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0502" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��ѯ����������
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0503" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ���ŷ��ͼ�¼��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0504" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ����ģ�����
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0505" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;ϵͳ���ܣ�</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                �û�����
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0601" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ��Ȩ�����ã�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0602" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ���ݱ��ݣ�
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0603" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ���ݻָ���
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0604" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                ϵͳ��־��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0605" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                �޸����룺
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0607" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                ���Ŷ�̬��
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0608" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px" >
                                                                ���ⷴ����
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0609" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">��ȡ</asp:ListItem>
                                                                    <asp:ListItem Value="m">�޸�</asp:ListItem>
                                                                    <asp:ListItem Value="a">����</asp:ListItem>
                                                                    <asp:ListItem Value="d">ɾ��</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                                                                                   <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                                                                                 <%-- <%=addcontent %>--%>
										</table>
									</td>
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
			
				<asp:button id="btnSave" runat="server" cssclass="button" text="�� ��" OnClientClick="return ConfirmSave()" 
                    onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:button id="btnDelete" runat="server" cssclass="button" text="ɾ ��" OnClientClick="return ConfirmDel()" onclick="btnDelete_Click" 
                    ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="btnBack" runat="server" Text="�� ��" CssClass="button" 
                    CausesValidation="False" onclick="btnBack_Click"></asp:button></div>
		</form>
		<script type="text/javascript" language="javascript">
		    function CheckedAll(intItem) {
		        var chkID = new Array();
		        chkID[0] = new Array("0101", "0102", "0103", "0201", "0202", "0203", "0301", "0302", "0303", "0401", "0402", "0403", "0501", "0502", "0503", "0504", "0505", "0601", "0602","0603","0604","0605","0607","0608","0609");
//		        chkID[1] = new Array("0402", "0404", "0406", "0408");
//		        chkID[2] = new Array("0602", "0604", "0606", "0608", "0610", "0612", "0614");
//		        chkID[3] = new Array("1002", "1004", "1006");
//		        chkID[4] = new Array("1202", "1204", "1206", "1208", "1210", "1212", "1214");
//		        chkID[5] = new Array("1402", "1404", "1406", "1408", "1410");
//		        chkID[6] = new Array("1602", "1604", "1606", "1608", "1610", "1612", "1614", "1616", "1618");
//		        chkID[7] = new Array("1802", "1804", "1806");
//		        chkID[8] = new Array("2002", "2004", "2006");
//		        chkID[9] = new Array("0802", "0806", "0808", "0810");
//		        chkID[10] = new Array("2202", "2204", "2206", "2208");
		        //var iSelect = document.all["tsVert"].selectedIndex;
		        if (intItem == 0) {
		            for (var i = 0; i < chkID[0].length; i++)
		                document.all["cbl" + chkID[0][i] + "_0"].checked = document.all["chkRead"].checked;
		        }
		        else if (intItem == 1) {
		            if (document.all["chkModify"].checked) {
		                for (var i = 0; i < chkID[0].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_0"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[0].length; i++)
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = false;
		            }
		        }
		        else if (intItem == 2) {
		            if (document.all["chkAdd"].checked) {
		                for (var i = 0; i < chkID[0].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["chkModify"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_0"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_2"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[0].length; i++)
		                    document.all["cbl" + chkID[0][i] + "_2"].checked = false;
		            }
		        }
		        else if (intItem == 3) {
		            if (document.all["chkDelete"].checked) {
		                for (var i = 0; i < chkID[0].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["chkModify"].checked = true;
		                    document.all["chkAdd"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_0"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_2"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_3"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[0].length; i++)
		                    document.all["cbl" + chkID[0][i] + "_3"].checked = false;
		            }
		        }
		        else if (intItem == 8) {
		            var blnChk = document.all["chkSubAll"].checked;
		            document.all["chkRead"].checked = blnChk;
		            document.all["chkModify"].checked = blnChk;
		            document.all["chkAdd"].checked = blnChk;
		            document.all["chkDelete"].checked = blnChk;
		            for (var i = 0; i < chkID[0].length; i++) {
		                document.all["cbl" + chkID[0][i] + "_0"].checked = blnChk;
		                document.all["cbl" + chkID[0][i] + "_1"].checked = blnChk;
		                document.all["cbl" + chkID[0][i] + "_2"].checked = blnChk;
		                document.all["cbl" + chkID[0][i] + "_3"].checked = blnChk;
		            }
		        }
		        else if (intItem == 9) {
		            var blnChk = document.all["chkSuper"].checked;
		            document.all["chkRead"].checked = blnChk;
		            document.all["chkModify"].checked = blnChk;
		            document.all["chkAdd"].checked = blnChk;
		            document.all["chkDelete"].checked = blnChk;
		            //document.all["chkSubAll"].checked = blnChk;
		            for (var i = 0; i < chkID.length; i++) {
		                for (var j = 0; j < chkID[i].length; j++) {
		                    document.all["cbl" + chkID[i][j] + "_0"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + "_1"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + "_2"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + "_3"].checked = blnChk;
		                }
		            }
		        }
		        return true;
		    }
		</script>
	</body>
</HTML>
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