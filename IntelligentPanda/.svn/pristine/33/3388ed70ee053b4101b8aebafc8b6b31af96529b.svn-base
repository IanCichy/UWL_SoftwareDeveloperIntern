<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AlertInfo" runat="Server">
    <article class="module width_3_quarter">
        <header>
            <h3>Reserve Rooms</h3>
        </header>
        <div class="module_content">
            <p style="font-size: large">
                Database:
                <asp:Label ID="lblDB" runat="server" Text="***"></asp:Label>
                <br />
                Query:
                <asp:Label ID="lblQuery" runat="server" Text="***"></asp:Label>
            </p>
            <asp:Panel ID="pnlSearchResults" runat="server" Visible="true" ScrollBars="both" Width="680px" Height="620px">
                <br />
                <p style="font-size: large">
                    Reservation Info
                </p>
                <asp:GridView ID="gridReservations" runat="server">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <p style="font-size: large">
                    Rooms Reserved
                </p>

                <asp:GridView ID="gridRoomsReserved" runat="server">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </article>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
</asp:Content>