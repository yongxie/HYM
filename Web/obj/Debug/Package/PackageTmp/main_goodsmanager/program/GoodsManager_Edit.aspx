<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsManager_Edit.aspx.cs" Inherits="Web.main_charge.program.GoodsManager_Edit" %>

<HTML>
	<HEAD>
		<title>设备保养</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;商品管理&nbsp;&gt;&nbsp;商品信息
				
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
								<td class="title1" nowrap>商品信息</td>
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
										<tr>
											<td class="tdh" align="right" width="144">商品ID：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtGoodsID" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtGoodsID" runat="server" errormessage="系统提示：商品ID不能为空" display="None" controltovalidate="txtGoodsID"></asp:requiredfieldvalidator></font></td>
											<td class="tdh" align="right" width="89">商品名称：</td>
											<td>&nbsp;
												<asp:textbox id="txtGoodsName" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtGoodsName" runat="server" errormessage="系统提示：商品名称不能为空" display="None" controltovalidate="txtGoodsName"></asp:requiredfieldvalidator></font></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="tdh" align="right" width="144">商品简码：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtCode" runat="server" ></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtCardID" runat="server" controltovalidate="txtCode" display="None" errormessage="系统提示：商品简码不能为空"></asp:requiredfieldvalidator></font></td>
											<td class="tdh" align="right" width="89">单&nbsp;&nbsp;价：</td>
											<td>&nbsp;
												<asp:textbox id="txtPrice" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" errormessage="系统提示：单价不能为空" display="None" controltovalidate="txtPrice"></asp:requiredfieldvalidator></font></td>
									
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="tdh" align="right" width="144" height="17">商品类别：</td>
											<td width="186" height="17">&nbsp;
												<asp:dropdownlist id="ddlGoodsCateId" runat="server"></asp:dropdownlist><font color="red"></font>
                                                <asp:textbox id="txtId" runat="server" Visible="false" ></asp:textbox>
                                                <asp:textbox id="txtPageIndex" runat="server" Visible="false" ></asp:textbox></td>
											
										</tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td class="table_iteam" align="right" width="144">备&nbsp;&nbsp;注：</td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtDesc" runat="server" width="430px" rows="4" textmode="MultiLine"></asp:textbox>
												<asp:regularexpressionvalidator id="vretxtDesc" runat="server" 
                                                    validationexpression="(.|\n){0,250}" errormessage="系统提示：不能超过250个字符" 
                                                    display="None" controltovalidate="txtDesc"></asp:regularexpressionvalidator>
                                                <br />
                                                <br />
                                            </td>
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
				<asp:button id="btnSave" runat="server" cssclass="button" text="保 存" OnClientClick="return ConfirmSave() " 
                    onclick="btnSave_Click"></asp:button>&nbsp;
				<asp:button id="btnDelete" runat="server" causesvalidation="False" 
                    cssclass="button" text="删 除" OnClientClick="return ConfirmDel() " onclick="btnDelete_Click"></asp:button>&nbsp;
				<asp:button id="Return" runat="server" causesvalidation="False" text="返 回" 
                    cssclass="button" onclick="Return_Click"></asp:button></div>
		</form>
		<script src="../../js/PressEnter.js"></script>
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