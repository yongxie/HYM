<%@ Register TagPrefix="MyTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Import Namespace="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_GroupAuthorization_Edit.aspx.cs" Inherits="Web.main_system.program.System_GroupAuthorization_Edit" %>

<HTML>
	<HEAD>
		<title>系统功能_用户组权限</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../../css/default.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="System_GroupAuthorization_Edit" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="20" height="25">
										<p align="left"><IMG height="25" src="../../images/page/table_tit_l.gif" width="20"></p>
									</td>
									<td class="title1" noWrap>用户组权限设置</td>
									<td width="10"><IMG height="25" src="../../images/page/table_tit_r.gif" width="10"></td>
									<td class="tdimages" width="99%">&nbsp;</td>
								</tr>
							</table>
						</td>
						<td width="2"><IMG src="../../images/page/table_dot_r.gif" width="2" 
                                style="height: 2px"></td>
					</tr>
					<tr>
						<td>
							<table class="tableclass1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="table_top"></td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" id="T1" cellSpacing="0" cellPadding="0" width="100%" align="center">
											<tr>
												<td class="tdh" align="right" width="123">用户组代码：</td>
												<td width="201">&nbsp;
													<asp:textbox id="txtGroupID" runat="server"  maxlength="20"></asp:textbox><font color="red">*
														<asp:requiredfieldvalidator id="vrftxtGroupID" runat="server" errormessage="系统提示：用户组代码不能为空" display="None" controltovalidate="txtGroupID"></asp:requiredfieldvalidator></font></td>
												<td class="tdh" align="right" width="122">用户组名称：</td>
												<td>&nbsp;
													<asp:textbox id="txtGroupName" runat="server"  maxlength="50"></asp:textbox>&nbsp;<font color="red">*
														<asp:validationsummary id="vvsError" runat="server" showmessagebox="True" showsummary="False" displaymode="List"></asp:validationsummary><asp:requiredfieldvalidator id="vrftxtGroupName" runat="server" errormessage="系统提示：用户组名称不能为空" display="None"
															controltovalidate="txtGroupName"></asp:requiredfieldvalidator></font></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
								</tr>
								<tr>
									<td>
										<table class="tableclass" cellSpacing="0" cellPadding="0" width="100%" align="center">
							            			  <tr bgColor="#bdd7ad">
												<td>
													<table cellSpacing="0" cellPadding="0" align="left" border="0">
														<tr>
															<td>
																<table border="0">
																	<tr>
																		<td><input id="chkRead" onclick="CheckedAll(0)" type="checkbox" name="chkRead"><label for="chkRead">读取</label></td>
																		<td><input id="chkModify" onclick="CheckedAll(1)" type="checkbox" name="chkModify"><label for="chkModify">修改</label></td>
																		<td><input id="chkAdd" onclick="CheckedAll(2)" type="checkbox" name="chkAdd"><label for="chkAdd">新增</label></td>
																		<td><input id="chkDelete" onclick="CheckedAll(3)" type="checkbox" name="chkDelete"><label for="chkDelete">删除</label></td>
																	</tr>
																</table>
															</td>
															<td>
																<table border="0">
																	<tr>
																		<td><input id="chkSuper" onclick="CheckedAll(9)" type="checkbox" name="chkSuper"><label for="chkSuper">超级权限</label></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;消费管理：</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                会员消费：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0101" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                会员充值：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0102" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                消费记录：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0103" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;会员管理：</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                会员录入：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0201" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                会员查询：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0202" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                会员级别：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0203" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;商品管理：</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                商品录入：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0301" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                商品查询：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0302" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                商品分类：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0303" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;统计分析：</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                会员统计：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0401" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                部门消费统计：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0402" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                会员消费统计：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0403" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;短信平台：</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                指定号码发送：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0501" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                系统数据发送：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0502" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                查询短信余量：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0503" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                短信发送记录：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0504" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                短信模版管理：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0505" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                                                                        <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120" align="left" height="19px">
                                                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;系统功能：</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                用户管理：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0601" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                组权限设置：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0602" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                数据备份：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0603" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                数据恢复：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0604" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                系统日志：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0605" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px">
                                                                修改密码：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0607" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" align="left">
                                                        <tr>
                                                            <td width="130" align="right" height="19px">
                                                                新闻动态：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0608" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="130" align="right" height="19px" >
                                                                问题反馈：
                                                            </td>
                                                            <td height="19px">
                                                                <asp:CheckBoxList ID="cbl0609" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="r">读取</asp:ListItem>
                                                                    <asp:ListItem Value="m">修改</asp:ListItem>
                                                                    <asp:ListItem Value="a">新增</asp:ListItem>
                                                                    <asp:ListItem Value="d">删除</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                                                                                   <tr>
                                            <td width="120" align="left" height="19px">
 
                                                </td>
                                            </tr>
                                                                                                 <%-- <%=addcontent %>--%>
										</table>
									</td>
								</tr>
                           
								<tr>
									<td class="table_bot"></td>
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
			
				<asp:button id="btnSave" runat="server" cssclass="button" text="保 存" OnClientClick="return ConfirmSave()" 
                    onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:button id="btnDelete" runat="server" cssclass="button" text="删 除" OnClientClick="return ConfirmDel()" onclick="btnDelete_Click" 
                    ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="btnBack" runat="server" Text="返 回" CssClass="button" 
                    CausesValidation="False" onclick="btnBack_Click"></asp:button></div>
		</form>
		<script type="text/javascript" language="javascript">
		    function CheckedAll(intItem) {
		        var chkID = new Array();
		        chkID[0] = new Array("0101", "0102", "0103", "0201", "0202", "0203", "0301", "0302", "0303", "0401", "0402", "0403", "0501", "0502", "0503", "0504", "0505", "0601", "0602","0603","0604","0605","0607","0608","0609");
//		        chkID[1] = new Array("0402", "0404", "0406", "0408");
//		        chkID[2] = new Array("0602", "0604", "0606", "0608", "0610", "0612", "0614");
//		        chkID[3] = new Array("1002", "1004", "1006");
//		        chkID[4] = new Array("1202", "1204", "1206", "1208", "1210", "1212", "1214");
//		        chkID[5] = new Array("1402", "1404", "1406", "1408", "1410");
//		        chkID[6] = new Array("1602", "1604", "1606", "1608", "1610", "1612", "1614", "1616", "1618");
//		        chkID[7] = new Array("1802", "1804", "1806");
//		        chkID[8] = new Array("2002", "2004", "2006");
//		        chkID[9] = new Array("0802", "0806", "0808", "0810");
//		        chkID[10] = new Array("2202", "2204", "2206", "2208");
		        //var iSelect = document.all["tsVert"].selectedIndex;
		        if (intItem == 0) {
		            for (var i = 0; i < chkID[0].length; i++)
		                document.all["cbl" + chkID[0][i] + "_0"].checked = document.all["chkRead"].checked;
		        }
		        else if (intItem == 1) {
		            if (document.all["chkModify"].checked) {
		                for (var i = 0; i < chkID[0].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_0"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[0].length; i++)
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = false;
		            }
		        }
		        else if (intItem == 2) {
		            if (document.all["chkAdd"].checked) {
		                for (var i = 0; i < chkID[0].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["chkModify"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_0"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_2"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[0].length; i++)
		                    document.all["cbl" + chkID[0][i] + "_2"].checked = false;
		            }
		        }
		        else if (intItem == 3) {
		            if (document.all["chkDelete"].checked) {
		                for (var i = 0; i < chkID[0].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["chkModify"].checked = true;
		                    document.all["chkAdd"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_0"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_1"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_2"].checked = true;
		                    document.all["cbl" + chkID[0][i] + "_3"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[0].length; i++)
		                    document.all["cbl" + chkID[0][i] + "_3"].checked = false;
		            }
		        }
		        else if (intItem == 8) {
		            var blnChk = document.all["chkSubAll"].checked;
		            document.all["chkRead"].checked = blnChk;
		            document.all["chkModify"].checked = blnChk;
		            document.all["chkAdd"].checked = blnChk;
		            document.all["chkDelete"].checked = blnChk;
		            for (var i = 0; i < chkID[0].length; i++) {
		                document.all["cbl" + chkID[0][i] + "_0"].checked = blnChk;
		                document.all["cbl" + chkID[0][i] + "_1"].checked = blnChk;
		                document.all["cbl" + chkID[0][i] + "_2"].checked = blnChk;
		                document.all["cbl" + chkID[0][i] + "_3"].checked = blnChk;
		            }
		        }
		        else if (intItem == 9) {
		            var blnChk = document.all["chkSuper"].checked;
		            document.all["chkRead"].checked = blnChk;
		            document.all["chkModify"].checked = blnChk;
		            document.all["chkAdd"].checked = blnChk;
		            document.all["chkDelete"].checked = blnChk;
		            //document.all["chkSubAll"].checked = blnChk;
		            for (var i = 0; i < chkID.length; i++) {
		                for (var j = 0; j < chkID[i].length; j++) {
		                    document.all["cbl" + chkID[i][j] + "_0"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + "_1"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + "_2"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + "_3"].checked = blnChk;
		                }
		            }
		        }
		        return true;
		    }
		</script>
	</body>
</HTML>
<script type="text/javascript">
    function ConfirmSave() {
        if (Page_ClientValidate()) {
            return confirm('确定要保存所选择的数据项吗？');
        }
        else {
            return false;
        }
    }
    function ConfirmDel() {
        if (Page_ClientValidate()) {
            return confirm('确定要删除所选择的数据项吗？');
        }
        else {
            return false;
        }
    }
 </script>