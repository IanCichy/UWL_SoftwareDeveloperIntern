<%@ Page Language="C#" MasterPageFile="~/wiaaMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

Login:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="userBox" runat="server"></asp:TextBox><br />
<br />Password:<asp:TextBox ID="adPwordBox" runat="server" TextMode="Password"></asp:TextBox><br /><br />
<asp:Button ID="adminLogButton" runat="server" Text="Login" OnClick="adminLogButton_Click" /> 
</asp:Content>

