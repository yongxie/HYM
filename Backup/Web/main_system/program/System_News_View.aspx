<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_News_View.aspx.cs" Inherits="Web.main_system.program.System_News_View" %>

<html>
	<head>
		<title>ϵͳ����_���Ŷ�̬</title>
		<%--/* ����������������Ϣע�ͣ���������������
          ��������ϵͳ����_���Ŷ�̬����
          �������������Ŷ�̬����
         ��������������������������������������*/--%>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
		<link href="../../css/Default.css" type="text/css" rel="stylesheet"/>
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</head>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>��ǰλ�ã�&nbsp;ϵͳ����&nbsp;&gt;&nbsp;���Ŷ�̬&nbsp;
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
									<td class="title2" nowrap>���Ŷ�̬���</td>
									<td width="10"><img height="25" src="../../images/page/table_tit_r2.gif" width="10"></td>

									<td class="tdimages" width="99%" align="right">

                                    ���⣺<asp:TextBox id="txtTitle" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    ���ݣ�<asp:TextBox id="txtCount" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    ����Ա��<asp:DropDownList id="ddlUserID" runat="server" DESIGNTIMEDRAGDROP="70"></asp:DropDownList>&nbsp;&nbsp;
                                    
										<asp:Button id="btnCha" runat="server" Text="��  ѯ" CssClass="button"
                                         onclick="btnCha_Click" ></asp:Button>&nbsp;&nbsp;&nbsp;
                                        <asp:Button id="btnAdd" runat="server" Text="��  ��" CssClass="button" 
                        onclick="btnAdd_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
                                 </td>
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
                                            pagerstyle-visible="False" onitemcommand="MyDataGrid_ItemCommand" 
                                            BorderColor="#336666" BorderWidth="3px" BackColor="White" 
                                            BorderStyle="Double">
											<ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" 
                                                BackColor="White" ForeColor="#333333"></ItemStyle>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
											<HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" 
                                                BackColor="#336666" Font-Bold="True"></HeaderStyle>
											<Columns >
                                                <%--<asp:TemplateColumn HeaderText="ѡ��">
													<ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
													</ItemTemplate>
												</asp:TemplateColumn>--%>
												<asp:TemplateColumn HeaderText="�к�">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>' ID="Label5">
														</asp:Label>
														<input type = "hidden" name="hidControl5" value='<%# DataBinder.Eval(Container, "DataItem.NewsId") %>' runat="server" id="hidControl5"/>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn Visible="false" HeaderText="����ID">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NewsId") %>' CausesValidation="False" ID="Linkbutton1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NewsName") %>' CausesValidation="False" ID="Linkbutton2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NewsContent").ToString()+"......" %>' CausesValidation="False" ID="Linkbutton3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="��������">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NewsType") %>' CausesValidation="False" ID="Linkbutton4">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="����Ա">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>' CausesValidation="False" ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="�Ƿ�������ʾ">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ShowOnSys") %>' CausesValidation="False" ID="Label4">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="���ʱ��">
													<ItemTemplate>
														<asp:Label  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SendTime") %>' CausesValidation="False" ID="Label2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
											    <asp:EditCommandColumn  CancelText="ȡ��" EditText="�༭" UpdateText="����">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:EditCommandColumn>
                                                <asp:ButtonColumn  CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '��ȷ��ɾ����ѡ�������� ') &quot;&gt; ɾ�� &lt;/div&gt; ">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                </asp:ButtonColumn>
											</Columns>
											<PagerStyle Visible="False" BackColor="#336666" ForeColor="White" 
                                                HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
										    <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
										</asp:datagrid></td>
								</tr>
								<tr>
									<td class="table_bot2"></td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
											<tr align="middle">
												<td>��
													<asp:label id="lblRecNum" runat="server"></asp:label>����¼</td>
												<td>��
													<asp:label id="lblCurrentPage" runat="server"></asp:label>ҳ/��
													<asp:label id="lblTotalPage" runat="server"></asp:label>ҳ</td>
												<td>ת����
													<asp:dropdownlist id="ddlCurrentPage" runat="server" autopostback="True" 
                                                        onselectedindexchanged="ddlCurrentPage_SelectedIndexChanged1"></asp:dropdownlist>ҳ
												</td>
												<td><asp:linkbutton id="lnkFirst" runat="server" visible="False" 
                                                        commandargument="First" causesvalidation="False" onclick="lnkFirst_Click">��  ҳ</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkPrevious" runat="server" visible="False" 
                                                        commandargument="Previous" causesvalidation="False" onclick="lnkFirst_Click">��һҳ</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkNext" runat="server" commandargument="Next" 
                                                        causesvalidation="False" onclick="lnkFirst_Click">��һҳ</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkLast" runat="server" commandargument="Last" 
                                                        causesvalidation="False" onclick="lnkFirst_Click">β  ҳ</asp:linkbutton></td>
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
			</div>
		</form>
	</body>
</html>
