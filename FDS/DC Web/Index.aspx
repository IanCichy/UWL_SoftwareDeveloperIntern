﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" MasterPageFile="MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form runat="server">
        <div>
            <br />
            <br />
            <asp:Button runat="server" ID="btnAddEmployee" Text="Add Employee" OnClick="btnAddEmployee_Click" />
            <br />
            <br />
            <asp:Table ID="tblEmployees" runat="server" />
            <br />
            <br />
            <br />
        </div>
    </form>
</asp:Content>