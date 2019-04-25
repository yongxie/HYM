<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_SMS_GetLast.aspx.cs" Inherits="Web.main_system.program.System_SMS_GetLast" %>

<HTML>
	<HEAD>
		<title>会员信息</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;系统功能&nbsp;&gt;&nbsp;短信平台&nbsp;&gt;&nbsp;短信余量查询
				
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
								<td class="title1" nowrap>短信余量</td>
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
                                        
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="table_iteam" align="right" width="164">当前短信剩余量（条）：
                                            </td>
																						<td>&nbsp;
												<asp:Label id="lbLast" runat="server"></asp:Label></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
                                       
                                       
                                        <tr><td>&nbsp;</td></tr>
										
									</table>
									
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
				&nbsp;
<%--				<input class="button" id="btnCancel" name="btnCancel" value="取 消" type="reset"/>&nbsp;--%>
				&nbsp;
				</div>
		</form>
		<script src="../../js/PressEnter.js"></script>
	</body>
</HTML>