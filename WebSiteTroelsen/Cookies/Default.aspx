<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="CkName" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="CkName"></asp:Label><br />
        <asp:TextBox ID="CkValue" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Cookie value"></asp:Label><br />

        <asp:Button ID="btnWriteToCookie" runat="server" Text="Write to cookie" OnClick="btnWriteToCookie_Click" /><br />
        <asp:Button ID="btnReadFromCookie" runat="server" Text="Create cookie" OnClick="btnReadFromCookie_Click" /><br />
        <asp:Label ID="lbl" Text="Cookie data" runat="server"/>

    </form>
</body>
</html>
