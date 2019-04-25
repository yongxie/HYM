<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inputmoney.aspx.cs" Inherits="Web.main_paymanager.program.inputmoney" %>

<HTML>
	<HEAD>
		<title>会员卡充值</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;消费管理&nbsp;&gt;&nbsp;会员充值
				
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
								<td class="title1" nowrap>会员充值</td>
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
                                    <%--<table class="tableclass" id="SaleManagerList_Table" cellspacing="0" cellpadding="0" width="100%" align="center">
										<tr>
											<td class="tdh" align="right" width="144"></td>
											<td width="186">&nbsp;</td>
												
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;</td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="tdh" align="right" width="144">会员卡号：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtCardID" runat="server" ></asp:textbox><font color="red">*</td>
                                    <td class="tdh" align="right" width="89">充值金额：</td>
											<td>&nbsp;
												<asp:textbox id="txtMoney" runat="server"  maxlength="20"></asp:textbox><font color="red">*</font></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>

											<td class="tdh" align="right" width="144" height="17">会员卡号：</td>
											<td width="186" height="17"><asp:Label id="lbCardID" runat="server" Width="100px" TabIndex="25" >&nbsp;&nbsp;</asp:Label></td>
											<td class="tdh" align="right" width="89">会员姓名：</td>
											<td><asp:Label id="lbUserName" runat="server" Width="100px" TabIndex="27" >&nbsp;&nbsp;</asp:Label>&nbsp;</td>
                                          
										</tr>
                                        <tr><td>&nbsp;</td></tr>

                                        <tr>
											<td class="tdh" align="right" width="144"></td>
											
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;</td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
									</table>
--%>
<table class="tableclass2" cellspacing="0" cellpadding="0" width="100%" border="0">
<tr>
									<td class="table_top2"></td>
								</tr>
                                <tr>
									<td class="tdimages" width="99%" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    会员卡号：<asp:TextBox id="txtCardID2" runat="server" Width="100px" 
                                            AutoCompleteType="Disabled" autocomplete="off" onfocus="return clear()"  ></asp:TextBox>&nbsp;&nbsp;
                                    
                                     <asp:Button ID="btnShuaka" runat="server" Text="查询" onclick="btnShuaka_Click" 
                                            TabIndex="2"/>
                                      &nbsp;&nbsp;
                                     <asp:Button ID="btnClear" runat="server" Text="清空" onclick="btnClear_Click" 
                                             TabIndex="3"  />&nbsp;&nbsp;
                                    &nbsp;&nbsp;
                                     <br />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                    
                                    </td>
								</tr>


                                <tr>
									<td class="tdimages" width="99%" align="left"><br /><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    会员卡号：<asp:Label id="lbCardID" runat="server" Width="100px" TabIndex="25" >&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;
                                        &nbsp;&nbsp;
                                      &nbsp;&nbsp;
                                     <br /><br /><br />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    会员姓名：<asp:Label id="lbUserName" runat="server" Width="100px" TabIndex="27" >&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;
                                    余额：<asp:Label id="lbAccount" runat="server" Width="100px" TabIndex="26" >&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;
                                    <br /><br /><br />
                                    </td>

								</tr>
                                 <tr>
									<td class="tdimages" width="99%" align="left"><br /><br /><br />





                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 账户操作：


                                    
                                    <asp:dropdownlist id="ddlOperate" Name="ddlOperate" runat="server" Width="100px" TabIndex="4"  ></asp:dropdownlist>
                                                                    <div class="Info" id="Info" style="width:100px; border:solid 1px Black; display:none;">
                                    </div>&nbsp;&nbsp;

                                    金额：<asp:TextBox id="txtMoney" runat="server" Width="100px" TabIndex="5" ></asp:TextBox>&nbsp;&nbsp;
                                     <asp:Button ID="btnSave" runat="server" Text="确定" onclick="btnSave_Click" 
                                            TabIndex="6"/>   
                                     <br /><br /><br />

                                    <br /><br />
                                    </td>
								</tr>

                                <tr>
									<td class="table_top2"></td>
								</tr>

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
				&nbsp;			&nbsp;<br />
                    <br /><br />
				</div>
		</form>
		<script src="../../js/PressEnter.js"></script>
	</body>
</HTML>