<%@ Register TagPrefix="MyTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Import Namespace="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_GroupAuthorization_Edit2.aspx.cs" Inherits="Web.main_system.program.System_GroupAuthorization_Edit2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
						<td width="2"><IMG height="2" src="../../images/page/table_dot_r.gif" width="2"></td>
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
													<asp:textbox id="txtGroupID" runat="server" cssclass="TBL" maxlength="20"></asp:textbox><font color="red">*
														<asp:requiredfieldvalidator id="vrftxtGroupID" runat="server" errormessage="系统提示：用户组代码不能为空" display="None" controltovalidate="txtGroupID"></asp:requiredfieldvalidator></font></td>
												<td class="tdh" align="right" width="122">用户组名称：</td>
												<td>&nbsp;
													<asp:textbox id="txtGroupName" runat="server" cssclass="TBL" maxlength="50"></asp:textbox>&nbsp;<font color="red">*
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
												<td align="center" height="25">系统主模块</td>
												<td>
													<table cellSpacing="0" cellPadding="0" align="left" border="0">
														<tr>
															<td align="center" width="100">子模块</td>
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
																		<td><input id="chkSubAll" onclick="CheckedAll(8)" type="checkbox" name="chkSubAll"><label for="chkSubAll">子模块全选</label></td>
																		<td><input id="chkSuper" onclick="CheckedAll(9)" type="checkbox" name="chkSuper"><label for="chkSuper">超级权限</label></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td><MYTAB:TABSTRIP id="tsVert" runat="server" AutoPostBack="True" TabHoverStyle="background-color:#f0e68c;"
														TabDefaultStyle="background-color:#BDD7AD;height:25px;width:100px;text-align:center" TabSelectedStyle="background-color:#73c363;"
														Orientation="Vertical" TargetID="mpVert">
														<MyTab:Tab Text="房产管理" />
														<MyTab:Tab Text="住户管理" />
														<MyTab:Tab Text="财务管理" />
														<MyTab:Tab Text="办公管理" />
														<MyTab:Tab Text="设备管理" />
														<MyTab:Tab Text="仓储管理" />
														<MyTab:Tab Text="安防管理" />
														<MyTab:Tab Text="环境管理" />
														<MyTab:Tab Text="决策支持" />
														<MyTab:Tab Text="系统功能" />
														<MyTab:Tab Text="社区综合服务" />
													</MYTAB:TABSTRIP></td>
												<td vAlign="top"><MYTAB:MULTIPAGE id="mpVert" runat="server">
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">小区管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0202" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">大楼管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0204" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">房产验收</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0206" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">购房管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0402" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">入伙管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0404" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">入住管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0406" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">出租管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0408" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">水电表录入</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0602" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">费用核算</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0604" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">住户交款</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0606" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">月结</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0608" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">银行托收</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0610" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">收费标准</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0612" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">汇总查询</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0614" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">雇员资料</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1002" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">奖惩记录</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1004" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">培训记录</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1006" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">设备类别定义</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1202" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">设备资料</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1204" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">设备保养</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1206" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">设备维修</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1208" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">设备巡查记录</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1210" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">设备运行时间</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1212" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">设备运行参数</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1214" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">物料类别定义</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1402" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">物料信息</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1404" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">物料申请</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1406" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">物料领用</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1408" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">物料盘点</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1410" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">安保管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1602" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">物品出入</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1604" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">来人来访</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1606" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">巡逻记录</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1608" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">突发事件</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1610" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">消防区定义</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1612" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">消防检查</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1614" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">消防演练</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1616" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">消防事故</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1618" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">卫生管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1802" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">绿化品种</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1804" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">绿化记录</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl1806" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">日常决策</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2002" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">报表</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2004" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">图表</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2006" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">通用代码定义</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0802" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">系统数据备份</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0806" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">系统初始化</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0808" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">系统操作日志</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl0810" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
														<MyTab:PageView>
															<table cellpadding="0" cellspacing="0" border="0" align="left">
																<tr>
																	<td width="100" align="center" height="19px">内容管理</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2202" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">住户投诉</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2204" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">小区调查</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2206" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
																<tr>
																	<td width="100" align="center" height="19px">日常服务</td>
																	<td height="19px">
																		<asp:CheckBoxList id="cbl2208" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="r">读取</asp:ListItem>
																			<asp:ListItem Value="m">修改</asp:ListItem>
																			<asp:ListItem Value="a">新增</asp:ListItem>
																			<asp:ListItem Value="d">删除</asp:ListItem>
																		</asp:CheckBoxList>
																	</td>
																</tr>
															</table>
														</MyTab:PageView>
													</MYTAB:MULTIPAGE></td>
											</tr>
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
				<br>
				<asp:button id="btnSave" runat="server" cssclass="button" text="保 存"></asp:button>&nbsp;
				<input class="button" id="btnCancel" type="reset" value="取 消" name="btnCancel">&nbsp;
				<asp:button id="btnDelete" runat="server" cssclass="button" text="删 除" causesvalidation="False"></asp:button>&nbsp;
				<asp:button id="btnBack" runat="server" Text="返 回" CssClass="button" CausesValidation="False"></asp:button></div>
		</form>
		<script language="javascript">
		    function CheckedAll(intItem) {
		        var chkID = new Array();
		        chkID[0] = new Array("0202", "0204", "0206");
		        chkID[1] = new Array("0402", "0404", "0406", "0408");
		        chkID[2] = new Array("0602", "0604", "0606", "0608", "0610", "0612", "0614");
		        chkID[3] = new Array("1002", "1004", "1006");
		        chkID[4] = new Array("1202", "1204", "1206", "1208", "1210", "1212", "1214");
		        chkID[5] = new Array("1402", "1404", "1406", "1408", "1410");
		        chkID[6] = new Array("1602", "1604", "1606", "1608", "1610", "1612", "1614", "1616", "1618");
		        chkID[7] = new Array("1802", "1804", "1806");
		        chkID[8] = new Array("2002", "2004", "2006");
		        chkID[9] = new Array("0802", "0806", "0808", "0810");
		        chkID[10] = new Array("2202", "2204", "2206", "2208");
		        var iSelect = document.all["tsVert"].selectedIndex;
		        if (intItem == 0) {
		            for (var i = 0; i < chkID[iSelect].length; i++)
		                document.all["cbl" + chkID[iSelect][i] + ":0"].checked = document.all["chkRead"].checked;
		        }
		        else if (intItem == 1) {
		            if (document.all["chkModify"].checked) {
		                for (var i = 0; i < chkID[iSelect].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":0"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":1"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[iSelect].length; i++)
		                    document.all["cbl" + chkID[iSelect][i] + ":1"].checked = false;
		            }
		        }
		        else if (intItem == 2) {
		            if (document.all["chkAdd"].checked) {
		                for (var i = 0; i < chkID[iSelect].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["chkModify"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":0"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":1"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":2"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[iSelect].length; i++)
		                    document.all["cbl" + chkID[iSelect][i] + ":2"].checked = false;
		            }
		        }
		        else if (intItem == 3) {
		            if (document.all["chkDelete"].checked) {
		                for (var i = 0; i < chkID[iSelect].length; i++) {
		                    document.all["chkRead"].checked = true;
		                    document.all["chkModify"].checked = true;
		                    document.all["chkAdd"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":0"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":1"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":2"].checked = true;
		                    document.all["cbl" + chkID[iSelect][i] + ":3"].checked = true;
		                }
		            }
		            else {
		                for (var i = 0; i < chkID[iSelect].length; i++)
		                    document.all["cbl" + chkID[iSelect][i] + ":3"].checked = false;
		            }
		        }
		        else if (intItem == 8) {
		            var blnChk = document.all["chkSubAll"].checked;
		            document.all["chkRead"].checked = blnChk;
		            document.all["chkModify"].checked = blnChk;
		            document.all["chkAdd"].checked = blnChk;
		            document.all["chkDelete"].checked = blnChk;
		            for (var i = 0; i < chkID[iSelect].length; i++) {
		                document.all["cbl" + chkID[iSelect][i] + ":0"].checked = blnChk;
		                document.all["cbl" + chkID[iSelect][i] + ":1"].checked = blnChk;
		                document.all["cbl" + chkID[iSelect][i] + ":2"].checked = blnChk;
		                document.all["cbl" + chkID[iSelect][i] + ":3"].checked = blnChk;
		            }
		        }
		        else if (intItem == 9) {
		            var blnChk = document.all["chkSuper"].checked;
		            document.all["chkRead"].checked = blnChk;
		            document.all["chkModify"].checked = blnChk;
		            document.all["chkAdd"].checked = blnChk;
		            document.all["chkDelete"].checked = blnChk;
		            document.all["chkSubAll"].checked = blnChk;
		            for (var i = 0; i < chkID.length; i++) {
		                for (var j = 0; j < chkID[i].length; j++) {
		                    document.all["cbl" + chkID[i][j] + ":0"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + ":1"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + ":2"].checked = blnChk;
		                    document.all["cbl" + chkID[i][j] + ":3"].checked = blnChk;
		                }
		            }
		        }
		        return true;
		    }
		</script>
	</body>
</HTML>