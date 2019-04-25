<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_UserAuthorization_Index.aspx.cs"
    Inherits="Web.main_system.program.System_UserAuthorization_Index" %>

<html>
<head>
    <title>系统功能--用户管理设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../../css/default.css" type="text/css" rel="stylesheet">
</head>
<body>
    <table class="page_place" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="center" align="middle" width="32">
                <img height="16" src="../../images/page/page_place.gif" width="16">
            </td>
            <td>
                &nbsp;&nbsp;当前位置：系统功能 &gt; 用户管理
            </td>
        </tr>
    </table>
    <form id="System_UserAuthorization_Index" method="post" runat="server">
    <div align="center">
        <table cellspacing="0" cellpadding="0" align="left" border="0" style="width: 20%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <br />
            <tr>
                <td width="20" height="25">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="tableclass2" width="100%">
                    <asp:TreeView ID="tvCategory" runat="server" ShowLines="True" 
                        onselectednodechanged="tvCategory_SelectedNodeChanged">
                    </asp:TreeView>
                </td>
                <td width="95">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table id="Table1" cellspacing="0" cellpadding="0" width="77%" align="center" border="0">
            <tr>
                <td>
                    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td width="20" height="25">
                                <img height="25" src="../../images/page/table_tit_l2.gif" width="20">
                            </td>
                            <td class="title2" nowrap>
                                <strong>系统用户</strong>列表
                            </td>
                            <td width="10">
                                <img height="25" src="../../images/page/table_tit_r2.gif" width="10">
                            </td>
                            <td class="tdimages" width="99%">
                                <p align="right">
                                    <asp:Button ID="btnAdd" runat="server" Text="新  增" CssClass="button" OnClick="btnAdd_Click">
                                    </asp:Button>&nbsp;&nbsp;&nbsp;</p>
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
                    <table class="tableclass2" id="Table4" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td class="table_top2">
                            </td>
                        </tr>
                        <tr>
                            <td class="table_linebot">
                                <asp:DataGrid ID="MyDataGrid" runat="server" PagerStyle-Visible="False" AutoGenerateColumns="False"
                                    PageSize="20" AllowPaging="True" CellPadding="4" Width="100%" CssClass="tableclass"
                                    GridLines="Horizontal" OnItemCommand="DataOperate" ForeColor="#333333" BorderColor="Gray"
                                    BorderWidth="1px">
                                    <SelectedItemStyle ForeColor="#333333" BackColor="#C5BBAF" Font-Bold="True"></SelectedItemStyle>
                                    <ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" BackColor="#E3EAEB">
                                    </ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" BackColor="#1C5E55"
                                        Font-Bold="True"></HeaderStyle>
                                    <EditItemStyle BackColor="#7C6F57" />
                                    <FooterStyle ForeColor="White" BackColor="#1C5E55" Font-Bold="True"></FooterStyle>
                                    <AlternatingItemStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="用户名">
                                            <ItemTemplate>
                                                <asp:Label ID="LinkButton1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserID") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="真实姓名">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>'
                                                    ID="Label2" NAME="Label2">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="所属分组">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="性别">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sex") %>'
                                                    ID="Label4" NAME="Label4">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="电话">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Tel") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="年龄">
                                            <ItemTemplate>
                                                <asp:Label ID="LinkButton2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Age") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="手机">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Mobile") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="上级操作员">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Father") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:EditCommandColumn CancelText="取消" EditText="编辑" UpdateText="更新">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:EditCommandColumn>
                                        <asp:ButtonColumn CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '你确定删除所选的数据吗？ ') &quot;&gt; 删除 &lt;/div&gt; ">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:ButtonColumn>
                                    </Columns>
                                    <PagerStyle Visible="False" BackColor="#666666" ForeColor="White" HorizontalAlign="Center">
                                    </PagerStyle>
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_bot2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="tableclass" id="Table3" cellspacing="0" cellpadding="2" width="88%"
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
                                            <asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrentPage_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            页
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkFirst" runat="server" Visible="False" CommandArgument="First"
                                                CausesValidation="False" OnClick="Link_Click">首  页</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkPrevious" runat="server" Visible="False" CommandArgument="Previous"
                                                CausesValidation="False" OnClick="Link_Click">上一页</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkNext" runat="server" CommandArgument="Next" CausesValidation="False"
                                                OnClick="Link_Click">下一页</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkLast" runat="server" CommandArgument="Last" CausesValidation="False"
                                                OnClick="Link_Click">尾  页</asp:LinkButton>
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
                <td width="2" height="3">
                </td>
            </tr>
        </table>
        <br>
        <div align="center">
        </div>
        <br>
    </div>
    </form>
</body>
</html>
