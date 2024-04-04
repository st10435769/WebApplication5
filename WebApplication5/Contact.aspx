<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication5.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
<form action="/" method="post">
    <label for="fname">First name:</label><br>
    <input type="text" required/><br />
    <label for="sname">Surname:</label><br>
    <input type="text" required maxlength="20"/><br />
    <label for="contact">Contact No:</label><br>
    <input type="text" required/><br />
    <label for="email">Email:</label><br>
    <input type="email" /><br />
    <label for="message">Send us a message:</label><br>
    <textarea name="Text1" required cols="40" rows="5"></textarea>
    <br>
    <br>
    <br>
    <input type="button" value="submit" />
</form>
</asp:Content>
