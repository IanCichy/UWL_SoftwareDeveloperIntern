<%@ Page Language="C#" MasterPageFile="~/Top.master" AutoEventWireup="true" CodeFile="ViewApplications.aspx.cs"
    Inherits="ViewApplications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div runat="server" id="content">
        <table>
            <tr>
                <td>
                    <asp:Repeater ID="daterangehallrep" runat="server">
                        <HeaderTemplate>
                            <table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="font-size:14px;">
                                    <%# DataBinder.Eval(Container.DataItem, "Hall") %>
                                    <asp:HiddenField ID="hallIDhidden" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "HallID") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Repeater ID="daterangerepouter" runat="server">
                                        <HeaderTemplate>
                                            <table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="font-size:13px; padding-left:15px;">
                                                    <%# DataBinder.Eval(Container.DataItem, "label") %>:
                                                    <asp:HiddenField ID="dateboundIDhidden" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Repeater ID="daterangerepinner" runat="server">
                                                        <HeaderTemplate>
                                                            <table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="padding-left:20px;">
                                                                    <asp:HyperLink ID="applink" runat="server"><%# DataBinder.Eval(Container.DataItem, "first") %><%# DataBinder.Eval(Container.DataItem, "last") %></asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
