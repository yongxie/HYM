<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsManager_Category_Index.aspx.cs"
    Inherits="Web.main_charge.program.GoodsManager_Category_Index" %>

<html>
<head>
    <title>��Ʒ����_��Ʒ����</title>
    <%--/* ����������������Ϣע�ͣ���������������
          ����������Ʒ����_��Ʒ�������
          ������������Ʒ�������
         ��������������������������������������*/--%>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../../css/Default.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../js/Time_Popup.js"></script>
</head>
<body>
    <table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="center" align="middle" width="32">
                <img height="16" src="../../images/page/page_place.gif" width="16">
            </td>
            <td>
                ��ǰλ�ã�&nbsp;��Ʒ����&nbsp;&gt;&nbsp;��Ʒ����&nbsp;
            </td>
        </tr>
    </table>
    <br />
    <form id="System_RecordOperate_View" method="post" runat="server">
    <div align="center">
        <table cellspacing="0" cellpadding="0" width="98%" align="right" border="0">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td width="20" height="25">
                                <img height="25" src="../../images/page/table_tit_l2.gif" width="20">
                            </td>
                            <td class="title2" nowrap>
                                ��Ʒ�������
                            </td>
                            <td width="10">
                                <img height="25" src="../../images/page/table_tit_r2.gif" width="10">
                            </td>
                            <td class="tdimages" width="99%" align="right">
                                ��Ʒ�������ƣ�<asp:TextBox ID="txtGoodName" runat="server" Width="100px">&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                <asp:Button ID="btnCha" runat="server" Text="��  ѯ"  OnClick="btnCha_Click">
                                </asp:Button>&nbsp;&nbsp;&nbsp;
                                <%--<asp:Button ID="btnAdd" runat="server" Text="��  ��" CssClass="button" OnClick="btnAdd_Click">
                                </asp:Button>&nbsp;&nbsp;&nbsp;--%>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="2">
                    <img height="2" src="../../images/page/table_dot_r2.gif" width="2">
                </td>
            </tr>
            <tr>
                <td>
                    <table class="tableclass2" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="table_top2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataGrid ID="MyDataGrid" runat="server" GridLines="Horizontal" CssClass="tableclass"
                                    Width="100%" CellPadding="4" AllowPaging="True" PageSize="20" AutoGenerateColumns="False"
                                    PagerStyle-Visible="False" OnItemCommand="MyDataGrid_ItemCommand" BorderColor="#336666"
                                    BorderWidth="3px" BackColor="White" BorderStyle="Double">
                                    <ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" BackColor="White"
                                        ForeColor="#333333"></ItemStyle>
                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" BackColor="#336666"
                                        Font-Bold="True"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateColumn Visible="true" HeaderText="�к�">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>'
                                                    ID="Label5">
                                                </asp:Label>
                                                <input type="hidden" name="hidControl5" value='<%# DataBinder.Eval(Container, "DataItem.GoodsCategoryId") %>'
                                                    runat="server" id="hidControl5" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="false" HeaderText="��Ʒ����ID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsCategoryId") %>'
                                                    CausesValidation="False" ID="Linkbutton1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Width = "40"
                                                    CausesValidation="False" ID="Label1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="��Ʒ��������">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'
                                                    CausesValidation="False" ID="Linkbutton2">
                                                </asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
           <%--                             <asp:TemplateColumn HeaderText="��������">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FatherName") %>'
                                                    CausesValidation="False" ID="Label1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>--%>
                                        <asp:ButtonColumn CommandName="AddBrother" Text="���ͬ������">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:ButtonColumn>
                                        <asp:ButtonColumn CommandName="AddSon" Text="����ӷ���">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:ButtonColumn>
                                        <asp:EditCommandColumn CancelText="ȡ��" EditText="�༭" UpdateText="����">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:EditCommandColumn>
                                        <asp:ButtonColumn CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '��ȷ��ɾ����ѡ�������𣿡��˷��������ӽڵ��������Ʒ����ֹɾ�� �� ') &quot;&gt; ɾ�� &lt;/div&gt; ">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Center" />
                                        </asp:ButtonColumn>
                                        

                                    </Columns>
                                    <PagerStyle Visible="False" BackColor="#336666" ForeColor="White" HorizontalAlign="Center"
                                        Mode="NumericPages"></PagerStyle>
                                    <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_bot2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="tableclass" id="Table3" cellspacing="0" cellpadding="2" width="100%"
                                    border="0">
                                    <tr align="middle">
                                        <td>
                                            ��
                                            <asp:Label ID="lblRecNum" runat="server"></asp:Label>����¼
                                        </td>
                                        <td>
                                            ��
                                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>ҳ/��
                                            <asp:Label ID="lblTotalPage" runat="server"></asp:Label>ҳ
                                        </td>
                                        <td>
                                            ת����
                                            <asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrentPage_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                            ҳ
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkFirst" runat="server" Visible="False" CommandArgument="First"
                                                CausesValidation="False" OnClick="lnkFirst_Click">��  ҳ</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkPrevious" runat="server" Visible="False" CommandArgument="Previous"
                                                CausesValidation="False" OnClick="lnkFirst_Click">��һҳ</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkNext" runat="server" CommandArgument="Next" CausesValidation="False"
                                                OnClick="lnkFirst_Click">��һҳ</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkLast" runat="server" CommandArgument="Last" CausesValidation="False"
                                                OnClick="lnkFirst_Click">β  ҳ</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" align="left" width="2" bgcolor="#bfbfbf">
                    <img height="2" src="../../images/page/table_dot_r.gif" width="2">
                </td>
            </tr>
            <tr bgcolor="#bfbfbf">
                <td>
                    <img height="3" src="../../images/son/table_dot_l.gif" width="2">
                </td>
                <td width="2">
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
