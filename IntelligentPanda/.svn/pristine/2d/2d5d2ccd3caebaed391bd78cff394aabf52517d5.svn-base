<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="wiaa_reports" EnableEventValidation="false" %>

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

    <article class="module width_3_quarter">
        <header>
            <h3>Reports</h3>
        </header>
        <div class="module_content">

            <div>
                <table>
                    <tr>
                        <td style="width: 235px">
                            <asp:RadioButtonList ID="rblReport" runat="server" ForeColor="Black"
                                OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="0">Reservations</asp:ListItem>
                                <asp:ListItem Value="1">Contact Information</asp:ListItem>
                                <asp:ListItem Value="2">Rooms Reserved</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />

                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="generateButton"
                                runat="server" Text="Generate" OnClick="generateButton_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="exportButton" runat="server" Text="Export"
                                OnClick="exportButton_Click" />
                        </td>
                    </tr>
                </table>
                <table align="center">
                    <tr>

                        <td>
                            <br />
                            <asp:Panel ID="pnlReservations" runat="server" Visible="false" ScrollBars="both" Width="680px" Height="620px">
                                <asp:GridView ID="gridReservations" runat="server">
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="pnlContactInfo" runat="server" Visible="false" ScrollBars="both" Width="680px" Height="620px">
                                <asp:GridView ID="gridContact" runat="server">
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="pnlRoomsReserved" runat="server" Visible="false" ScrollBars="both" Width="680px" Height="620px">
                                <asp:GridView ID="gridRoomsReserved" runat="server">
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </article>
</asp:Content>