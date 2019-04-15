<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="fld" runat="server" Text="Required field"></asp:Label><br />
            <asp:TextBox ID="field" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the field" ControlToValidate="field" Display="None" InitialValue="Please enter your name"></asp:RequiredFieldValidator><br />

            <asp:Label ID="rng" runat="server" Text="Range 0-100"></asp:Label><br />
            <asp:TextBox ID="range" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter value between 0-100" ControlToValidate="range" Display="None" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator><br />

            <asp:Label ID="ss" runat="server" Text="Enter your US SSN"></asp:Label><br />
            <asp:TextBox ID="ssn" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid ssn" Display="None" ControlToValidate="ssn" ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator><br />

            <asp:Label ID="vl" runat="server" Text="Value < 20"></asp:Label><br />
            <asp:TextBox ID="value" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Enter a value less than 20" ControlToValidate="value" Display="None" ValueToCompare="20" Type="Integer" Operator="LessThan"></asp:CompareValidator><br />

            <asp:Button ID="pbk" runat="server" Text="Button" OnClick="pbk_Click" />   <br />
            <asp:Label ID="hre" runat="server" Text="Here are the things you must correct"></asp:Label><br />
            <asp:ValidationSummary ID="ValidSum" runat="server" Width="333px" HeaderText="Here are the things you must correct" />
        </div>
    </form>
</body>
</html>
