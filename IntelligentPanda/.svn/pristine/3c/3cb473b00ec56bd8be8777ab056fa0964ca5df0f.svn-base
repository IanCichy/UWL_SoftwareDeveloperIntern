<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="wiaa_reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <link rel="stylesheet" href="../styles/layout.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="styles/WiaaStyleSheet.css" />
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">

    <article class="module width_3_quarter">
        <header>
            <h3>Reserve Rooms</h3>
        </header>
        <div class="module_content">

            <div>
                <table>
                    <tr>
                        <td style="width: 235px">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" ForeColor="Black"
                                OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="0">School Hall Assignment</asp:ListItem>
                                <asp:ListItem Value="1">Schools Needing Refund</asp:ListItem>
                                <asp:ListItem Value="2">Total Revenue</asp:ListItem>
                                <asp:ListItem Value="3">School Contact Info</asp:ListItem>
                                <asp:ListItem Value="4">Cancelled Schools</asp:ListItem>
                                <asp:ListItem Value="5">Volunteer Misc Charges</asp:ListItem>
                                <asp:ListItem Value="6">Volunteer Contact and Reservations</asp:ListItem>
                                <asp:ListItem Value="7">Schools and Reserved Rooms</asp:ListItem>
                                <asp:ListItem Value="8">School Billing</asp:ListItem>
                                <asp:ListItem Value="9">School Misc Charges</asp:ListItem>
                                <asp:ListItem Value="10">Number of Rooms per School</asp:ListItem>
                                <asp:ListItem Value="11">Arrival Times</asp:ListItem>
                                <asp:ListItem Value="12">Volunteer Room Reservations</asp:ListItem>
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
                            <asp:Panel ID="panel1" runat="server" Visible="false">
                                <asp:GridView ID="hallAssignGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="panel2" runat="server" Visible="false">
                                <asp:GridView ID="schoolRefundGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="panel3" runat="server" Visible="false">
                                <asp:GridView ID="TotalRevenueGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="panel4" runat="server" Visible="false">
                                <asp:GridView ID="schoolPhoneGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="panel5" runat="server" Visible="false">
                                <asp:GridView ID="cancelledSchoolGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="panel6" runat="server" Visible="false">
                                <asp:GridView ID="volMiscGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="panel7" runat="server" Visible="false">
                                <asp:GridView ID="volContactGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panel8" runat="server" Visible="false">
                                <asp:GridView ID="roomsReservedGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panel9" runat="server" Visible="false" ScrollBars="Both" Width="700px" Height="600px">
                                <asp:GridView ID="allTotalGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panel10" runat="server" Visible="false" ScrollBars="Both" Width="700px" Height="600px">
                                <asp:GridView ID="miscChargesGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panel11" runat="server" Visible="false" ScrollBars="Both" Width="700px" Height="600px">
                                <asp:GridView ID="numReservationsGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panel12" runat="server" Visible="false" ScrollBars="Both" Width="700px" Height="600px">
                                <asp:GridView ID="arrivalTimesGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panel13" runat="server" Visible="false" ScrollBars="Both" Width="700px" Height="600px">
                                <asp:GridView ID="volReservationsGrid" CssClass="Report" runat="server">
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </article>
</asp:Content>