<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_DataBackup_Restore.aspx.cs" Inherits="Web.main_system.program.System_DataBackup_Restore" %>

<HTML>
	<HEAD>
		<title>系统功能_数据恢复</title>
        <%--/* ＊＊＊＊＊程序信息注释＊＊＊＊＊＊＊＊
          程序名：系统数据恢复
          程序描述：数据库恢复
          建立人及时间：Daniel，2003-01-22
          最后修改人及时间：Daniel，2003-01-22
         ＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊*/--%>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../../css/Default.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<table class="page_place" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td vAlign="center" align="middle" width="32"><IMG height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;系统功能&nbsp;&gt;&nbsp;数据恢复</td>
			</tr>
		</table>
		<br>
		<form id="System_DataBackup_Restore" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="20" height="25"><IMG height="25" src="../../images/page/table_tit_l2.gif" width="20"></td>
									<td class="title2" noWrap>备份文件列表</td>
									<td width="10"><IMG height="25" src="../../images/page/table_tit_r2.gif" width="10"></td>
									<td class="tdimages" width="99%">
										<p align="right">&nbsp;</p>
									</td>
								</tr>
							</table>
						</td>
						<td width="2"><IMG height="2" src="../../images/page/table_dot_r2.gif" width="2"></td>
					</tr>
					<tr>
						<td>
							<table class="tableclass2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="table_top2"></td>
								</tr>
								<tr>
									<td class="table_linebot"><asp:datagrid id="MyDataGrid" runat="server" 
                                            onitemcommand="DataOperate" gridlines="Horizontal" cssclass="tableclass" 
                                            width="100%" cellpadding="4" allowpaging="True" autogeneratecolumns="False" 
                                            pagerstyle-visible="False" BorderColor="Gray" BorderWidth="1px" 
                                            ForeColor="#333333">

<PagerStyle Visible="False" BackColor="#666666" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

											<selecteditemstyle forecolor="#333333" backcolor="#C5BBAF" Font-Bold="True"></selecteditemstyle>
											<itemstyle horizontalalign="Center" height="21px" cssclass="item" 
                                                BackColor="#E3EAEB"></itemstyle>
											<headerstyle horizontalalign="Center" height="21px" forecolor="White" 
                                                backcolor="#1C5E55" Font-Bold="True"></headerstyle>
											<EditItemStyle BackColor="#7C6F57" />
											<footerstyle forecolor="White" backcolor="#1C5E55" Font-Bold="True"></footerstyle>
											<AlternatingItemStyle BackColor="White" />
											<columns>
												<asp:templatecolumn headertext="文件名">
													<itemtemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileName") %>' CausesValidation=False ID="Linkbutton1" >
														</asp:Label>
													</itemtemplate>
												</asp:templatecolumn>
												<asp:templatecolumn headertext="文件大小(KB)">
													<itemtemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileSize") %>' ID="Label3">
														</asp:Label>
													</itemtemplate>
												</asp:templatecolumn>
												<asp:templatecolumn headertext="文件创建时间">
													<itemtemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreateDate") %>' ID="Label2">
														</asp:Label>
													</itemtemplate>
												</asp:templatecolumn>
												<asp:templatecolumn headertext="文件修改时间">
													<itemtemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastModifyDate") %>' ID="Label1" >
														</asp:Label>
													</itemtemplate>
												</asp:templatecolumn>
											    <asp:EditCommandColumn CancelText="取消" EditText="&lt;div onclick= &quot;JavaScript:return confirm( '你确定要恢复此备份吗？ ') &quot;&gt; 恢复备份 &lt;/div&gt; " UpdateText="更新">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:EditCommandColumn>
											</columns>
										</asp:datagrid></td>
								</tr>
								<tr>
									<td class="table_bot2"></td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" id="Table3" cellSpacing="0" cellPadding="2" width="88%" border="0">
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
												<td><asp:linkbutton id="lnkFirst" runat="server" causesvalidation="False" 
                                                        commandargument="First" visible="False" onclick="lnkFirst_Click">首  页</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkPrevious" runat="server" causesvalidation="False" 
                                                        commandargument="Previous" visible="False" onclick="lnkFirst_Click">上一页</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkNext" runat="server" causesvalidation="False" 
                                                        commandargument="Next" onclick="lnkFirst_Click">下一页</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkLast" runat="server" causesvalidation="False" 
                                                        commandargument="Last" onclick="lnkFirst_Click">尾  页</asp:linkbutton></td>
											</tr>
										</table>
									</td>
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
				<%--<div align="center">&nbsp;
					<TABLE cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
						<TR>
							<TD>
								<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD width="20" height="25"><IMG height="25" src="../../images/page/table_tit_l.gif" width="20"></TD>
										<TD class="title1" noWrap>操作备份</TD>
										<TD width="10"><IMG height="25" src="../../images/page/table_tit_r.gif" width="10"></TD>
										<TD class="tdimages" align="right" width="99%">&nbsp;
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD width="2"><IMG height="2" src="../../images/page/table_dot_r.gif" width="2"></TD>
						</TR>
						<TR>
							<TD>
								<TABLE class="tableclass1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD class="table_top"></TD>
									</TR>
									<TR>
										<TD>
											<TABLE class="tableclass" id="SaleManagerList_Table" cellSpacing="0" cellPadding="0" width="100%" align="center">
												<TR>
													<TD class="tdh" align="right" width="122">备份文件名：</TD>
													<TD>&nbsp;
														<asp:textbox id="txtFileName" runat="server"  ReadOnly="True" Width="238px" ></asp:textbox>
														<asp:requiredfieldvalidator id="vrftxtFileName" runat="server" errormessage="系统提示：请选择一个备份文件!" display="None" controltovalidate="txtFileName"></asp:requiredfieldvalidator>
														<asp:validationsummary id="vvsError" runat="server" showmessagebox="True" showsummary="False" displaymode="List"></asp:validationsummary></TD>
												</TR>
											</TABLE>
										</TD>
									<TR>
										<TD class="table_bot"></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top" align="left" width="2" bgColor="#bfbfbf"><IMG height="2" src="../../images/page/table_dot_r.gif" width="2"></TD>
						</TR>
						<TR bgColor="#bfbfbf">
							<TD><IMG height="3" src="../../images/son/table_dot_l.gif" width="2"></TD>
							<TD width="2" height="3"></TD>
						</TR>
					</TABLE>
					<BR>
					<DIV align="center">&nbsp;
						<asp:button id="btnRestore" runat="server" cssclass="button" text="恢复备份"  OnClientClick="return confirm('你确定要恢复所选择的数据项吗？')"
                            onclick="btnRestore_Click"></asp:button>&nbsp;&nbsp;&nbsp;</DIV>
				</div>--%>
			</div>
		</form>
	</body>
</HTML>
