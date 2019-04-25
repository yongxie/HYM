<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_QuestionFB_View.aspx.cs" Inherits="Web.main_system.program.System_QuestionFB_View" %>

<html>
	<head>
		<title>系统功能_问题反馈</title>
        <%--/* ＊＊＊＊＊程序信息注释＊＊＊＊＊＊＊＊
          程序名：系统功能_问题反馈程序
          程序描述：问题反馈程序
         ＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊*/--%>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
		<link href="../../css/Default.css" type="text/css" rel="stylesheet"/>
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</head>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;系统功能&nbsp;&gt;&nbsp;问题反馈&nbsp;
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
									<td class="title2" nowrap>问题反馈查询浏览</td>
									<td width="10"><img height="25" src="../../images/page/table_tit_r2.gif" width="10"></td>

									<td class="tdimages" width="99%" align="right">

                                    问题标题：<asp:TextBox id="txtQuesTitle" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    问题内容：<asp:TextBox id="txtQuesContent" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                    提问者：<asp:DropDownList id="ddlQues" runat="server" DESIGNTIMEDRAGDROP="70"></asp:DropDownList>&nbsp;&nbsp;
										
                                        <asp:Button id="btnCha" runat="server" Text="查  询" CssClass="button"
                                         onclick="btnCha_Click" ></asp:Button>&nbsp;&nbsp;&nbsp;
                                        <asp:Button id="btnAdd" runat="server" Text="新  增" CssClass="button" 
                                         onclick="btnAdd_Click"></asp:Button>&nbsp;&nbsp;&nbsp;</td>
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
									<td><asp:datagrid id="GoodsDataGrid" runat="server" gridlines="Horizontal" 
                                            cssclass="tableclass" width="100%" 
                                            cellpadding="4" allowpaging="True" pagesize="20" autogeneratecolumns="False" 
                                            pagerstyle-visible="False" onitemcommand="GoodsDataGrid_ItemCommand" 
                                            BorderColor="#336666" BorderWidth="3px" BackColor="White" BorderStyle="Double">
											<SelectedItemStyle ForeColor="White" BackColor="#339966" Font-Bold="True"></SelectedItemStyle>
											<ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" 
                                                BackColor="White" ForeColor="#333333"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" 
                                                BackColor="#336666" Font-Bold="True"></HeaderStyle>
											<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="行号">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>' ID="Label5">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn Visible="false" HeaderText="问题ID">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>' CausesValidation="False" ID="Linkbutton3">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="提问者">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Qer") %>' CausesValidation="False" ID="Linkbutton2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="问题标题">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QAName") %>' CausesValidation="False" ID="Linkbutton1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="问题内容">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Question").ToString()+"......" %>' CausesValidation="False" ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="提问时间">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QuestionTime") %>' CausesValidation="False" ID="Label2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<%--<asp:TemplateColumn HeaderText="是否答复">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsCategoryDescription") %>' CausesValidation="False" ID="Label2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>--%>
											    <asp:EditCommandColumn CancelText="取消" EditText="查看" UpdateText="更新">
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                </asp:EditCommandColumn>
                                                <asp:ButtonColumn CommandName="Delete" 
                                                    Text="&lt;div onclick= &quot;JavaScript:return confirm( '你确定删除所选的数据吗？ ') &quot;&gt; 删除 &lt;/div&gt; ">
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:ButtonColumn>
											    <asp:ButtonColumn Visible="false" CommandName="Select" Text="回复">
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                </asp:ButtonColumn>
											</Columns>
											<PagerStyle Visible="False" BackColor="#336666" ForeColor="White" 
                                                HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
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
