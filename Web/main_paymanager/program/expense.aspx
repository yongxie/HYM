<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="expense.aspx.cs" Inherits="Web.main_paymanager.program.expense" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<html>
	<head>
		<title>���ѹ�������������</title>
        <%--/* ����������������Ϣע�ͣ���������������
          ����������Ʒ����_��Ʒ��ѯ����
          ������������Ʒ��ѯ����
         ��������������������������������������*/--%>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
		<link href="../../css/Default.css" type="text/css" rel="stylesheet"/>
			<script language="javascript" src="../../js/Time_Popup.js"></script>

              <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     var top = 0;
     var selected = 0; //Ĭ��ѡ���0��
     function setInfo() {
         var test = escape($("#txtGoodsCode").val());
         if (test == "") {
             selected = 0;
             $("#Info").hide(0);
             return;
         }
         var url = "gouwu.aspx?keyword=" + test;
         $.get(url, function (data) {
             if (data == "") {
                 $("#Info").hide(0);
                 return;
             }

             var html = "";
             var arr = data.split(',');
             if (arr.length == 0) {
                 $("#Info").hide(0);
             }
             top = arr.length;
             for (var i = 0; i < arr.length; i++) {
                 html += "<div id='" + i + "' onclick=\"Show('" + arr[i] + "')\" >" + arr[i] + "</div>";
             }
             $("#Info").show(0);
             $("#Info").html(html);

         });
     }
     function Show(text) {
         $("#txtGoodsCode").val(text);
         $("#Info").hide(0);
     }

     function select(id) {
         $("#Info div").css("background-color", "White");
         $("#" + id).css("background-color", "Gray");
     }
     function SelectItemEvent() {
         var items = $("#Info div");
         //��׽�����¼�
         $(document).keydown(function (e) {
             if (e.keyCode == 38) {//�ϼ�ͷ
                 selected--;
                 if (selected < 0) selected = (top - 1);

             } else if (e.keyCode == 40) {//�¼�ͷ
                 selected++;
                 if (selected > (top - 1)) selected = 0;

             } else if (e.keyCode == 13) {
                 $("#txtGoodsCode").blur();
                 $("#txtGoodsCode").val($("#" + selected).text());
                 $("#Info").hide(0);
             }

         });
         $(document).ajaxComplete(function (e) {

             select(selected);
         });
     }
     $(document).ready(function () {
         SelectItemEvent();
     });
     
    </script>
  
   


  
     <style type="text/css">
     .Info
      {
          position:absolute;
          left:122px;
          top:192px;
          }
    </style>








	</head>
	<body>
		<table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td valign="center" align="middle" width="32"><img height="16" src="../../images/page/page_place.gif" width="16"></td>
				<td>��ǰλ�ã�&nbsp;���ѹ���&nbsp;&gt;&nbsp;��������&nbsp;
				</td>
			</tr>
		</table>
		<br/>

		<form id="System_RecordOperate_View" method="post" runat="server">

        </asp:ScriptManager>
			<div align="center">
				<table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
					<tr>
						<td>
							<table cellspacing="0" cellpadding="0" width="100%" border="0">
								<tr>
									<td width="20" height="25"><img height="25" src="../../images/page/table_tit_l2.gif" width="20"></td>
									<td class="title2" nowrap>��Ա����</td>
									<td width="10"><img height="25" src="../../images/page/table_tit_r2.gif" width="10"></td>

									<td  width="99%" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                                                           <td class="tdimages" width="99%" align="right">
                                    						&nbsp;</td>
								       
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
									<td class="tdimages" width="99%" align="left"><br /><br /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        ���ѽ�<asp:TextBox id="TextAmt" runat="server" Width="100px" TabIndex="5" ></asp:TextBox>&nbsp;&nbsp;
                                     <asp:Button ID="Luru" runat="server" Text="¼��" onclick="Luru_Click" TabIndex="6"/>   
                                     <br /><br /><br />

                                    <br /><br />
                                    </td>
								</tr>
                                <tr>
									<td class="tdimages" width="99%" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    ��Ա���ţ�<asp:TextBox id="txtCardID2" runat="server" Width="100px" 
                                            AutoCompleteType="Disabled" autocomplete="off" onfocus="return clear()"  ></asp:TextBox>&nbsp;&nbsp;
                                    ���룺<asp:TextBox id="txtPwd2" runat="server" Width="100px" 
                                            AutoCompleteType="Disabled" autocomplete="off"  TextMode="Password" 
                                            onfocus="return clear()" TabIndex="1" ></asp:TextBox>
                                        &nbsp;&nbsp;
                                     <asp:Button ID="btnShuaka" runat="server" Text="ˢ��" onclick="btnShuaka_Click" 
                                            TabIndex="2"/>
                                      &nbsp;&nbsp;
                                     <asp:Button ID="btnClear" runat="server" Text="���" onclick="btnClear_Click" 
                                            OnClientClick= "return Clear()" TabIndex="3"  />&nbsp;&nbsp;
                                    <asp:button id="btnSave" runat="server"  text="��ֵ" 
                            onclick="btnSave_Click" TabIndex="12"></asp:button>&nbsp;&nbsp;
                                     <br />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                    
                                    </td>
								</tr>
                                <tr>
									<td class="tdimages" width="99%" align="left"><br /><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    ��Ա���ţ�<asp:Label id="lbCardID" runat="server" Width="100px" TabIndex="25" >&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;
                                        &nbsp;&nbsp;
                                      &nbsp;&nbsp;
                                     <br /><br /><br />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    ��Ա������<asp:Label id="lbUserName" runat="server" Width="100px" TabIndex="27" >&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;
                                    ��<asp:Label id="lbAccount" runat="server" Width="100px" TabIndex="26" >&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;
                                    <br /><br /><br />
                                    </td>

								</tr>
                                <tr>
									<td class="table_top2"></td>
								</tr>
								<tr>
									<td><asp:datagrid id="GoodsDataGrid" runat="server" gridlines="Horizontal" 
                                            cssclass="tableclass" width="100%" 
                                            cellpadding="4" allowpaging="True" pagesize="20" autogeneratecolumns="False" 
                                            pagerstyle-visible="False" ForeColor="#333333" BorderColor="Gray" 
                                            BorderWidth="1px" TabIndex="14" onitemcommand="GoodsDataGrid_ItemCommand" >
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
													</ItemTemplate>
												</asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="��Ʒ����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsCode") %>' CausesValidation="False" ID="Linkbutton2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="��Ʒ����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsName") %>' CausesValidation="False" ID="Linkbutton1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>

												<asp:TemplateColumn HeaderText="����">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Price","{0:N2}") %>' CausesValidation="False" ID="Label1">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="��������">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Count") %>' CausesValidation="False" ID="Label2">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="���">
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Money","{0:N2}") %>' CausesValidation="False" ID="Label22">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:ButtonColumn CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '��ȷ��ɾ����ѡ�������� ') &quot;&gt; ɾ�� &lt;/div&gt; ">
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Left" />
                                                </asp:ButtonColumn>
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
													<asp:label id="lblRecNum" runat="server" TabIndex="23"></asp:label>����¼</td>
												<td>��
													<asp:label id="lblCurrentPage" runat="server" TabIndex="22"></asp:label>ҳ/��
													<asp:label id="lblTotalPage" runat="server" TabIndex="21"></asp:label>ҳ</td>
												<td>ת����
													<asp:dropdownlist id="ddlCurrentPage" runat="server" autopostback="True" 
                                                        onselectedindexchanged="ddlCurrentPage_SelectedIndexChanged1" 
                                                        TabIndex="48"></asp:dropdownlist>ҳ
												</td>
												<td><asp:linkbutton id="lnkFirst" runat="server" visible="False" 
                                                        commandargument="First" causesvalidation="False" onclick="lnkFirst_Click" 
                                                        TabIndex="17">��  ҳ</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkPrevious" runat="server" visible="False" 
                                                        commandargument="Previous" causesvalidation="False" 
                                                        onclick="lnkFirst_Click" TabIndex="18">��һҳ</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkNext" runat="server" commandargument="Next" 
                                                        causesvalidation="False" onclick="lnkFirst_Click" TabIndex="16">��һҳ</asp:linkbutton></td>
												<td><asp:linkbutton id="lnkLast" runat="server" commandargument="Last" 
                                                        causesvalidation="False" onclick="lnkFirst_Click" TabIndex="20">β  ҳ</asp:linkbutton></td>
											</tr>
										</table>

                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        �ܼƽ�<asp:TextBox id="txtSumMoney" runat="server" Width="100px" TabIndex="24" ></asp:TextBox>&nbsp;&nbsp;
                                        <br />
                                        <br />
                                        <br />
                                        <br />
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
					<asp:Button id="btnJiezhang" runat="server" Text="��  ��" CssClass="button" 
                        onclick="btnJiezhang_Click" TabIndex="7"></asp:Button>
			&nbsp;<br />
                    <br /><br />
				</div>
			</div>
		</form>
	</body>
</html>




<script type="text/javascript" defer="defer">
    window.onload = function () {
        document.getElementById("txtPwd2").value = "";
        document.getElementById("txtCardID2").value = "";
        var a = document.getElementById("txtCardID2").value;
        //alert(a);
    }
</script>
<script type="text/javascript" >
    function Clear() {
        document.getElementById("txtCardID2").value = "";
        document.getElementById("txtPwd2").value = "";

        //var a = document.getElementById("txtCardID2").value;
        //alert(a);
    }
</script>