﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DVDStats.aspx.cs" Inherits="DVDStats" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="FrmDVDStats" runat="server">
        <br />
        <br />
        <asp:Label ID="LblItems" runat="server" Text="Items per page" />
        <asp:DropDownList ID="DdlItemsfilter" runat="server" OnSelectedIndexChanged="DdlItemsfilter_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="15" Value="15" />
            <asp:ListItem Text="25" Value="25" />
            <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
            <asp:ListItem Text="All" Value="999" />
        </asp:DropDownList>

        <div runat="server" id="divDVDStats">
            <asp:GridView ID="gvDVDStats" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="15"
                DataSourceID="sqlDVDStats" BorderWidth="1px" OnRowCreated="gvDVDStats_RowCreated">
                <PagerStyle CssClass="pager-row" />
                <EditRowStyle CssClass="edit-row" />
                <SortedAscendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedAscendingHeaderStyle CssClass="Asc_Des_Header" />
                <SortedDescendingCellStyle CssClass="Asc_Des_Cell" />
                <SortedDescendingHeaderStyle CssClass="Asc_Des_Header" />
                <Columns>
                    <asp:BoundField DataField="LocId" HeaderText="LocId" ReadOnly="true" SortExpression="LocId" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="true" SortExpression="Title" />
                    <asp:BoundField DataField="Year" HeaderText="Year" ReadOnly="true" SortExpression="Year" />
                    <asp:BoundField DataField="Runtime" HeaderText="Runtime" ReadOnly="true" SortExpression="Runtime" />
                    <asp:BoundField DataField="MpaaRating" HeaderText="Mpaa Rating" ReadOnly="true" SortExpression="MpaaRating" />
                    <asp:BoundField DataField="TimesCheckedOut" HeaderText="Yearly Check Outs" ReadOnly="true" SortExpression="TimesCheckedOut" />
                    <asp:BoundField DataField="lastCheckedOut" HeaderText="last Checked Out" ReadOnly="true" SortExpression="lastCheckedOut" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sqlDVDStats" runat="server" SelectCommandType="StoredProcedure" SelectCommand="DVDStatsForHall">
                <SelectParameters>
                    <asp:SessionParameter Name="hallID" SessionField="hall" DefaultValue="-1" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <br />
        <br />
    </form>
</asp:Content>