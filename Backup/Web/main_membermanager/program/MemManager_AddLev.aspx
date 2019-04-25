<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemManager_AddLev.aspx.cs" Inherits="Web.main_membermanager.program.MemManager_AddLev" %>

<HTML>
	<HEAD>
		<title>会员级别编辑</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;会员管理&nbsp;&gt;&nbsp;会员级别编辑
				
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
								<td class="title1" nowrap>会员级别编辑</td>
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
											<td class="tdh" align="right" width="144"></td>
											<td width="186">&nbsp;
												
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="tdh" align="right" width="144">会员级别名称：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtLevelName" runat="server" ></asp:textbox><font color="red">*
											
                                    <td class="tdh" align="right" width="89">会员级别状态：</td>
											<td>&nbsp;
                                                <asp:DropDownList ID="ddlEnbled" runat="server">
                                                </asp:DropDownList><font color="red">*</font>
                                            </td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="tdh" align="right" width="144" height="17"></td>
											<td width="186" height="17">&nbsp;
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;
                                          
										</tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr>
											<td class="tdh" align="right" width="144"></td>
											
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;
										</tr>
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
                <asp:button id="btnSave" runat="server" cssclass="button" text="保 存" OnClientClick="return confirm('你确定要保存所选择的数据项吗？')" 
                    onclick="btnSave_Click"></asp:button>&nbsp;
				<asp:button id="btnDelete" runat="server" causesvalidation="False" 
                    cssclass="button" text="删 除" OnClientClick="return confirm('你确定要删除所选择的数据项吗？')" onclick="btnDelete_Click"></asp:button>&nbsp;
				<asp:button id="Return" runat="server" causesvalidation="False" text="返回" 
                    cssclass="button" onclick="Return_Click"></asp:button></div>
		</form>
		<script src="../../js/PressEnter.js"></script>
	</body>
</HTML>