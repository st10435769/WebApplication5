<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication5.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Search through our curated collection of artisanal creations.</h3>
    <br />
    <asp:TextBox ID="SearchTextBox" runat="server" Width="300px" placeholder="Enter search term..."></asp:TextBox>
    <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
    <br /><br />
    <asp:Repeater ID="SearchResultsRepeater" runat="server">
        <ItemTemplate>
            <div>
                <h3><%# Eval("Product_Name") %></h3>
               <p>Price: <%# Eval("Product_Price", "{0:C}") %></p>
                <p>Description: <%# Eval("Product_Description") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div id="noResultsMessage" runat="server" visible="false">
    <h3>No products found.</h3>
</div>
</asp:Content>

