<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
            <asp:BoundField DataField="ModelNumber" HeaderText="ModelNumber" SortExpression="ModelNumber" />
            <asp:BoundField DataField="ModelName" HeaderText="ModelName" SortExpression="ModelName" />
            <asp:BoundField DataField="ProductImage" HeaderText="ProductImage" SortExpression="ProductImage" />
            <asp:BoundField DataField="UnitCost" HeaderText="UnitCost" SortExpression="UnitCost" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AutoLotConnectionString1 %>" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductID], [CategoryID], [ModelNumber], [ModelName], [ProductImage], [UnitCost], [Description]) VALUES (@ProductID, @CategoryID, @ModelNumber, @ModelName, @ProductImage, @UnitCost, @Description)" ProviderName="<%$ ConnectionStrings:AutoLotConnectionString1.ProviderName %>" SelectCommand="SELECT [ProductID], [CategoryID], [ModelNumber], [ModelName], [ProductImage], [UnitCost], [Description] FROM [Products]" UpdateCommand="UPDATE [Products] SET [CategoryID] = @CategoryID, [ModelNumber] = @ModelNumber, [ModelName] = @ModelName, [ProductImage] = @ProductImage, [UnitCost] = @UnitCost, [Description] = @Description WHERE [ProductID] = @ProductID">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
            <asp:Parameter Name="CategoryID" Type="String" />
            <asp:Parameter Name="ModelNumber" Type="String" />
            <asp:Parameter Name="ModelName" Type="String" />
            <asp:Parameter Name="ProductImage" Type="String" />
            <asp:Parameter Name="UnitCost" Type="Int32" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CategoryID" Type="String" />
            <asp:Parameter Name="ModelNumber" Type="String" />
            <asp:Parameter Name="ModelName" Type="String" />
            <asp:Parameter Name="ProductImage" Type="String" />
            <asp:Parameter Name="UnitCost" Type="Int32" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="ProductID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>