<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br/>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br/>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br/>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br/>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br />

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </form>
</body>
</html>
