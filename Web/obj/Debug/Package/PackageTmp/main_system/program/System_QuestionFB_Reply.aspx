<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_QuestionFB_Reply.aspx.cs" Inherits="Web.main_system.program.System_QuestionFB_Reply" %>

<HTML>
	<HEAD>
		<title>问题反馈</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link href="../../css/Default.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../../js/Time_Popup.js"></script>
	</HEAD>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>当前位置：&nbsp;系统功能&nbsp;&gt;&nbsp;问题反馈
				
				</td>
			</tr>
		</table>
		<br/>
		<form id="form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
				<tr>
					<td>
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
								<td width="20" height="25"><img height="25" src="../../images/page/table_tit_l.gif" width="20"></td>
								<td class="title1" nowrap>问题反馈浏览</td>
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
											<td class="tdh" align="right">问题：</td>
											<td colspan="3">&nbsp;
                                                <asp:textbox ReadOnly="true" id="txtQuesName" runat="server"  maxlength="100" Width="500px"></asp:textbox>
										</tr><tr><td>&nbsp;</td></tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;提问者：<asp:Label ID="lblQer" runat="server" Text=""></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                提问时间：<asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td  align="right">问题内容：</td>
											<td colspan="3">&nbsp;
												<asp:textbox ReadOnly="true" id="txtQuesContent" runat="server" width="500px" rows="10" textmode="MultiLine"></asp:textbox>
												
                                                <br />
                                                <br />
                                            </td>
										</tr>
                                        <tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr>
                                        <tr id="trAnwser1" runat="server" visible="false">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;回复者：<asp:Label ID="lblAer" runat="server" Text=""></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                回复时间：<asp:Label ID="lblATime" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
										<tr>
											<td  align="right">回 复：</td>
											<td colspan="3">&nbsp;
												<asp:textbox id="txtAnwser" runat="server" width="500px" rows="20" textmode="MultiLine"></asp:textbox>
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
