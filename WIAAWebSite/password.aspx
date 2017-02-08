<%@ Page Title="" Language="C#" MasterPageFile="~/wiaaMaster.master" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>Please enter the email address you used when making your application.</p>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>

