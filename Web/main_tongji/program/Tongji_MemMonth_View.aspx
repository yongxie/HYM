<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tongji_MemMonth_View.aspx.cs" Inherits="Web.main_tongji.program.Tongji_MemMonth_View" %>

<html>
	<head>
		<title>ͳ�Ʒ���_��Ա����ͳ��</title>
		<%--/* ����������������Ϣע�ͣ���������������
          ����������Ա����_��Ա���²�ѯ����
          ������������Ա���²�ѯ����
         ��������������������������������������*/--%>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
		<link href="../../css/Default.css" type="text/css" rel="stylesheet"/>
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</head>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>��ǰλ�ã�&nbsp;ͳ�Ʒ���&nbsp;&gt;&nbsp;��Ա����ͳ��&nbsp;
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
									<td class="title2" nowrap>��Ա����ͳ��</td>
									<td width="10"><img height="25" src="../../images/page/table_tit_r2.gif" width="10"></td>

									<td class="tdimages" width="99%" align="right">
                                    ���ţ�<asp:TextBox id="txtCardId" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    ������<asp:TextBox id="txtMemName" runat="server" Width="70px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    ���������̣�<asp:DropDownList id="ddlUserID" runat="server" DESIGNTIMEDRAGDROP="60"></asp:DropDownList>&nbsp;&nbsp;
                                        &nbsp;&nbsp;��ʼʱ�䣺<asp:TextBox id="txtBeginDate" runat="server" Width="80px" >&nbsp;&nbsp;</asp:TextBox><IMG style="CURSOR: hand" onclick="fPopUpCalendarDlg(txtBeginDate);return false" alt="" src="../../images/button/datetime.gif" align="absMiddle">
										<asp:CompareValidator id="vcvtxtBeginDate" runat="server" Display="None" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtBeginDate" ErrorMessage="ϵͳ��ʾ����ʼ���ڱ�����д��ȷ�����ڸ�ʽ��"></asp:CompareValidator>
										&nbsp;&nbsp;����ʱ�䣺<asp:TextBox id="txtEndDate" runat="server" Width="80px" >&nbsp;&nbsp;</asp:TextBox><IMG style="CURSOR: hand" onclick="fPopUpCalendarDlg(txtEndDate);return false" alt="" src="../../images/button/datetime.gif" align="absMiddle">
										<asp:CompareValidator id="vcvtxtEndDate" runat="server" Display="None" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtEndDate" ErrorMessage="ϵͳ��ʾ���������ڱ�����д��ȷ�����ڸ�ʽ��"></asp:CompareValidator>
                                        &nbsp;&nbsp;
                                        <asp:validationsummary id="vvsError" runat="server" displaymode="List" showsummary="False" showmessagebox="True"></asp:validationsummary>
										<asp:Button id="btnCha"  runat="server" Text="��  ѯ" CssClass="button"
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
												<asp:TemplateColumn HeaderText="�к�">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>' ID="Label5">
														</asp:Label>
														<%--<input type = "hidden" name="hidControl5" value='<%# DataBinder.Eval(Container, "DataItem.MemID") %>' runat="server" id="hidControl5"/>--%>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="��Ա����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CardId") %>' CausesValidation="False" ID="Linkbutton3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="��Ա����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MemName") %>' CausesValidation="False" ID="Label4">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="������ID">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.father") %>' CausesValidation="False" ID="Linkbutton2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="����������">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FatherName") %>' CausesValidation="False" ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="�˻����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Account","{0:N2}") %>' CausesValidation="False" ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="���Ѻϼ�">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Xiaofei" ,"{0:N2}") %>' CausesValidation="False" ID="Label2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="��ֵ�ϼ�">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Chongzhi","{0:N2}") %>' CausesValidation="False" ID="Label3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
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


                                <tr>
									<td>
										<table class="tableclass" id="Table11" cellspacing="0" cellpadding="2" width="100%" border="0">
											<tr align="middle">
												<td>�˻�����
													<asp:label id="lbTotalMoney" runat="server"></asp:label></td>
												<td>�����Ѻϼƣ�
													<asp:label id="lbTotalXiaofei" runat="server"></asp:label></td>
												<td>�ܳ�ֵ�ϼƣ�
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
