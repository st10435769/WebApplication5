﻿<%@ Page Title="Register" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication5.Register" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %></title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
    #loginForm {
        margin: 0 auto; 
        width: 300px;
        text-align: center;
    }

    #loginForm div {
        margin-bottom: 10px;
        text-align: left;
    }
</style>
</head>
<body><div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" runat="server" href="~/"></a>
        </div>
        <div class="navbar-collapse collapse" >
            <ul class="nav navbar-nav" >
                <li><a runat="server" href="~/">Home</a></li>
                <li><a runat="server" href="~/About">About Us</a></li>
                <li><a runat="server" href="~/Contact">Contact Us</a></li>
                <li><a runat="server" href="~/Work">My Work</a></li>
                <li><a runat="server" href="~/Login">Login</a></li>
                <li><a runat="server" href="~/Register">Register</a></li>
            </ul>
        </div>
    </div>
</div>
    <form id="loginForm" runat="server" align="right">
        <h2>Register a new user</h2>
        <div>
            <label for="username">Username:</label>
            <asp:TextBox ID="username" runat="server" CssClass="form-control" required="required"></asp:TextBox>

        </div>
        <div>
            <label for="password">Password:</label>
            <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" required="required"></asp:TextBox>

        </div>
        <div>
            <label for="email">Email:</label>
            <asp:TextBox ID="email" runat="server" CssClass="form-control" required="required"></asp:TextBox>

        </div>
        <div>
    <label for="address">Address:</label>
    <asp:TextBox ID="address" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
            <div>
        <label for="contact_no">Contact No:</label>
    <asp:TextBox ID="contact_no" runat="server" CssClass="form-control"></asp:TextBox>

    </div>
        <div>
            <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click" />
        </div>
    </form>
</body>
</html>
