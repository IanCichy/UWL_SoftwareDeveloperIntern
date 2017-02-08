<%@ Page Language="C#" MasterPageFile="~/Top.master" AutoEventWireup="true" CodeFile="Login.aspx.cs"
    Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 50%">
                <tr>
                    <td class="prequestiontext">
                        Username:
                    </td>
                    <td class="prequestionbox">
                        <asp:TextBox CssClass="contenttextbox" ID="username" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="prequestiontext">
                        Password:
                    </td>
                    <td class="prequestionbox">
                        <asp:TextBox CssClass="contenttextbox" TextMode="Password" ID="password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="buttoncell" colspan="2">
                        <asp:Button CssClass="button" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div runat="server" id="errordiv" class="errordiv">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
