<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="WebApplication5.Properties.ProductManagement" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Product Management</title>
    <script type="text/javascript">
        function showNotification(message) {
            alert(message);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="ProductNameTextBox" runat="server" placeholder="Product Name"></asp:TextBox>
            <asp:TextBox ID="PriceTextBox" runat="server" placeholder="Price"></asp:TextBox>
            <asp:TextBox ID="DescriptionTextBox" runat="server" placeholder="Description"></asp:TextBox>
            <asp:Button ID="UpdateButton" runat="server" Text="Update Product" OnClick="UpdateButton_Click" />
        </div>
    </form>
</body>
</html>
