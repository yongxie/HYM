<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tongji_AgentMonth_View.aspx.cs" Inherits="Web.main_tongji.program.Tongji_Agent_View" %>

<html>
	<head>
		<title>统计分析_部门消费按月统计</title>
		<%--/* ＊＊＊＊＊程序信息注释＊＊＊＊＊＊＊＊
          程序名：会员管理_代理商按月查询程序
          程序描述：代理商按月查询程序
         ＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊*/--%>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
		<link href="../../css/Default.css" type="text/css" rel="stylesheet"/>
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</head>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;统计分析&nbsp;&gt;&nbsp;部门消费按月统计&nbsp;
				</td>
			</tr>
		</table>
		<br/>
		<form id="System_RecordOperate_View" method="post" runat="server">
			<div align="center">
				<table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
					<tr>
						<td>
							<table cellspacing="0" cellpadding="0" width="100%" border="0">
								<tr>
									<td width="20" height="25"><img height="25" src="../../images/page/table_tit_l2.gif" width="20"></td>
									<td class="title2" nowrap>部门消费按月统计</td>
									<td width="10"><img height="25" src="../../images/page/table_tit_r2.gif" width="10"></td>
                                    <td class="tdimages" width="99%" align="right">
                                    代理商ID：<asp:TextBox id="txtUserId" runat="server" Width="80px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    代理商姓名：<asp:DropDownList id="ddlUserName" runat="server" DESIGNTIMEDRAGDROP="70"></asp:DropDownList>&nbsp;&nbsp;

                                        &nbsp;&nbsp;起始时间：<asp:TextBox id="txtBeginDate" runat="server" Width="80px" >&nbsp;&nbsp;</asp:TextBox><IMG style="CURSOR: hand" onclick="fPopUpCalendarDlg(txtBeginDate);return false" alt="" src="../../images/button/datetime.gif" align="absMiddle">
										<asp:CompareValidator id="vcvtxtBeginDate" runat="server" Display="None" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtBeginDate" ErrorMessage="系统提示：起始日期必须填写正确的日期格式！"></asp:CompareValidator>
										&nbsp;&nbsp;结束时间：<asp:TextBox id="txtEndDate" runat="server" Width="80px" >&nbsp;&nbsp;</asp:TextBox><IMG style="CURSOR: hand" onclick="fPopUpCalendarDlg(txtEndDate);return false" alt="" src="../../images/button/datetime.gif" align="absMiddle">
										<asp:CompareValidator id="vcvtxtEndDate" runat="server" Display="None" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtEndDate" ErrorMessage="系统提示：结束日期必须填写正确的日期格式！"></asp:CompareValidator>
                                        &nbsp;&nbsp;
                                        <asp:validationsummary id="vvsError" runat="server" displaymode="List" showsummary="False" showmessagebox="True"></asp:validationsummary>
										<asp:Button id="btnCha"  runat="server" Text="查  询" CssClass="button"
                                         onclick="btnCha_Click" ></asp:Button></td>
								</tr>
							</table>
						</td>
						<td width="2"><img height="2" src="../../images/page/table_dot_r2.gif" width="2"></td>
					</tr>
					<tr>
						<td>
							<table class="tableclass2" cellspacing="0" cellpadding="0" width="100%" border="0">
								<tr>
									<td class="table_top2"></td>
								</tr>
								<tr>
									<td><asp:datagrid id="MyDataGrid" runat="server" gridlines="Horizontal" 
                                            cssclass="tableclass" width="100%" 
                                            cellpadding="4" allowpaging="True" pagesize="20" autogeneratecolumns="False" 
                                            pagerstyle-visible="False" 
                                            ForeColor="#333333" BorderColor="Gray" BorderWidth="1px">
											<SelectedItemStyle ForeColor="#333333" BackColor="#C5BBAF" Font-Bold="True"></SelectedItemStyle>
											<ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" 
                                                BackColor="#E3EAEB"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" 
                                                BackColor="#1C5E55" Font-Bold="True"></HeaderStyle>
											<EditItemStyle BackColor="#7C6F57" />
											<FooterStyle ForeColor="White" BackColor="#1C5E55" Font-Bold="True"></FooterStyle>
											<AlternatingItemStyle BackColor="White" />
											<Columns>
												<asp:TemplateColumn HeaderText="行号">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>' ID="Label5">
														</asp:Label>
														<%--<input type = "hidden" name="hidControl5" value='<%# DataBinder.Eval(Container, "DataItem.MemID") %>' runat="server" id="hidControl5"/>--%>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="代理商ID">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserId") %>' CausesValidation="False" ID="Linkbutton2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="代理商姓名">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>' CausesValidation="False" ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="总消费">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZongXiaofei" ,"{0:N2}") %>' CausesValidation="False" ID="Label2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="总充值">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZongCongzhi" ,"{0:N2}") %>' CausesValidation="False" ID="Label3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <%--<asp:TemplateColumn HeaderText="充值总额">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Money") %>' CausesValidation="False" ID="Label3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>--%>
											</Columns>
											<PagerStyle Visible="False" BackColor="#666666" ForeColor="White" 
                                                HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid></td>
								</tr>
								<tr>
									<td class="table_bot2"></td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
											<tr align="middle">
												<td>共
													<asp:label id="lblRecNum" runat="server"></asp:label>个记录</td>
												<td>第
													<asp:label id="lblCurrentPage" runat="server"></asp:label>页/共
													<asp:label id="lblTotalPage" runat="server"></asp:label>页</td>
												<td>转到第
													<asp:dropdownlist id="ddlCurrentPage" runat="server" autopostback="True" 
                                                        onselectedindexchanged="ddlCurrentPage_SelectedIndexChanged1"></asp:dropdownlist>页
												</td>
												<td><asp:linkbutton id="lnkFirst" runat="server" visible="False" 
                                                        commandargument="First" causesvalidation="False" onclick="lnkFirst_Click">首  页</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkPrevious" runat="server" visible="False" 
                                                        commandargument="Previous" causesvalidation="False" onclick="lnkFirst_Click">上一页</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkNext" runat="server" commandargument="Next" 
                                                        causesvalidation="False" onclick="lnkFirst_Click">下一页</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkLast" runat="server" commandargument="Last" 
                                                        causesvalidation="False" onclick="lnkFirst_Click">尾  页</asp:linkbutton></td>
											</tr>
										</table>
									</td>
								</tr>

                                <tr>
									<td>
										<table class="tableclass" id="Table11" cellspacing="0" cellpadding="2" width="100%" border="0">
											<tr align="middle">
												<td>总消费合计：
													<asp:label id="lbTotalXiaofei" runat="server"></asp:label></td>
												<td>总充值合计：
													<asp:label id="lbTotalChongzhi" runat="server"></asp:label>
												</td>
												
											</tr>
										</table>
									</td>
								</tr>



							</table>
						</td>
						<td valign="top" align="left" width="2" bgcolor="#bfbfbf"><img height="2" src="../../images/page/table_dot_r.gif" width="2"></td>
					</tr>
					<tr bgcolor="#bfbfbf">
						<td><img height="3" src="../../images/son/table_dot_l.gif" width="2"></td>
						<td width="2"></td>
					</tr>
				</table>
                <br/>
               <div align="center">
			&nbsp;<br />
                    <br /><br />
				</div>
			</div>
		</form>
	</body>
</html>
