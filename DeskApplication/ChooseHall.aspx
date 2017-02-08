<%@ Page Language="C#" MasterPageFile="~/Top.master" AutoEventWireup="true" CodeFile="ChooseHall.aspx.cs"
    Inherits="ChooseHall" EnableViewState="true" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Please choose your hall:
    <br />
    <br />
    <asp:DropDownList ID="ddlHall" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnContinue" runat="server" Text="Continue" onclick="btnContinue_Click"/>
</asp:Content>
