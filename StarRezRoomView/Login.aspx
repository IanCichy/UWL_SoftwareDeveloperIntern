<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <form id="login_form" runat="server">
        <br />
        <br />
        <br />
        <div class="container">
            <label for="username">Username:</label>
            <asp:TextBox runat="server" ID="txtUsername" CssClass="Login" placeholder="NetId" />
            <label for="password">Password:</label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="Password" placeholder="Password"/>
            <asp:Button Style="margin-top: 1em; width: 80px; height: 30px;"
                type="submit" runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_OnClick" />
        </div>
    </form>
</asp:Content>