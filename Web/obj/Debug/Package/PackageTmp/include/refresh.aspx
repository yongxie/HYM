<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="refresh.aspx.cs" Inherits="Web.include.refresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<meta http-equiv="refresh" content="5" />
<body>
<marquee id=mymar    scrollAmount="3" width="910" onmouseover="this.stop()" onmouseout="this.start()">
                                                <asp:Repeater ID="RptNews" runat="server"> 
                                                    <ItemTemplate> 
                                                             <%# Eval("NewsContent")%> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </ItemTemplate> 
                                                </asp:Repeater>

</marquee>
</body>
</html>