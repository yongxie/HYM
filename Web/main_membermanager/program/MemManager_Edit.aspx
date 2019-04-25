<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemManager_Edit.aspx.cs" Inherits="Web.main_membermanager.program.MemManager_Edit" %>

<HTML>
	<HEAD>
		<title>会员信息</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;会员管理&nbsp;&gt;&nbsp;会员信息
				</td>
			</tr>
		</table>
		<br>
		<form id="form1" method="post" runat="server" >
			<table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
				<tr>
					<td>
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
								<td width="20" height="25"><img height="25" src="../../images/page/table_tit_l.gif" width="20"></td>
								<td class="title1" nowrap>会员信息</td>
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
											<td class="tdh" align="right" width="144" height="17">会员信息：</td>
											<td width="186" height="17">&nbsp;
											</td>
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;</td>
                                          
										</tr>
                                        <tr>
											<td class="tdh" align="right" width="144">用户名：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtMemId" runat="server" ></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtMemId" runat="server" controltovalidate="txtMemId" display="None" errormessage="系统提示：会员ID不能为空"></asp:requiredfieldvalidator></font></td>
											<td class="tdh" align="right" width="89">姓名：</td>
											<td >&nbsp;
												<asp:textbox id="txtMemName" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtMemName" runat="server" errormessage="系统提示：姓名不能为空" display="None" controltovalidate="txtMemName"></asp:requiredfieldvalidator></font></td>
									
										</tr>
                                        <tr><td>&nbsp;</td></tr>

                                        <tr>
											<td class="tdh" align="right" width="144">出生日期：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtBirthday" runat="server"  maxlength="20"></asp:textbox>
													</td>
													
											<td class="tdh" align="right" width="89">会员性别：</td>
											<td>&nbsp;
												<asp:dropdownlist id="ddlSex" runat="server"></asp:dropdownlist></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>

                                        <tr>
											<td class="tdh" align="right" width="144">年龄：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtAge" runat="server"  maxlength="20"></asp:textbox></td>
													
											<td class="tdh" align="right" width="89">职业：</td>
											<td>&nbsp;
												<asp:textbox id="txtJob" runat="server"  maxlength="20"></asp:textbox></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr>
											<td class="tdh" align="right" width="144">固定电话：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtTel" runat="server"  maxlength="20"></asp:textbox></td>
													
											<td class="tdh" align="right" width="89">手机：</td>
											<td>&nbsp;
												<asp:textbox id="txtMobi" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtMobi" runat="server" errormessage="系统提示：手机号码不能为空" display="None" controltovalidate="txtMobi"></asp:requiredfieldvalidator></font></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr>
											<td class="tdh" align="right" width="144">开户人：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtAccountName" runat="server"  maxlength="20"></asp:textbox></td>
													
								            											<td class="tdh" align="right" width="89">银行账号：</td>
											<td>&nbsp;
												<asp:textbox id="txtAccountNumber" runat="server"  maxlength="20"></asp:textbox></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>
                            

                                        <tr>
											<td class="table_iteam" align="right" width="144">开户分行：</td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtOpeningBank" runat="server" width="430px" ></asp:textbox></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>

                                        <tr>
											<td class="tdh" align="right" width="144">身份证号：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtIdentitycard" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" errormessage="系统提示：身份证号不能为空" display="None" controltovalidate="txtIdentitycard"></asp:requiredfieldvalidator></font></td>
											<td class="tdh" align="right" width="89">省：</td>
											<td>&nbsp;
												<asp:dropdownlist id="ddlProvince" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlProvince_SelectedIndexChanged"></asp:dropdownlist></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>

                                        <tr>
											<td class="tdh" align="right" width="144">市：</td>
											<td width="186">&nbsp;
												<asp:dropdownlist id="ddlCity" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlCity_SelectedIndexChanged"></asp:dropdownlist></td>
													
											<td class="tdh" align="right" width="89">县：</td>
											<td>&nbsp;
												<asp:dropdownlist id="ddlDistrict" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
										</tr>
                                        <tr><td>&nbsp;</td></tr>

										<tr>
											<td class="table_iteam" align="right" width="144">住址：</td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtAddr" runat="server" width="430px" rows="4"></asp:textbox>
												<asp:regularexpressionvalidator id="vretxtAddr" runat="server" 
                                                    validationexpression="(.|\n){0,250}" errormessage="系统提示：不能超过250个字符" 
                                                    display="None" controltovalidate="txtAddr"></asp:regularexpressionvalidator></td>
										</tr>
                                        	
                                         <tr>
											<td class="tdh" align="right" width="144" height="17">会员卡信息：</td>
											<td width="186" height="17">&nbsp;
											</td>
											<td class="tdh" align="right" width="89"></td>
											<td>&nbsp;</td>
                                          
										</tr>
                                        			
                                          <tr>
											<td class="tdh" align="right" width="144">会员卡号：</td>
											<td width="186">&nbsp;
												<asp:textbox id="txtCardID" runat="server" ></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtCardID" runat="server" controltovalidate="txtCardID" display="None" errormessage="系统提示：会员卡号不能为空"></asp:requiredfieldvalidator></font></td>
											<td class="tdh" align="right" width="89">密码：</td>
											<td>&nbsp;
												<asp:textbox id="txtPwd" runat="server"  maxlength="20"></asp:textbox><font color="red">*
													<asp:requiredfieldvalidator id="vrftxtPwd" runat="server" errormessage="系统提示：会员密码不能为空" display="None" controltovalidate="txtPwd"></asp:requiredfieldvalidator></font></td>
									
										</tr>
                                        <tr><td>&nbsp;</td></tr>

										
										<tr>
											<td class="tdh" align="right" width="144" height="17">卡状态：</td>
											<td width="186" height="17">&nbsp;
												<asp:dropdownlist id="ddlStatus" runat="server"></asp:dropdownlist><font color="red"></font></td>
											<td class="tdh" align="right" width="89">会员级别：</td>
											<td>&nbsp;
												<asp:dropdownlist id="ddlMemLevelID" runat="server"></asp:dropdownlist>
                                                <asp:textbox id="txtAgent" runat="server" Visible="false" ></asp:textbox></td>
                                          </tr>
                                             <tr><td>&nbsp;</td></tr>



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
				<asp:button id="btnSave" runat="server" cssclass="button" text="保 存" OnClientClick="return ConfirmSave()"
                    onclick="btnSave_Click"></asp:button>&nbsp;
<%--				<input class="button" id="btnCancel" name="btnCancel" value="取 消" type="reset"/>&nbsp;--%>
				<asp:button id="btnDelete" runat="server" causesvalidation="False" 
                    cssclass="button" text="删 除" OnClientClick="return ConfirmDel()"  onclick="btnDelete_Click"></asp:button>&nbsp;
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