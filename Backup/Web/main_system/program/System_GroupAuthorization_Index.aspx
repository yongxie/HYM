<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_GroupAuthorization_Index.aspx.cs" Inherits="Web.main_system.program.System_GroupAuthorization_Index" %>

<html>
	<head>
		<title>ϵͳ����_�û���Ȩ��</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
		<link href="../../css/default.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<table class="page_place" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td vAlign="center" align="middle" width="32"><IMG height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>&nbsp;&nbsp;��ǰλ�ã�ϵͳ���� &gt; �û���Ȩ��</td>
			</tr>
		</table>
		<br/>
		<form id="System_GroupAuthorization_Index" method="post" runat="server">
			<div align="center">
				<table id="Table1" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
					<TR>
						<TD>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="20" height="25"><IMG height="25" src="../../images/page/table_tit_l2.gif" width="20"></TD>
									<TD class="title2" noWrap><STRONG>ϵͳ�û���</STRONG>�б�</TD>
									<TD width="10"><IMG height="25" src="../../images/page/table_tit_r2.gif" width="10"></TD>
									<TD class="tdimages" width="99%">
										<P align="right"><asp:Button id="btnAdd" runat="server" Text="��  ��" CssClass="button" 
                        onclick="btnAdd_Click"></asp:Button>&nbsp;</P>
									</TD>                                    <td class="tdimages" width="99%" align="right">
                                    						&nbsp;</td>
								</TR>
							</TABLE>
						</TD>
						<TD width="2"><IMG height="2" src="../../images/page/table_dot_r2.gif" width="2"></TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="tableclass2" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="table_top2"></TD>
								</TR>
								<TR>
									<TD class="table_linebot">
										<ASP:DATAGRID id="MyDataGrid" runat="server" PagerStyle-Visible="False" 
                                            AutoGenerateColumns="False" PageSize="20" AllowPaging="True" 
                                            CellPadding="4" Width="100%" CssClass="tableclass" GridLines="Horizontal" 
                                            OnItemCommand="DataOperate" ForeColor="#333333" BorderColor="Gray" 
                                            BorderWidth="1px">
											<SelectedItemStyle ForeColor="#333333" BackColor="#C5BBAF" Font-Bold="True"></SelectedItemStyle>
											<ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" 
                                                BackColor="#E3EAEB"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" 
                                                BackColor="#1C5E55" Font-Bold="True"></HeaderStyle>
											<EditItemStyle BackColor="#7C6F57" />
											<FooterStyle ForeColor="White" BackColor="#1C5E55" Font-Bold="True"></FooterStyle>
											<AlternatingItemStyle BackColor="White" />
											<Columns>
												<asp:TemplateColumn HeaderText="�û������">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupID") %>' ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="�û�������">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>' ID="Linkbutton1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
											    <asp:EditCommandColumn CancelText="ȡ��" EditText="�༭" UpdateText="����">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:EditCommandColumn>
                                                <asp:ButtonColumn CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '��ȷ��ɾ����ѡ�������� ') &quot;&gt; ɾ�� &lt;/div&gt; ">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                </asp:ButtonColumn>
											</Columns>
											<PagerStyle Visible="False" BackColor="#666666" ForeColor="White" 
                                                HorizontalAlign="Center"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<TR>
									<TD class="table_bot2"></TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="tableclass" id="Table3" cellSpacing="0" cellPadding="2" width="88%" border="0">
											<TR align="middle">
												<TD>��
													<asp:Label id="lblRecNum" runat="server"></asp:Label>����¼</TD>
												<TD>��
													<asp:label id="lblCurrentPage" runat="server"></asp:label>ҳ/��
													<asp:label id="lblTotalPage" runat="server"></asp:label>ҳ</TD>
												<td>ת����
													<asp:DropDownList id="ddlCurrentPage" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlCurrentPage_SelectedIndexChanged1"></asp:DropDownList>ҳ
												</td>
												<TD><asp:linkbutton id="lnkFirst" runat="server" Visible="False" 
                                                        CommandArgument="First" CausesValidation="False" onclick="lnkFirst_Click">��  ҳ</asp:linkbutton></TD>
												<TD><asp:linkbutton id="lnkPrevious" runat="server" Visible="False" 
                                                        CommandArgument="Previous" CausesValidation="False" onclick="lnkFirst_Click">��һҳ</asp:linkbutton></TD>
												<TD><asp:linkbutton id="lnkNext" runat="server" CommandArgument="Next" 
                                                        CausesValidation="False" onclick="lnkFirst_Click">��һҳ</asp:linkbutton></TD>
												<TD><asp:linkbutton id="lnkLast" runat="server" CommandArgument="Last" 
                                                        CausesValidation="False" onclick="lnkFirst_Click">β  ҳ</asp:linkbutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="left" width="2" bgColor="#bfbfbf"><IMG height="2" src="../../images/page/table_dot_r.gif" width="2"></TD>
					</TR>
					<TR bgColor="#bfbfbf">
						<TD><IMG height="3" src="../../images/son/table_dot_l.gif" width="2"></TD>
						<TD width="2" height="3"></TD>
					</TR>
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