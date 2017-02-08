<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="misc.aspx.cs" Inherits="ncaa_misc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <link rel="stylesheet" href="../styles/layout.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="styles/NcaaStyleSheet.css" />
    <!--[if lt IE 9]>
	<link rel="stylesheet" href="../styles/ie.css" type="text/css" media="screen" />
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
    <script src="../js/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../js/hideshow.js" type="text/javascript"></script>
    <script src="../js/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery.equalHeight.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AlertInfo" runat="Server">
    <h4 class="alert_info">5/22 2:55pm - Removing Reservations page has been fixed</h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <article class="module width_3_quarter">
                <header>
                    <h3 class="content-header">Add Charges</h3>
                </header>
                <div class="module_content">
                    <table>
                        <tr>
                            <td style="width: 324px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="School Name: "></asp:Label>
                                <asp:DropDownList ID="ddlReservation" runat="server" Height="22px"
                                    Width="150px" OnSelectedIndexChanged="ddlReservation_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Reason for Charge: "
                                    ForeColor="Black"></asp:Label>
                                <asp:DropDownList ID="ddlChargeType" runat="server" Height="22px"
                                    Width="150px" OnSelectedIndexChanged="ddlChargeType_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem>Lost Access Card</asp:ListItem>
                                    <asp:ListItem>Lost Room Key</asp:ListItem>
                                    <asp:ListItem>Fan</asp:ListItem>
                                    <asp:ListItem>Blanket</asp:ListItem>
                                    <asp:ListItem>Sheet</asp:ListItem>
                                    <asp:ListItem>Pillow</asp:ListItem>
                                    <asp:ListItem>Pillowcase</asp:ListItem>
                                    <asp:ListItem>Towel</asp:ListItem>
                                    <asp:ListItem>Washcloth</asp:ListItem>
                                    <asp:ListItem>Screen Removal</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="schoolNumberTextBox" runat="server" Text="1" Width="32px"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="otherLabel" runat="server" Text="Other Explanation:"
                                    ForeColor="Black" Visible="false"></asp:Label>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="otherTextBox" runat="server" Height="54px" TextMode="MultiLine"
                    Width="173px" Visible="false"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="dollarLabel" runat="server" Text="Dollar Amount: " ForeColor="Black" Visible="false"></asp:Label>
                                &nbsp;<asp:TextBox ID="dollarTextBox" runat="server" Width="96px" Visible="false"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                    ID="btnAddCharge" runat="server" Text="Add Charge"
                                    OnClick="btnAddCharge_Click" />
                                &nbsp;
                <asp:Button ID="btnRemove" runat="server" Text="Remove Selected"
                    OnClick="btnRemove_Click" Width="123px" />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                            </td>
                            <td style="border-width: thin; border-color: #000000; border-style: none none none groove;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl6" runat="server" Text="Currently being charged..."
                    ForeColor="Black"></asp:Label>
                                <br />
                                <asp:CheckBoxList ID="checkListBox" runat="server" ForeColor="Black">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 324px"></td>
                            <td style="border-left-style: groove; border-width: thin; border-color: #000000; border-top-style: dashed;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="totalLabel" runat="server" Text="Total: " ForeColor="Black"></asp:Label>
                                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Width="61px"></asp:TextBox>
                                <br />
                                <br />

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCharge" runat="server"
                    Text="Charge" OnClick="btnCharge_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </article>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>