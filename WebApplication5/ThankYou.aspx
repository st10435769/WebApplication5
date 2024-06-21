<%@ Page Title="Thank You" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="WebApplication5.ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    .container {
      padding-top: 50px;
    }

    h1 {
      font-size: 2em;
      margin-bottom: 20px;
    }

    p {
      font-size: 1.2em;
    }
  </style>
  <div class="container">
    <div class="row">
      <div class="col-md-12 text-center">
        <h1>Thank You for Your Order!</h1>
        <p>Your order has been successfully processed. We will send you a confirmation email shortly.</p>
      </div>
    </div>
  </div>
</asp:Content>
