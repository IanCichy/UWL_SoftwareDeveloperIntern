<%@ Page Language="C#" MasterPageFile="~/wiaaMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 705px; text-align: center;">
        <asp:Panel runat="server" ID="loginPanel" Style="text-align: left" DefaultButton="btnLogin">
            <b><asp:Label ID="lblResStart" runat="server" Text="Label"></asp:Label></b>
            <asp:Label ID="reservLabel" runat="server" Visible="False"></asp:Label><br />
            <br />
            <asp:Button ID="btnNewRes" runat="server" style="margin-bottom: 30px;" Text="Create New Reservation" Visible="false" OnClick="btnNewRes_Click" />
            <div runat="server" id="divLogin" style="width: 705px">
                <!-- THIS CONTENT GETS DYNAMICALLY GENERATED -->
            </div>
            <br />
            <div id="divCredentials" runat="server">
                To view your reservation, please login with the email address and password that you entered at the registration page.
                <br />
                *Accounts from previous years are not active. You may register with the same credentials as past years.
                <br />
                <br />
                <asp:Label ID="emailAddLabel" runat="server" Text="Email Address:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="passLabel" runat="server" Text="Password:"></asp:Label>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <a href="password.aspx">Forgot Password?</a><br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </asp:Panel>
</asp:Content>
