<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsManager_View.aspx.cs"
    Inherits="Web.main_charge.program.GoodsManager_View" %>

<html>
<head>
    <title>商品管理_商品查询</title>
    <%--/* ＊＊＊＊＊程序信息注释＊＊＊＊＊＊＊＊
          程序名：商品管理_商品查询程序
          程序描述：商品查询程序
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
                当前位置：&nbsp;商品管理&nbsp;&gt;&nbsp;商品查询&nbsp;
            </td>
        </tr>
    </table>
    <br />
    <form id="System_RecordOperate_View" method="post" runat="server">
    <div align="center">
        <table cellspacing="0" cellpadding="0" width="25%" align="left" border="0">
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
                <td width="20" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="tableclass2" width="100%" >
                    <asp:TreeView ID="tvCategory" runat="server" ShowLines="True"  Height="100%"
                        onselectednodechanged="tvCategory_SelectedNodeChanged">
                    </asp:TreeView>
                    <br />
                    
                </td>
                <td width="95">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="73%" align="center" border="0">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td width="20" height="25">
                                <img height="25" src="../../images/page/table_tit_l2.gif" width="20">
                            </td>
                            <td class="title2" nowrap>
                                商品信息查询浏览
                            </td>
                            <td width="10">
                                <img height="25" src="../../images/page/table_tit_r2.gif" width="10">
                            </td>
                            <td class="tdimages" width="99%" align="right">
                                商品ID：<asp:TextBox ID="txtGoodsId" runat="server" Width="100px">&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                商品名称：<asp:TextBox ID="txtGoodsName" runat="server" Width="100px">&nbsp;&nbsp;</asp:TextBox>&nbsp;&nbsp;
                                <asp:TextBox ID="txtId" runat="server" Width="10px" Visible ="false">&nbsp;&nbsp;</asp:TextBox>
                                <asp:TextBox ID="txtPageIndex" runat="server" Width="10px" Visible ="false">&nbsp;&nbsp;</asp:TextBox>
                                <%--商品类别：<asp:DropDownList ID="ddlGoodsCateID" runat="server" DESIGNTIMEDRAGDROP="70">
                                </asp:DropDownList>--%>
                                &nbsp;&nbsp;
                                <%--&nbsp;&nbsp;登记起始时间：<asp:TextBox id="txtBeginDate" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox><IMG style="CURSOR: hand" onclick="fPopUpCalendarDlg(txtBeginDate);return false" alt="" src="../../images/button/datetime.gif" align="absMiddle">
										<asp:CompareValidator id="vcvtxtBeginDate" runat="server" Display="None" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtBeginDate" ErrorMessage="系统提示：起始日期必须填写正确的日期格式！"></asp:CompareValidator>
										&nbsp;&nbsp;登记结束时间：<asp:TextBox id="txtEndDate" runat="server" Width="100px" >&nbsp;&nbsp;</asp:TextBox><IMG style="CURSOR: hand" onclick="fPopUpCalendarDlg(txtEndDate);return false" alt="" src="../../images/button/datetime.gif" align="absMiddle">
										<asp:CompareValidator id="vcvtxtEndDate" runat="server" Display="None" Operator="DataTypeCheck" Type="Date" ControlToValidate="txtEndDate" ErrorMessage="系统提示：结束日期必须填写正确的日期格式！"></asp:CompareValidator>
                                        
                                        <asp:validationsummary id="vvsError" runat="server" displaymode="List" showsummary="False" showmessagebox="True"></asp:validationsummary>--%>
                                <asp:Button ID="btnCha" runat="server" Text="查  询" CssClass="button" OnClick="btnCha_Click">
                                </asp:Button>&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAdd" runat="server" Text="新  增" CssClass="button" OnClick="btnAdd_Click">
                                </asp:Button>&nbsp;&nbsp;&nbsp;
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
                                <asp:DataGrid ID="GoodsDataGrid" runat="server" GridLines="Horizontal" CssClass="tableclass"
                                    Width="100%" CellPadding="4" AllowPaging="True" PageSize="20" AutoGenerateColumns="False"
                                    PagerStyle-Visible="False" OnItemCommand="GoodsDataGrid_ItemCommand" BorderColor="#336666"
                                    BorderWidth="3px" BackColor="White" BorderStyle="Double">
                                    <SelectedItemStyle ForeColor="White" BackColor="#339966" Font-Bold="True"></SelectedItemStyle>
                                    <ItemStyle HorizontalAlign="Center" Height="21px" CssClass="item" BackColor="White"
                                        ForeColor="#333333"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" Height="21px" ForeColor="White" BackColor="#336666"
                                        Font-Bold="True"></HeaderStyle>
                                    <FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="行号">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.idno") %>'
                                                    ID="Label5">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="商品ID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsID") %>'
                                                    CausesValidation="False" ID="Linkbutton2">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="商品名称">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsName") %>'
                                                    CausesValidation="False" ID="Linkbutton1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="单价">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Price","{0:N2}") %>'
                                                    CausesValidation="False" ID="Label1">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="商品类别">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GoodsCategoryDescription") %>'
                                                    CausesValidation="False" ID="Label2">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:EditCommandColumn CancelText="取消" EditText="编辑" UpdateText="更新">
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" />
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:EditCommandColumn>
                                        <asp:ButtonColumn CommandName="Delete" Text="&lt;div onclick= &quot;JavaScript:return confirm( '你确定删除所选的数据吗？ ') &quot;&gt; 删除 &lt;/div&gt; ">
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" />
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:ButtonColumn>
                                    </Columns>
                                    <PagerStyle Visible="False" BackColor="#336666" ForeColor="White" HorizontalAlign="Center"
                                        Mode="NumericPages"></PagerStyle>
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
