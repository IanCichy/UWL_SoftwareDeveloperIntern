﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="AddEmployee" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <form runat="server">
        <br />
        <br />
        <div class="container">
            <br />
            <br />
            <asp:Label runat="server" Text="Eagle ID:&nbsp&nbsp" />
            <asp:TextBox runat="server" ID="txtEagleID" type="login" CssClass="textbox" placeholder="NetID" /><br />
            <br />
            <asp:Button runat="server" ID="btnAddEmployee" Text="Add Employee" OnClick="btnAddEmployee_OnClick" />
        </div>
    </form>
</asp:Content>