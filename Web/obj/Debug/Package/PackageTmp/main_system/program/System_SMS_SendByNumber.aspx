<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_SMS_SendByNumber.aspx.cs" Inherits="Web.main_system.program.System_SMS_Send" %>

<HTML>
	<HEAD>
		<title>����ƽ̨</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	    <style type="text/css">
            #UploadFile
            {
                width: 226px;
            }
        </style>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>��ǰλ�ã�&nbsp;ϵͳ����&nbsp;&gt;&nbsp;����ƽ̨&nbsp;&gt;&nbsp;ʹ��ָ�����뷢��
				
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
								<td width="20" height="25"><img height="25" src="../../images/page/table_tit_l.gif" width="20"></td>
								<td class="title1" nowrap>�༭����</td>
								<td width="10"><img height="25" src="../../images/page/table_tit_r.gif" width="10"></td>
								<td width="99%" class="tdimages">
								</td>
							</tr>
						</table>
					</td>
					<td width="2"><img height="2" src="../../images/page/table_dot_r.gif" width="2"></td>
				</tr>
				<tr>
					<td>
						<table class="tableclass1" cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
								<td class="table_top"></td>
							</tr>
							<tr>
								<td>
									<table class="tableclass" id="SaleManagerList_Table" cellspacing="0" cellpadding="0" width="100%" align="center">
                                        <tr>
											<td class="table_iteam" align="right" width="164">�������ݣ�<br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
											<td colspan="3">&nbsp;
												<asp:FileUpload ID="File1" runat="server"/> 
                                                    &nbsp;
                                                    <asp:button id="BtnDaoru" runat="server"  text="�������" onclick="BtnDaoru_Click" 
                    ></asp:button>
                                                     
												</td>

                                         
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										
                                        <tr>
											<td class="table_iteam" align="right" width="164">�ֻ����룺<br />
                                                <br />
                                                <br />
                                                <br />
                                                �������Ӣ�ķֺš�;������ 
                                                <br />
                                            </td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtNumber" runat="server" width="430px" rows="4" 
                                                    textmode="MultiLine" Height="170px"></asp:textbox>
                                                    &nbsp;&nbsp;<asp:button id="BtnQuchong" runat="server"  text="ȥ���ظ�" onclick="BtnQuchong_Click"  
                    ></asp:button>
                                                     
												&nbsp;&nbsp;
                                                    <%--<asp:button id="BtnDaoru" runat="server"  text="�������" onclick="BtnDaoru_Click" 
                    ></asp:button>--%>
                                                     
												</td>

                                         
										</tr>
                                        <tr><td>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            </td></tr>
										<tr>
											<td class="table_iteam" align="right" width="164">
                                                ����ģ�棺
                                            </td>
											<td colspan="3">&nbsp;
                                                <asp:DropDownList ID="ddlTemp" runat="server" 
                                                    onselectedindexchanged="ddlTemp_SelectedIndexChanged" AutoPostBack="True" 
                                                    CausesValidation="True">
                                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                                                <asp:button id="btnSet" runat="server"  text="����" 
                                                    onclick="btnSet_Click" ></asp:button>
												&nbsp;&nbsp; <font color="blue">*��������ֻ����벻����ϵͳ�еĻ�Ա�벻Ҫʹ�ô���ͨ�����ģ�壬������Ž����ᷢ��</font></td>
										</tr>
                                        <tr><td>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            </td></tr>
										<tr>
											<td class="table_iteam" align="right" width="164">�������ݣ�<br />
&nbsp;<br />
                                                <br />
                                                <br />
                                                [70��һ��,�����������Ʒ�] 
                                                <br />
                                            </td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtContent" runat="server" width="430px" rows="4" 
                                                    textmode="MultiLine" Height="105px"></asp:textbox>
                                                    <font color="blue">&nbsp; *���δʹ��ģ�壬���������н�ֹ����#��</font>
												</td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr><td>&nbsp;</td></tr>
									</table>
									<asp:validationsummary id="vvsError" runat="server" showmessagebox="True" showsummary="False" displaymode="List"></asp:validationsummary>
								</td>
							</tr>
							<tr>
								<td class="table_bot"></td>
							</tr>
						</table>
					</td>
					<td valign="top" align="left" width="2" bgcolor="#bfbfbf"><img height="2" src="../../images/page/table_dot_r.gif" width="2"></td>
				</tr>
				<tr bgcolor="#bfbfbf">
					<td><img height="3" src="../../images/son/table_dot_l.gif" width="2"></td>
					<td width="2" height="3"></td>
				</tr>
			</table>
			<br/>
			<div align="center">
				<asp:button id="btnSend" runat="server"  text="�� ��" 
                    onclick="btnSend_Click"></asp:button>&nbsp;
<%--				<input class="button" id="btnCancel" name="btnCancel" value="ȡ ��" type="reset"/>&nbsp;--%>
				<br />
				&nbsp;
				</div>
		</form>
		<script src="../../js/PressEnter.js"></script>
	</body>
</HTML>