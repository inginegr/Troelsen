<%@ Page Language="C#" %>
<%@ Import Namespace="AutoLotConnectedLayer" %>
<%@ Assembly Name="AutoLotDAL" %>

<!DOCTYPE html>
<script runat="server">

    protected void btn_Click(object sender, EventArgs e)
    {
        InventoryDAL dAL = new InventoryDAL();
        dAL.OpenConnection(@"Data Source=(local)\SQLEXPRESS;" +
            "Initial Catalog=AutoLot;Integrated Security=True;Pooling=False");
        crs.DataSource = dAL.GetAllInventoryAsList();
        crs.DataBind();
        dAL.CloseConnection();
    }
</script>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">   
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="crs" runat="server" Height="142px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btn_Click" />

    </form>
</body>
</html>
