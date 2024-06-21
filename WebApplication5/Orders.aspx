<%@ Page Title="My Orders" Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="WebApplication5.Orders" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%: Page.Title %></title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        h2 {
            color: #333;
            text-align:center;
        }
        .orders-table {
            width: 100%;
            border-collapse: collapse;
        }
        .orders-table th, .orders-table td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .orders-table th {
            background-color: #f2f2f2;
            text-align: left;
        }
        .orders-table tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        .orders-table tr:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2><asp:Label ID="OrdersHeading" runat="server" Text="My Orders"></asp:Label></h2>
            <asp:GridView ID="OrdersGridView" runat="server" CssClass="orders-table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="PricePerItem" HeaderText="Price per Item" DataFormatString="{0:C}" SortExpression="PricePerItem" />
                    <asp:BoundField DataField="Totalamount" HeaderText="Total Amount" DataFormatString="{0:C}" SortExpression="Totalamount" />
                    <asp:BoundField DataField="Transaction_date" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" SortExpression="Transaction_date" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                </Columns>
            </asp:GridView>
            <asp:Literal ID="NoOrdersLiteral" runat="server" Visible="False" Text="No orders found." />
        </div>
    </form>
</body>
</html>
