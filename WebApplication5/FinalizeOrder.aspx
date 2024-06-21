<%@ Page Title="Checkout" Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WebApplication5.Checkout" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Checkout</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        h2 {
            color: #333;
        }
        .cart-table {
            width: 100%;
            border-collapse: collapse;
        }
        .cart-table th, .cart-table td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .cart-table th {
            background-color: #f2f2f2;
            text-align: left;
        }
        .cart-table tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        .cart-table tr:hover {
            background-color: #ddd;
        }
        .checkout-button {
            margin-top: 10px;
            padding: 10px;
            background-color: #eb1515;
            color: white;
            border-radius: 5px;
            text-decoration: none;
        }
        .checkout-button1 {
            margin-top: 10px;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border-radius: 5px;
            text-decoration: none;
        }
        .back-button {
            margin-top: 10px;
            padding: 10px;
            background-color: #333;
            color: white;
            border-radius: 5px;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Checkout</h2>
            <asp:Repeater ID="CartRepeater" runat="server">
                <HeaderTemplate>
                    <table class="cart-table">
                        <thead>
                            <tr>
                                <th>Product Name</th>
                                <th>Price</th>
                                <th>Quantity</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Product_Name") %></td>
                        <td><%# Eval("Product_Price", "{0:C}") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td><%# Eval("TotalAmount", "{0:C}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="CheckoutButton" runat="server" Text="Clear Cart" CssClass="checkout-button" OnClick="CheckoutButton_Click" />
            <asp:Button ID="CheckoutButton1" runat="server" Text="Checkout" CssClass="checkout-button1" OnClick="CheckoutButton1_Click" />
            <asp:Button ID="BackButton" runat="server" Text="Back to Work" CssClass="back-button" OnClick="BackButton_Click" />
            <asp:Literal ID="NoItemsMessage" runat="server" Visible="False" Text="Your cart is empty." />
        </div>
    </form>
</body>
</html>
