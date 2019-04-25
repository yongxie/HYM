<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsManager_Category_Index.aspx.cs"
    Inherits="Web.main_charge.program.GoodsManager_Category_Index" %>

<html>
<head>
    <title>商品管理_商品分类</title>
    <%--/* ＊＊＊＊＊程序信息注释＊＊＊＊＊＊＊＊
          程序名：商品管理_商品分类程序
          程序描述：商品分类程序
         ＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊*/--%>
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
                当前位置：&nbsp;商品管理&nbsp;&gt;&nbsp;商品分类&nbsp;
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
                                商品分类浏览
                            </td>
                            <td width="10">
                                <img height="25" src="../../images/page/table_tit_r2.gif" width="10">
                            </td>
                            <td class="tdimages" width="99%" align="right">
                                商品分类名称：<asp:TextBox ID="txtGoodName" runat="server" Width="100px">&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                <asp:Button ID="btnCha" runat="server" Text="查  询"  OnClick="btnCha_Click">
                                </asp:Button>&nbsp;&nbsp;&nbsp;
                                <%--<asp:Button ID="btnAdd" runat="server" Text="新  增" CssClass="button" OnClick="btnAdd_Click">
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
                                        <asp:TemplateColumn Visible="true" HeaderText="行号">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>'
                                                    ID="Label5">
                                                </asp:Label>
                                                <input type="hidden" name="hidControl5" value='<%# DataBinder.Eval(Container, "DataItem.GoodsCategoryId") %>'
                                                    runat="server" id="hidControl5" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="false" HeaderText="商品分类ID">
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
                                        <asp:TemplateColumn HeaderText="商品分类名称">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'
                                                    CausesValidation="False" ID="Linkbutton2">
                                                </asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
           <%--                             <asp:TemplateColumn HeaderText="所属分类">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FatherName") %>'
                                                    CausesValidation="False" ID="Label1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>--%>
                                        <asp:ButtonColumn CommandName="AddBrother" Text="添加同级分类">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:ButtonColumn>
                                        <asp:ButtonColumn CommandName="AddSon" Text="添加子分类">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:ButtonColumn>
                                        <asp:EditCommandColumn CancelText="取消" EditText="编辑" UpdateText="更新">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:EditCommandColumn>
                                        <asp:ButtonColumn CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '你确定删除所选的数据吗？【此分类下有子节点或者有商品将禁止删除 】 ') &quot;&gt; 删除 &lt;/div&gt; ">
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
                                            共
                                            <asp:Label ID="lblRecNum" runat="server"></asp:Label>个记录
                                        </td>
                                        <td>
                                            第
                                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>页/共
                                            <asp:Label ID="lblTotalPage" runat="server"></asp:Label>页
                                        </td>
                                        <td>
                                            转到第
                                            <asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrentPage_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                            页
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkFirst" runat="server" Visible="False" CommandArgument="First"
                                                CausesValidation="False" OnClick="lnkFirst_Click">首  页</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkPrevious" runat="server" Visible="False" CommandArgument="Previous"
                                                CausesValidation="False" OnClick="lnkFirst_Click">上一页</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkNext" runat="server" CommandArgument="Next" CausesValidation="False"
                                                OnClick="lnkFirst_Click">下一页</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkLast" runat="server" CommandArgument="Last" CausesValidation="False"
                                                OnClick="lnkFirst_Click">尾  页</asp:LinkButton>
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
