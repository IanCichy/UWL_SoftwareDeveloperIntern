<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="Account_settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <link rel="stylesheet" href="../styles/layout.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="styles/WiaaStyleSheet.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AlertInfo" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <article class="module width_3_quarter">
        <header>
            <h3 class="content-header">Settings</h3>
        </header>
        <div class="module_content">
            <div>
                <asp:CheckBox runat="server" ID="chkAutoprint" Text="Automatically Print Receipts" OnCheckedChanged="chkAutoprint_CheckedChanged" />
            </div>
            <div style="margin-top: 30px; margin-bottom: 15px;">
                <asp:Button runat="server" ID="btnUpdate" Text="Save Settings" OnClick="btnUpdate_Click" Font-Size="Large" OnClientClick="confirm('Settings saved!');" />
            </div>
        </div>
    </article>
</asp:Content>