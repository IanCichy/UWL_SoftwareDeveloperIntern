﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form id="login_form" runat="server">
        <!--Snow for Winter Fun!!-->
        <!--
        <script src="Scripts/jquery-2.1.0.min.js"></script>
        <script src="Scripts/snowfall.jquery.js"></script>
        <script>
            $(document).snowfall({ flakeCount: 150, round: true, minSize: 5, maxSize: 15 });
        </script>
        -->
        <br />
        <br />
        <br />
        <div class="container">
            <label for="username">Username:</label>
            <asp:TextBox type="login" runat="server" ID="txtUsername" CssClass="textbox" placeholder="NetId" />
            <label for="password">Password:</label>
            <asp:TextBox type="password" runat="server" ID="txtPassword" TextMode="Password" CssClass="textbox" />
            <asp:Button Style="margin-top: 1em; width: 80px; height: 30px;"
                type="submit" runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_OnClick" />
        </div>
    </form>
</asp:Content>